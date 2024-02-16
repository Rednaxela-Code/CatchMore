using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using CatchMore.Models.ViewModels;
using CatchMore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class CatchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CatchController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public IActionResult Index()
        {
            var objCatchList = _unitOfWork.Catch.GetAll(includeProperties: "Session").Where(u => u.ApplicationUserId == GetUserId()).ToList();
            return View(objCatchList);
        }

        [Authorize]
        public IActionResult Create()
        {
            var userId = GetUserId();
            var sessionList = _unitOfWork.Session.GetAll();
            sessionList = sessionList.Where(u => u.ApplicationUserId == userId).ToList();
            var catchViewModel = new CatchVM()
            {
                SessionList = sessionList.ToList()
                //SessionList = _unitOfWork.Session.GetAll().Where(u => u.ApplicationUserId == userId).ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Date.ToString(),
                    Value = s.Id.ToString(),
                }),
                Catch = new Catch()
                {
                    ApplicationUserId = userId,
                }
            };
            return View(catchViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CatchVM catchVM, IFormFile? file)
        {
            if (catchVM.Catch.ApplicationUserId == GetUserId())
            {
                if (catchVM.Catch.Date > DateTime.Now)
                {
                    ModelState.AddModelError("Date", "The Catch start date must be in the past.");
                }
                //if (ModelState.IsValid)
                //{
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = String.Concat(Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));
                    string catchPath = Path.Combine(wwwRootPath, @"images\catch");

                    using (var fileStream = new FileStream(Path.Combine(catchPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    catchVM.Catch.Image = String.Concat(@"\images\catch\", fileName);
                }
                _unitOfWork.Catch.Add(catchVM.Catch);
                _unitOfWork.Save();
                TempData["success"] = "Catch created successfully";
                return RedirectToAction("Index", "Catch");
                //}
                //else
                //{
                //    catchVM.SessionList = _unitOfWork.Session.GetAll().Where(u => u.ApplicationUserId == GetUserId())
                //    .Select(s => new SelectListItem
                //    {
                //        Text = s.Date.ToString(),
                //        Value = s.Id.ToString(),
                //    });
                //    return View(catchVM);
                //}
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userId = GetUserId();
            var sessionList = _unitOfWork.Session.GetAll();
            sessionList = sessionList.Where(u => u.ApplicationUserId == userId).ToList();
            var catchFromDb = new CatchVM()
            {
                SessionList = sessionList
                .Select(s => new SelectListItem
                {
                    Text = s.Date.ToString(),
                    Value = s.Id.ToString(),
                }),
                Catch = _unitOfWork.Catch.Get(u => u.ApplicationUserId == GetUserId() && u.Id == id)
            };
            if (catchFromDb == null)
            {
                return NotFound();
            }
            return View(catchFromDb);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit(CatchVM catchVM, IFormFile? file)
        {
            if (catchVM.Catch.ApplicationUserId == GetUserId())
            {
                //if (ModelState.IsValid)
                //{
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = String.Concat(Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));
                    string catchPath = Path.Combine(wwwRootPath, @"images\catch");

                    if (!string.IsNullOrEmpty(catchVM.Catch.Image))
                    {
                        //Delete old Image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, catchVM.Catch.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(catchPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    catchVM.Catch.Image = String.Concat(@"\images\catch\", fileName);
                }
                _unitOfWork.Catch.Update(catchVM.Catch);
                _unitOfWork.Save();
                TempData["success"] = "Catch updated successfully";
                return RedirectToAction("Index", "Catch");
                //}
            }
            else
            {
                return View();
            }
        }

        #region API CALLS
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var objCatchList = _unitOfWork.Catch.GetAll(includeProperties: "Session").Where(u => u.ApplicationUserId == GetUserId()).ToList();
            return Json(new { data = objCatchList });
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            var catchToBeDeleted = _unitOfWork.Catch.Get(i => i.ApplicationUserId == GetUserId() && i.Id == id);
            if (catchToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            if (!string.IsNullOrEmpty(catchToBeDeleted.Image))
            {
                var oldImagePath =
                            Path.Combine(_webHostEnvironment.WebRootPath,
                            catchToBeDeleted.Image.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Catch.Remove(catchToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Catch Deleted" });
        }
        #endregion
        private string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}

using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using CatchMore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CatchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objCatchList = _unitOfWork.Catch.GetAll().ToList();
            return View(objCatchList);
        }

        public IActionResult Create()
        {
            var catchViewModel = new CatchVM()
            {
                SessionList = _unitOfWork.Session.GetAll()
                .Select(s => new SelectListItem
                {
                    Text = s.Date.ToString(),
                    Value = s.Id.ToString(),
                }),
                Catch = new Catch()
            };
            return View(catchViewModel);
        }

        [HttpPost]
        public IActionResult Create(CatchVM catchVM)
        {
            if (catchVM.Catch.Date > DateTime.Now)
            {
                ModelState.AddModelError("Date", "The Catch start date must be in the past.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Catch.Add(catchVM.Catch);
                _unitOfWork.Save();
                TempData["success"] = "Catch created successfully";
                return RedirectToAction("Index", "Catch");
            }
            else
            {
                catchVM.SessionList = _unitOfWork.Session.GetAll()
                .Select(s => new SelectListItem
                {
                    Text = s.Date.ToString(),
                    Value = s.Id.ToString(),
                });
                return View(catchVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catchFromDb = _unitOfWork.Catch.Get(i => i.Id == id);
            if (catchFromDb == null)
            {
                return NotFound();
            }
            return View(catchFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Catch obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Catch.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Catch updated successfully";
                return RedirectToAction("Index", "Catch");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catchFromDb = _unitOfWork.Catch.Get(i => i.Id == id);
            if (catchFromDb == null)
            {
                return NotFound();
            }
            return View(catchFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Catch.Get(i => i.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Catch.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Catch deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using CatchMore.Models.ViewModels;
using CatchMore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Security.Claims;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class SessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult Index()
        {
            var sessionList = _unitOfWork.Session.GetAll().Where(u => u.ApplicationUserId == GetUserId()).ToList();

            return View(sessionList);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Session obj)
        {
            if (obj.ApplicationUserId == null)
            {
                obj.ApplicationUserId = GetUserId();
            }

            if (obj.Date > DateTime.Now)
            {
                ModelState.AddModelError("Date", "The Session start date must be in the past.");
            }
            obj.Latitude = obj.Latitude.CorrectDouble();
            obj.Longitude = obj.Longitude.CorrectDouble();
            _unitOfWork.Session.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Session created successfully";
            return RedirectToAction("Index", "Session");
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sessionFromDb = _unitOfWork.Session.Get(i => i.ApplicationUserId == GetUserId() && i.Id == id);
            if (sessionFromDb == null)
            {
                return NotFound();
            }
            return View(sessionFromDb);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Session obj)
        {
            obj.ApplicationUserId = GetUserId();
            _unitOfWork.Session.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Session updated successfully";
            return RedirectToAction("Index", "Session");
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sessionFromDb = _unitOfWork.Session.Get(i => i.ApplicationUserId == GetUserId() && i.Id == id);
            if (sessionFromDb == null)
            {
                return NotFound();
            }
            return View(sessionFromDb);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Session.Get(i => i.ApplicationUserId == GetUserId() && i.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Session.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Session deleted successfully";
            return RedirectToAction("Index");
        }
        private string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}

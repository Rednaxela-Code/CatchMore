using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objSessionList = _unitOfWork.Session.GetAll().ToList();
            return View(objSessionList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Session obj)
        {
            if (obj.Date > DateTime.Now)
            {
                ModelState.AddModelError("Date", "The Session start date must be in the past.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Session.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Session created successfully";
                return RedirectToAction("Index", "Session");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sessionFromDb = _unitOfWork.Session.Get(i => i.Id == id);
            if (sessionFromDb == null)
            {
                return NotFound();
            }
            return View(sessionFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Session obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Session.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Session updated successfully";
                return RedirectToAction("Index", "Session");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sessionFromDb = _unitOfWork.Session.Get(i => i.Id == id);
            if (sessionFromDb == null)
            {
                return NotFound();
            }
            return View(sessionFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Session.Get(i => i.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Session.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Session deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

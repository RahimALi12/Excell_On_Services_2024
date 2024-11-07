using Excell_On_Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Excell_On_Services.Controllers
{

    [Authorize(Policy = "RequireAdminRole")]

    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _AppDbContext;
        public DashboardController(ApplicationDbContext AppDb)
        {
            this._AppDbContext = AppDb;
        }

        public IActionResult Index()
        {
            var services = _AppDbContext.Service.ToList();
            var contacts = _AppDbContext.Contacts.ToList();
            ViewBag.Services = services;
            ViewBag.Contacts = contacts;
            return View();
        }

        public IActionResult ServiceIndex()
        {
            ViewBag.Data = _AppDbContext.Service.ToList();
            return View();
        }

        public IActionResult AddService()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Services svc)
        {
            _AppDbContext.Service.Add(svc);
            _AppDbContext.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
            return View();
        }

        public IActionResult DetailService(int id)
        {
            var detailData = _AppDbContext.Service.Find(id);

            //var detailData = _AppDbContext.Employees.Include(x => x.Dept).FirstOrDefault(x => x.EmpId == id);

            return View(detailData);
        }

        public IActionResult EditService(int id)
        {
            var editData = _AppDbContext.Service.Find(id);
            return View(editData);
        }

        [HttpPost]
        public IActionResult EditService(int id, Services svc)
        {
            if (ModelState.IsValid)
            {
                _AppDbContext.Service.Update(svc);
                _AppDbContext.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public IActionResult Message()
        {
            ViewBag.Data = _AppDbContext.Contacts.ToList();
            return View();
        }

        public IActionResult DeleteService(int id)
        {
            var deleteData = _AppDbContext.Service.Find(id);
            return View(deleteData);
        }

        [HttpPost, ActionName("DeleteService")]

        public IActionResult ConfirmDelete(int id)
        {
            var confirmDelete = _AppDbContext.Service.Find(id);
            if (confirmDelete != null)
            {
                _AppDbContext.Service.Remove(confirmDelete);
                _AppDbContext.SaveChanges();
                return RedirectToAction("index", "Dashboard");
            }
            return View();
        }

    }
}

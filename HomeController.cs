using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Library;

namespace MVC_Model.Controllers
{
    public class HomeController : Controller
    {
        Operations operations = new Operations();
        public ActionResult Index()
        {
            return View(operations.GetAllEmployees());
        }

        [HttpGet]
        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(Employee e)
        {
            operations.AddEmployee(e);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(int id)
        {
            var emp = (from em in operations.GetAllEmployees() where em.eid == id select em).First();
            return View(emp);

        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee emp)
        {
            operations.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            operations.DeleteEmployee(id);
            return RedirectToAction("Index");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
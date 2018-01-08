using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    public class EmployerController : Controller
    {

        EmployerDAO eDAO = new EmployerDAO();
        SpecialityDAO specialityDAO = new SpecialityDAO();

        public ActionResult Index()
        {
            var apps = eDAO.GetAllApplications();
            return View(apps);
        }

        public ActionResult Details(int id)
        {
            var applicationDetails = eDAO.GetApplicationDetails(id);
            return View(applicationDetails);
        }

        public ActionResult Create()
        {
            var specialities = new SelectList(specialityDAO.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Application app)
        {
            try
            {
                eDAO.CreateApplication(app);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var specialities = new SelectList(specialityDAO.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            var app = eDAO.GetApplicationById(id);
            return View(app);
        }

        [HttpPost]
        public ActionResult Edit(Application app)
        {
            try
            {
                eDAO.EditApplication(app);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var app = eDAO.GetApplicationById(id);
            return View(app);
        }

        [HttpPost]
        public ActionResult Delete(Application app)
        {
            try
            {
                eDAO.RemoveApplication(app);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

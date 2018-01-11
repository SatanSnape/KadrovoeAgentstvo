using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    [Authorize]
    public class EmployerController : Controller
    {

        EmployerDAO eDAO = new EmployerDAO();
        SpecialityDAO specialityDAO = new SpecialityDAO();
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

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

        [Authorize(Roles = "Employer")]
        public ActionResult Create()
        {
            var specialities = new SelectList(specialityDAO.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
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

        [Authorize(Roles = "Employer")]
        public ActionResult Edit(int id)
        {
            var specialities = new SelectList(specialityDAO.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            var app = eDAO.GetApplicationById(id);
            return View(app);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
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

        [Authorize(Roles = "Administration, Employer, Moderator")]
        public ActionResult Delete(int id)
        {
            var app = eDAO.GetApplicationById(id);
            return View(app);
        }

        [HttpPost]
        [Authorize(Roles = "Administration, Employer, Moderator")]
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

        [Authorize(Roles = "Aspirant")]
        public ActionResult LeaveApplication(int applicationId)
        {
            try
            {
                eDAO.LeaveApplication(applicationId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Administration, Employer, Moderator")]
        public ActionResult ShowIntUsers(int applicationId)
        {
            try
            {
                var spec = _db.Applications.FirstOrDefault(x => x.ApplicationId == applicationId).Speciality;
                var company = _db.Applications.FirstOrDefault(x => x.ApplicationId == applicationId).Company;
                ViewBag.Appl = $"{company.Name} {spec.Name}";
                var interestedUsers = eDAO.ShowIntUsers(applicationId);
                return View("InterestedUsers", interestedUsers);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}

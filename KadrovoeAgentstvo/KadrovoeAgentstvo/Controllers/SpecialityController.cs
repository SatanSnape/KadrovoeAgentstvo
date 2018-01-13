using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    [Authorize(Roles = "Administration")]
    public class SpecialityController : Controller
    {

        SpecialityDAO specDAO = new SpecialityDAO();

        [Authorize(Roles = "Administration")]
        public ActionResult Index()
        {
            var specialities = specDAO.GetAllSpecilities();
            return View(specialities);
        }

        [Authorize(Roles = "Administration")]
        public ActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Administration")]
        [HttpPost]
        public ActionResult Create(Speciality spec)
        {
            try
            {
                specDAO.CreateSpeciality(spec);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administration")]
        public ActionResult Edit(int id)
        {
            var speciality = specDAO.GetSpecialityById(id);
            return View(speciality);
        }

        [Authorize(Roles = "Administration")]
        [HttpPost]
        public ActionResult Edit(Speciality spec)
        {
            try
            {
                specDAO.EditSpeciality(spec);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administration")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var spec = specDAO.GetSpecialityById(id);
            return View(spec);
        }

        [Authorize(Roles = "Administration,Moderator")]
        [HttpPost]
        public ActionResult Delete(Speciality spec)
        {
            try
            {
                specDAO.RemoveSpeciality(spec);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

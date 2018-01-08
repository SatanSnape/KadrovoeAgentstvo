using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    public class SpecialityController : Controller
    {

        SpecialityDAO specDAO = new SpecialityDAO();

        public ActionResult Index()
        {
            var specialities = specDAO.GetAllSpecilities();
            return View(specialities);
        }

        public ActionResult Create()
        {
            return View();
        }


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

        public ActionResult Edit(int id)
        {
            var speciality = specDAO.GetSpecialityById(id);
            return View(speciality);
        }

        // POST: Speciality/Edit/5
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var spec = specDAO.GetSpecialityById(id);
            return View(spec);
        }
        
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

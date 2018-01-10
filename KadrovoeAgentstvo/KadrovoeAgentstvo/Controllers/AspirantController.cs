using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    public class AspirantController : Controller
    {
        AspirantDAO dao = new AspirantDAO();

        public ActionResult Index()
        {
            var list = dao.GetProfilesByPersonId();
            return View(list);
        }
        
        [HttpPost]
        public ActionResult CreateProfile(Profile profile)
        {
            dao.CreateProfile(profile);
            return View();
        }

        public ActionResult CreateProfile()
        {
            var specialities = new SelectList(dao.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            return RedirectToAction("Index");
        }
    }
}

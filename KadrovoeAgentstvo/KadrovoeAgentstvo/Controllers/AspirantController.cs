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
    [Authorize]
    public class AspirantController : Controller
    {
        AspirantDAO _aDao = new AspirantDAO();
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        [Authorize]
        [Authorize(Roles = "Aspirant")]
        public ActionResult Index()
        {
            var list = _aDao.GetProfilesByPersonId();
            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "Aspirant")]
        public ActionResult CreatePerson()
        {
            var specialities = new SelectList(_aDao.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Aspirant")]
        public ActionResult CreatePerson(Person person)
        {
            try
            {
                var pEntity = _aDao.CreatePerson(person);
                ViewBag.PersonId = pEntity.PersonId;
                return RedirectToAction("CreateProfile");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Aspirant")]
        public ActionResult CreateProfile()
        {
            var specialities = new SelectList(_aDao.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Aspirant")]
        public ActionResult CreateProfile(Profile profile)
        {
            try
            {
                _aDao.CreateProfile(profile);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Aspirant,Administration,Moderator")]
        public ActionResult Details(int profileId)
        {
            var profile = _aDao.GetProfileDetails(profileId);
            return View(profile);
        }

        [HttpGet]
        [Authorize(Roles = "Aspirant")]
        public ActionResult EditProfileData(int id)
        {
            var specialities = new SelectList(_aDao.GetAllSpecilities(), "SpecialityId", "Name");
            ViewBag.Specialities = specialities;
            var profile = _aDao.GetProfileById(id);
            var person = _db.People.FirstOrDefault(x => x.PersonId == profile.PersonId);
            ViewBag.Person = $"{person.Name} {person.Surname}";
            profile.People.Add(person);
            return View(profile);
        }

        [Authorize(Roles = "Aspirant")]
        public ActionResult EditProfileData(Profile profile)
        {
            try
            {
                _aDao.EditProfile(profile);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }            
        }

        [Authorize(Roles = "Aspirant,Administration,Moderator")]
        public ActionResult DeleteProfile(int id)
        {
            var profile = _aDao.GetProfileDetails(id);
            return View(profile);
        }

        [Authorize(Roles = "Aspirant,Administration,Moderator")]
        public ActionResult Remove(int id)
        {
            _aDao.RemoveProfile(id);
            return RedirectToAction("Index");
        }

    }
}

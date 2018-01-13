using KadrovoeAgentstvo.DAO;
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    [Authorize(Roles = "Administration, Moderator")]
    public class PersonController : Controller
    {

        PersonDAO dao = new PersonDAO();

        [Authorize(Roles = "Administration, Moderator")]
        public ActionResult Index()
        {
            var people = dao.GetPeople();
            return View(people);
        }

        [HttpGet]
        [Authorize(Roles = "Administration, Moderator")]
        public ActionResult Edit(int id)
        {
            var person = dao.GetPeople().FirstOrDefault(x => x.PersonId == id);
            return View(person);
        }

        [Authorize(Roles = "Administration, Moderator")]
        public ActionResult Edit(Person person)
        {
            try
            {
                dao.EditPerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administration, Moderator")]
        public ActionResult DeletePersonView(int id)
        {
            var person = dao.GetPeople().FirstOrDefault(x => x.PersonId == id);
            return View("Delete", person);
        }

        [Authorize(Roles = "Administration, Moderator")]
        //[HttpPost]
        public ActionResult DeletePerson(int personId)
        {
            try
            {
                dao.RemovePerson(personId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}
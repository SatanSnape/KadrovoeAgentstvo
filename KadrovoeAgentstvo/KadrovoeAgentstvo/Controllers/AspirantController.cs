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

        public ActionResult Index(Person person)
        {
            dao.CreatePerson(person);
            return View();
        }

        public ActionResult CreateProfile(int jobId, int personId)
        {
            dao.CreateProfile(jobId, personId);
            return View();
        }
    }
}

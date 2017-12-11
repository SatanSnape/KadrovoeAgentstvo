using KadrovoeAgentstvo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KadrovoeAgentstvo.Controllers
{
    public class PersonController : Controller
    {

        PersonDAO dao = new PersonDAO();

        public ActionResult Index()
        {
            var people = dao.GetPeople();
            return View(people);
        }
    }
}
using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KadrovoeAgentstvo.DAO
{
    public class PersonDAO
    {

        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<PersonViewModel> GetPeople()
        {
            var people = _db.People.Select(person => new PersonViewModel
            {
                PersonId = person.PersonId,
                Name = person.Name,
                Surname = person.Surname,
                Pathronymic = person.Pathronymic,
                BirthDate = person.DateBirth,
                Passport = person.Passport,              
            }).ToList();
            return people;
        }

    }
}
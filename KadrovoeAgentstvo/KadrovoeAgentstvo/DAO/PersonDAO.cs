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

        public List<Person> GetPeople()
        {
            var people = _db.People.ToList();
            return people;
        }

        public void EditPerson(Person person)
        {
            var personE = _db.People.FirstOrDefault(x => x.PersonId == person.PersonId);
            personE.Name = person.Name;
            personE.Surname = person.Surname;
            personE.Pathronymic = person.Pathronymic;
            personE.DateBirth = person.DateBirth;
            personE.Passport = person.Passport;
            _db.SaveChanges();
        }

        public void RemovePerson(int id)
        {
            var person = _db.People.FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                throw new Exception("Не удалось найти пользователя");
            _db.People.Remove(person);
            _db.SaveChanges();
        }

    }
}
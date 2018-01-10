using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KadrovoeAgentstvo.Models;
namespace KadrovoeAgentstvo.DAO
{
    public class AspirantDAO
    {
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<Profile> GetProfilesByPersonId()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            var person = _db.People.FirstOrDefault(x => x.UserId == user.Id);
            if (person == null)
                return new List<Profile>();
            var profiles = _db.People.FirstOrDefault(x => x.PersonId == person.PersonId).Profile;
            return null;

        }

        public void CreatePerson(Person person)
        {
            _db.People.Add(new Person
            {
                Application = person.Application,
                Company = person.Company,
                DateBirth = person.DateBirth,
                Name = person.Name,
                Passport = person.Passport,
                Pathronymic = person.Pathronymic,
                Profile = person.Profile,
                Speciality = person.Speciality,
                Surname = person.Surname
            });
        }

        public void CreateProfile(int jobDirectoryId, int personId)
        {
            var person = _db.People.First(x => x.PersonId == personId);
            var jobDirectory = _db.JobDirectories.First(x => x.JobDirectoryId == jobDirectoryId);
            _db.Profiles.Add(new Profile
            {
                Date = DateTime.Now,
                //People = person,
                //JobDirectory = jobDirectory,
                //JobDirectoryId = jobDirectory.JobDirectoryId,
                //ProfileId = person.ProfileId,
                State = "Заявление создано"
            });
        }
    }
}
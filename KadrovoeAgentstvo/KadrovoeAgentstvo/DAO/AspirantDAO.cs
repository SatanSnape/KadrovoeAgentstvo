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

        public List<Speciality> GetAllSpecilities() => _db.Specialities.ToList();

        public List<Profile> GetProfilesByPersonId()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            var person = _db.People.FirstOrDefault(x => x.UserId == user.Id);
            if (person == null)
                return new List<Profile>();
            var profiles = _db.Profiles.Where(x => x.PersonId == person.PersonId).ToList();
            return profiles;

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

        public void CreateProfile(Profile profile)
        {
            var jobDirectory = _db.JobDirectories.First(x => x.Profiles.Contains(profile));
            _db.Profiles.Add(new Profile
            {
                Date = DateTime.Now,
                People = profile.People,
                JobDirectory = jobDirectory,
                JobDirectoryId = jobDirectory.JobDirectoryId,
                ProfileId = profile.ProfileId,
                State = "Заявление создано"
            });
            _db.SaveChanges();
        }
    }
}
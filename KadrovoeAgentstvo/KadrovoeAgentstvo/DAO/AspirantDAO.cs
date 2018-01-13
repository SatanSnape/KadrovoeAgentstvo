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

        public List<Profs> GetProfilesByPersonId()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            var persons = _db.People.Where(x => x.UserId == user.Id);
            if (persons == null || !persons.Any())
                return new List<Profs>();
            var profiles = _db.Profiles.Where(x => persons.Any(y => y.PersonId == x.PersonId))
                .Select(x => new Profs
                {
                    ProfileId = x.ProfileId,
                    Name = _db.People.FirstOrDefault(y => y.PersonId == x.PersonId).Name,
                    Surname = _db.People.FirstOrDefault(y => y.PersonId == x.PersonId).Surname,
                    CreatedDate = x.Date,
                    Speciality = x.Speciality.Name,
                    State = x.State
                }).ToList();
            return profiles;
        }

        public Person CreatePerson(Person person)
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            if (user == null)
                throw new Exception("Пользователь не найден");
            var personE = _db.People.FirstOrDefault(x => x.UserId == user.Id);
            var personEntity = new Person();
            //if (personE != null)
            //{
            //    personE.DateBirth = person.DateBirth;
            //    personE.Name = person.Name;
            //    personE.Surname = person.Surname;
            //    person.
            //    personEntity = personE;
            //}
            //else
            //{
            personEntity = new Person
            {
                DateBirth = person.DateBirth,
                Name = person.Name,
                Passport = person.Passport,
                Pathronymic = person.Pathronymic,
                SpecialityId = person.SpecialityId,
                Surname = person.Surname,
                UserId = user.Id
            };
            _db.People.Add(personEntity);
            //}
            _db.SaveChanges();
            return personEntity;
        }

        public void CreateInitPerson(string id)
        {
            Person person = new Person
            {
                UserId = id
            };
            _db.People.Add(person);
            _db.SaveChanges();
        }

        public void CreateProfile(Profile profile)
        {
            var jobD = new JobDirectory
            {
                Date = DateTime.UtcNow,
                Description = profile.JobDirectory.Description,
                MinSalary = profile.JobDirectory.MinSalary,
                MaxSalary = profile.JobDirectory.MaxSalary,
                State = "Создано"
            };
            _db.JobDirectories.Add(jobD);
            _db.SaveChanges();
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            if (user == null)
                throw new Exception("Пользователь не найден");
            var profileEntity = new Profile
            {
                Date = DateTime.Now,
                PersonId = user.People.FirstOrDefault(x => x.UserId == user.Id).PersonId,
                State = "Заявление создано",
                SpecialityId = profile.SpecialityId,
                JobDirectoryId = jobD.JobDirectoryId
            };
            _db.Profiles.Add(profileEntity);
            _db.SaveChanges();
        }

        public Profile GetProfileDetails(int profileId)
        {
            var profile = _db.Profiles.FirstOrDefault(x => x.ProfileId == profileId);
            var person = _db.People.FirstOrDefault(x => x.PersonId == profile.PersonId);
            profile.People.Add(person);
            return profile;
        }

        public void EditProfile(Profile profile)
        {
            if (profile == null)
                throw new Exception("Резюме не найдено");
            var profileEntity = _db.Profiles.FirstOrDefault(x => x.ProfileId == profile.ProfileId);
            profileEntity.SpecialityId = profile.SpecialityId;
            profileEntity.JobDirectory.MinSalary = profile.JobDirectory.MinSalary;
            profileEntity.JobDirectory.MaxSalary = profile.JobDirectory.MaxSalary;
            profileEntity.JobDirectory.Description = profile.JobDirectory.Description;
            profileEntity.Date = DateTime.UtcNow;
            _db.SaveChanges();
        }

        public Profile GetProfileById(int id)
        {
            var profile = _db.Profiles.FirstOrDefault(x => x.ProfileId == id);
            return profile;
        }

        public void RemoveProfile(int id)
        {
            var profile = _db.Profiles.FirstOrDefault(x => x.ProfileId == id);
            var person = _db.People.FirstOrDefault(x => x.PersonId == profile.PersonId);
            _db.People.Remove(person);
            _db.Profiles.Remove(profile);
            _db.SaveChanges();
        }

    }
}
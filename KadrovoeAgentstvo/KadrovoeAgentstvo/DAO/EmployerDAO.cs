using KadrovoeAgentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KadrovoeAgentstvo.DAO
{
    public class EmployerDAO
    {
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<Application> GetAllApplications() =>
            _db.Applications.ToList();

        public Application GetApplicationById(int id) =>
            _db.Applications.FirstOrDefault(x => x.ApplicationId == id);

        public Application GetApplicationDetails(int id) =>
            _db.Applications.FirstOrDefault(x => x.ApplicationId == id);

        public void CreateApplication(Application app)
        {
            JobDirectory jobDirectory = new JobDirectory
            {
                Date = DateTime.UtcNow,
                MaxSalary = app.JobDirectory.MaxSalary,
                MinSalary = app.JobDirectory.MinSalary,
                State = "Заявление создано",
                Description = app.JobDirectory.Description
            };
            _db.JobDirectories.Add(jobDirectory);
            _db.SaveChanges();           
            Application appEntity = new Application
            {
                Date = DateTime.UtcNow,
                JobDirectoryId = jobDirectory.JobDirectoryId,
                SpecialityId = app.SpecialityId,
                Duties = app.Duties,
                Requirements = app.Requirements,
                State = "Заявление создано"
            };
            _db.Applications.Add(appEntity);
            _db.SaveChanges();
        }

        public void EditApplication(Application app)
        {
            var appEntity = _db.Applications.FirstOrDefault(x => x.ApplicationId == app.ApplicationId);
            if (appEntity == null)
                throw new Exception("Запрашиваемое заявление не найдено");
            appEntity.SpecialityId = app.SpecialityId;
            appEntity.Duties = app.Duties;
            appEntity.Requirements = app.Requirements;
            appEntity.JobDirectory.Description = app.JobDirectory.Description;
            appEntity.JobDirectory.MaxSalary = app.JobDirectory.MaxSalary;
            appEntity.JobDirectory.MinSalary = app.JobDirectory.MinSalary;
            _db.SaveChanges();
        }

        public void RemoveApplication(Application app)
        {
            var job = _db.JobDirectories.FirstOrDefault(x => x.JobDirectoryId == app.JobDirectoryId);
            if (job == null)
                throw new Exception("Запрашиваемые подробности заявления не найдены");
            var appEntity = _db.Applications.FirstOrDefault(x => x.ApplicationId == app.ApplicationId);
            if (appEntity == null)
                throw new Exception("Запрашиваемое заявление не найдено");
            _db.JobDirectories.Remove(job);
            _db.Applications.Remove(appEntity);
            _db.SaveChanges();
        }

    }
}
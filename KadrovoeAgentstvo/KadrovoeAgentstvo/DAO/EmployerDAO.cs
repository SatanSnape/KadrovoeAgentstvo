using KadrovoeAgentstvo.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KadrovoeAgentstvo.DAO
{
    public class EmployerDAO
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<Application> GetAllApplications() =>
            _db.Applications.ToList();

        public Application GetApplicationById(int id) =>
            _db.Applications.FirstOrDefault(x => x.ApplicationId == id);

        public Application GetApplicationDetails(int id) =>
            _db.Applications.FirstOrDefault(x => x.ApplicationId == id);

        public void CreateApplication(Application app)
        {
            logger.Debug("Создание Job Directory");
            JobDirectory jobDirectory = new JobDirectory
            {
                Date = DateTime.UtcNow,
                MaxSalary = app.JobDirectory.MaxSalary,
                MinSalary = app.JobDirectory.MinSalary,
                State = "Заявление создано",
                Description = app.JobDirectory.Description
            };
            logger.Debug("Сохранение Job Directory");
            _db.JobDirectories.Add(jobDirectory);
            _db.SaveChanges();
            logger.Debug("Создание заявления");
            Application appEntity = new Application
            {
                Date = DateTime.UtcNow,
                JobDirectoryId = jobDirectory.JobDirectoryId,
                SpecialityId = app.SpecialityId,
                Duties = app.Duties,
                Requirements = app.Requirements,
                State = "Заявление создано"
            };
            logger.Debug("Создание заявления");
            _db.Applications.Add(appEntity);
            _db.SaveChanges();
        }

        public void EditApplication(Application app)
        {
            logger.Debug("Поиск заявления для редактирования");
            var appEntity = _db.Applications.FirstOrDefault(x => x.ApplicationId == app.ApplicationId);
            if (appEntity == null)
            {
                logger.Error("Запрашиваемое заявление не найдено");
                throw new Exception("Запрашиваемое заявление не найдено");
            }
            logger.Debug("Редактирование заявления");
            appEntity.SpecialityId = app.SpecialityId;
            appEntity.Duties = app.Duties;
            appEntity.Requirements = app.Requirements;
            appEntity.JobDirectory.Description = app.JobDirectory.Description;
            appEntity.JobDirectory.MaxSalary = app.JobDirectory.MaxSalary;
            appEntity.JobDirectory.MinSalary = app.JobDirectory.MinSalary;
            logger.Debug("Применение изменений для заявления");
            _db.SaveChanges();
        }

        public void RemoveApplication(Application app)
        {
            logger.Debug("Начало удаления заявления");
            var job = _db.JobDirectories.FirstOrDefault(x => x.JobDirectoryId == app.JobDirectoryId);
            if (job == null)
            {
                logger.Error("Запрашиваемые подробности заявления не найдены");
                throw new Exception("Запрашиваемые подробности заявления не найдены");
            }   
            var appEntity = _db.Applications.FirstOrDefault(x => x.ApplicationId == app.ApplicationId);
            if (appEntity == null)
            {
                logger.Error("Запрашиваемое заявление не найдено");
                throw new Exception("Запрашиваемое заявление не найдено");
            }
            logger.Debug("Запрашиваемое заявление успешно было удалено");
            _db.JobDirectories.Remove(job);
            _db.Applications.Remove(appEntity);
            _db.SaveChanges();
        }

        public void LeaveApplication(int appId)
        {
            logger.Debug("Оставление заявки на пользователя на заявление работодателя");
            var currentUser = HttpContext.Current.User.Identity.Name;
            var user = _db.AspNetUsers.FirstOrDefault(x => x.UserName == currentUser);
            var person = _db.People.FirstOrDefault(x => x.UserId == user.Id);
            Request request = new Request
            {
                ApplicationId = appId,
                PersonId = person.PersonId
            };
            _db.Requests.Add(request);
            _db.SaveChanges();
        }

    }
}
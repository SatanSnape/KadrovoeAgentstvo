using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KadrovoeAgentstvo.Models;
using NLog;

namespace KadrovoeAgentstvo.DAO
{
    public class SpecialityDAO
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<Speciality> GetAllSpecilities() => _db.Specialities.ToList();

        public void CreateSpeciality(Speciality spec)
        {
            logger.Debug("Создание новой вакансии");
            var speciality = new Speciality
            {
                Name = spec.Name
            };
            logger.Debug("Сохранение новой вакансии");
            _db.Specialities.Add(spec);
            _db.SaveChanges();
        }

        public void EditSpeciality(Speciality spec)
        {
            logger.Debug("Редактирование вакансии");
            var specEntity = _db.Specialities.FirstOrDefault(x => x.SpecialityId == spec.SpecialityId);
            if (specEntity == null)
            {
                logger.Error("Вакансия для редактирования не найдена");
                throw new Exception("Вакансия для редактирования не найдена");
            }
            specEntity.Name = spec.Name;
            _db.SaveChanges();
        }

        public Speciality GetSpecialityById(int id) => GetAllSpecilities().FirstOrDefault(x => x.SpecialityId == id);

        public void RemoveSpeciality(Speciality spec)
        {
            var specEntity = _db.Specialities.FirstOrDefault(x => x.SpecialityId == spec.SpecialityId);
            if (specEntity == null)
            {
                logger.Error("Вакансия для удаления не найдена");
                throw new Exception("Вакансия для удаления не найдена");
            }
            _db.Specialities.Remove(specEntity);
            _db.SaveChanges();
        }

    }
}
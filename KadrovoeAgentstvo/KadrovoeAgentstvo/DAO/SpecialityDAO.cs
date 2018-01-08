using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KadrovoeAgentstvo.Models;

namespace KadrovoeAgentstvo.DAO
{
    public class SpecialityDAO
    {

        private KadrovoeAgentstvoEntities _db = new KadrovoeAgentstvoEntities();

        public List<Speciality> GetAllSpecilities() => _db.Specialities.ToList();

        public void CreateSpeciality(Speciality spec)
        {
            var speciality = new Speciality
            {
                Name = spec.Name
            };
            _db.Specialities.Add(spec);
            _db.SaveChanges();
        }

        public void EditSpeciality(Speciality spec)
        {
            var specEntity = _db.Specialities.FirstOrDefault(x => x.SpecialityId == spec.SpecialityId);
            specEntity.Name = spec.Name;
            _db.SaveChanges();
        }

        public Speciality GetSpecialityById(int id) => GetAllSpecilities().FirstOrDefault(x => x.SpecialityId == id);

        public void RemoveSpeciality(Speciality spec)
        {
            var entity = _db.Specialities.FirstOrDefault(x => x.SpecialityId == spec.SpecialityId);
            if (entity != null)
                _db.Specialities.Remove(entity);
            _db.SaveChanges();
        }

    }
}
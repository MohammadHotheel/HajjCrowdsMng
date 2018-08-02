using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class CityRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public CityRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.City> All()
        {
            return _context.Cities.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.City Find(int id)
        {
            return _context.Cities.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.City> AllByStateId(int id)
        {
            return _context.Cities.Where(w => w.DeletedFlag == false && w.StateId == id).ToList();
        }

        public void Insert(Entity.City City)
        {
            _context.Entry(City).State = EntityState.Added;
        }
        public void Update(Entity.City City)
        {
            _context.Entry(City).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.Cities.Find(id);
            _context.Cities.Remove(obj);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public bool CheckCanDeleted(int id)
        {
            int i = 0;
            i = _context.SaudiStudentAssociations.Where(w => w.CityId == id).Count();
            return (i == 0);
        }
    }
}

using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class UniversityRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public UniversityRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.University> All()
        {
            return _context.Universities.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.University Find(int id)
        {
            return _context.Universities.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }

        public void Insert(Entity.University University)
        {
            _context.Entry(University).State = EntityState.Added;
        }
        public void Update(Entity.University University)
        {
            _context.Entry(University).State = EntityState.Modified;
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
            i = _context.SaudiStudentAssociations.Where(w => w.UniversityId == id).Count();
            i += _context.AspNetUsers.Where(w => w.UniversityId == id).Count();
            return (i == 0);
        }
    }
}
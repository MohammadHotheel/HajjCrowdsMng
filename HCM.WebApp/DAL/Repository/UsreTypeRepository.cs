
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class UserTypeRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public UserTypeRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.UserType> All()
        {
            return _context.UserTypes.ToList();
        }
        public Entity.UserType Find(int id)
        {
            return _context.UserTypes.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Insert(Entity.UserType UserType)
        {
            _context.Entry(UserType).State = EntityState.Added;
        }
        public void Update(Entity.UserType UserType)
        {
            _context.Entry(UserType).State = EntityState.Modified;
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
    }
}
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class UserRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public UserRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.AspNetUser> All()
        {
            return _context.AspNetUsers.ToList();
        }
        public Entity.AspNetUser Find(string id)
        {
            return _context.AspNetUsers.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Insert(Entity.AspNetUser AspNetUser)
        {
            _context.Entry(AspNetUser).State = EntityState.Added;
        }
        public void Update(Entity.AspNetUser AspNetUser)
        {
            _context.Entry(AspNetUser).State = EntityState.Modified;
        }
        public void Delete(string id)
        {
            var obj = _context.AspNetUsers.Find(id);
            _context.AspNetUsers.Remove(obj);
        }

        public List<UserType> AllUserType()
        {
            return _context.UserTypes.ToList();
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
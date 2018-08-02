using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class NotificationLevelRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public NotificationLevelRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.NotificationLevel> All()
        {
            return _context.NotificationLevels.ToList();
        }
        public Entity.NotificationLevel Find(int id)
        {
            return _context.NotificationLevels.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Insert(Entity.NotificationLevel NotificationLevel)
        {
            _context.Entry(NotificationLevel).State = EntityState.Added;
        }
        public void Update(Entity.NotificationLevel NotificationLevel)
        {
            _context.Entry(NotificationLevel).State = EntityState.Modified;
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
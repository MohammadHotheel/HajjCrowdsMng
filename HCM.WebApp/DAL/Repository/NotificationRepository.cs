using HCM.WebApp.DAL.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HCM.WebApp.DAL.Repository
{
    public class NotificationRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public NotificationRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.Notification> All()
        {
            return _context.Notifications.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.Notification Find(int id)
        {
            return _context.Notifications.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.Notification> AllByUserTypeId(int id)
        {
            return _context.Notifications.Where(w => w.DeletedFlag == false && w.UserTypeId == id).ToList();
        }

        public void Insert(Entity.Notification Notification)
        {
            _context.Entry(Notification).State = EntityState.Added;
        }
        public void Update(Entity.Notification Notification)
        {
            _context.Entry(Notification).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.Notifications.Find(id);
            _context.Notifications.Remove(obj);
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
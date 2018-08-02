using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class MessageRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public MessageRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.Message> All()
        {
            return _context.Messages.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.Message Find(int id)
        {
            return _context.Messages.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.Message> AllByMessageTypeId(int id)
        {
            return _context.Messages.Where(w => w.DeletedFlag == false && w.MessageTypeId == id).ToList();
        }

        public void Insert(Entity.Message Message)
        {
            _context.Entry(Message).State = EntityState.Added;
        }
        public void Update(Entity.Message Message)
        {
            _context.Entry(Message).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.Messages.Find(id);
            _context.Messages.Remove(obj);
        }

        public List<MessageType> AllMessageType()
        {
            return _context.MessageTypes.ToList();
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
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class FAQRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public FAQRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.FAQ> All()
        {
            return _context.FAQs.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.FAQ Find(int id)
        {
            return _context.FAQs.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.FAQ> AllBySSAId(int id)
        {
            return _context.FAQs.Where(w => w.DeletedFlag == false && w.SaudiStudentAssociationId == id).ToList();
        }

        public void Insert(Entity.FAQ FAQ)
        {
            _context.Entry(FAQ).State = EntityState.Added;
        }
        public void Update(Entity.FAQ FAQ)
        {
            _context.Entry(FAQ).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.FAQs.Find(id);
            _context.FAQs.Remove(obj);
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
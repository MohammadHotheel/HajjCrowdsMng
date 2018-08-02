
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class ServiceCategoryRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public ServiceCategoryRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.ServiceCategory> All()
        {
            return _context.ServiceCategories.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.ServiceCategory Find(int id)
        {
            return _context.ServiceCategories.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }

        public void Insert(Entity.ServiceCategory ServiceCategory)
        {
            _context.Entry(ServiceCategory).State = EntityState.Added;
        }
        public void Update(Entity.ServiceCategory ServiceCategory)
        {
            _context.Entry(ServiceCategory).State = EntityState.Modified;
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
            i = _context.ServiceInformations.Where(w => w.ServiceCategoryId == id).Count();
            return (i == 0);
        }
    }
}
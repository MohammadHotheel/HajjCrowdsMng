using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class ServiceDetailsRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public ServiceDetailsRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.ServiceDetail> All()
        {
            return _context.ServiceDetails.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.ServiceDetail Find(int id)
        {
            return _context.ServiceDetails.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.ServiceDetail> AllByServiceInfoId(int id)
        {
            return _context.ServiceDetails.Where(w => w.DeletedFlag == false && w.ServiceInformationId == id).ToList();
        }

        public void Insert(Entity.ServiceDetail ServiceDetails)
        {
            _context.Entry(ServiceDetails).State = EntityState.Added;
        }
        public void Update(Entity.ServiceDetail ServiceDetails)
        {
            _context.Entry(ServiceDetails).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.ServiceDetails.Find(id);
            _context.ServiceDetails.Remove(obj);
        }

        public List<InfoType> AllInfoType()
        {
            return _context.InfoTypes.ToList();
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
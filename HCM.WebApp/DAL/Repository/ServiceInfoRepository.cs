using HCM.WebApp.DAL.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HCM.WebApp.DAL.Repository
{
    public class ServiceInfoRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public ServiceInfoRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.ServiceInformation> All()
        {
            return _context.ServiceInformations.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.ServiceInformation Find(int id)
        {
            return _context.ServiceInformations.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public List<Entity.ServiceInformation> AllBySSAId(int id)
        {
            return _context.ServiceInformations.Where(w => w.DeletedFlag == false && w.SaudiStudentAssociationId == id).ToList();
        }

        public void Insert(Entity.ServiceInformation ServiceInformation)
        {
            _context.Entry(ServiceInformation).State = EntityState.Added;
        }
        public void Update(Entity.ServiceInformation ServiceInformation)
        {
            _context.Entry(ServiceInformation).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.ServiceInformations.Find(id);
            _context.ServiceInformations.Remove(obj);
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
            i = _context.ServiceDetails.Where(w => w.ServiceInformationId == id).Count();
            return (i == 0);
        }
    }
}
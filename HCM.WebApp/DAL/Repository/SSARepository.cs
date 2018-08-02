using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class SSARepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public SSARepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public List<Entity.SaudiStudentAssociation> All()
        {
            return _context.SaudiStudentAssociations.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.SaudiStudentAssociation Find(int id)
        {
            return _context.SaudiStudentAssociations.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        //public Entity.SaudiStudentAssociation FindByAdministratorId(string id)
        //{
        //    return _context.SaudiStudentAssociations.Where(w => w.AdministratorId == id && w.DeletedFlag == false).SingleOrDefault();
        //}
        public Entity.SaudiStudentAssociation FindByUniversityId(int id)
        {
            return _context.SaudiStudentAssociations.Where(w => w.UniversityId == id && w.DeletedFlag == false).SingleOrDefault();
        }

        public void Insert(Entity.SaudiStudentAssociation SaudiStudentAssociation)
        {
            _context.Entry(SaudiStudentAssociation).State = EntityState.Added;
        }
        public void Update(Entity.SaudiStudentAssociation SaudiStudentAssociation)
        {
            _context.Entry(SaudiStudentAssociation).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var obj = _context.SaudiStudentAssociations.Find(id);
            _context.SaudiStudentAssociations.Remove(obj);
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
            i = _context.FAQs.Where(w => w.SaudiStudentAssociationId == id).Count();
            i += _context.ServiceInformations.Where(w => w.SaudiStudentAssociationId == id).Count();
            return (i == 0);
        }
    }
}
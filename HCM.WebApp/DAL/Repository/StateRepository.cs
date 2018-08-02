using HCM.WebApp.DAL.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HCM.WebApp.DAL.Repository
{
    public class StateRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public StateRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }
        public List<Entity.State> All()
        {
            return _context.States.Where(w => w.DeletedFlag == false).ToList();
        }
        public Entity.State Find(int id)
        {
            return _context.States.Where(w => w.Id == id && w.DeletedFlag == false).SingleOrDefault();
        }
        public void Insert(Entity.State State)
        {
            _context.Entry(State).State = EntityState.Added;
        }
        public void Update(Entity.State State)
        {
            _context.Entry(State).State = EntityState.Modified;
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
            i = _context.SaudiStudentAssociations.Where(w => w.StateId == id).Count();
            i += _context.Cities.Where(w => w.StateId == id).Count();
            return (i == 0);
        }
    }
}
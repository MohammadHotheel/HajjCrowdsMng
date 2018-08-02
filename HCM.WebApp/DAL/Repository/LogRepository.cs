using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCM.WebApp.DAL.Repository
{
    public class LogRepository
    {
        private readonly HajjCrawdsMngEntities _context;
        public LogRepository()
        {
            _context = new HajjCrawdsMngEntities();
        }

        public void Insert(Log Log)
        {
            _context.Entry(Log).State = EntityState.Added;
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
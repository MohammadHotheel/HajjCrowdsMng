using HCM.WebApp.DAL.Repository;
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HCM.WebApp.BLL.Base;

namespace HCM.WebApp.BLL.Manager
{
    public class UniversityManager
    {
        private readonly UniversityRepository _IUniversityRepository;
        public UniversityManager()
        {
            _IUniversityRepository = new UniversityRepository();
        }

        public DAL.Entity.University GetUniversity(int id)
        {
            try
            {
                return _IUniversityRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.University> GetAllUniversity()
        {
            try
            {
                return _IUniversityRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddUniversity(DAL.Entity.University University)
        {
            try
            {
                _IUniversityRepository.Insert(University);
                return _IUniversityRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateUniversity(DAL.Entity.University University)
        {
            try
            {
                _IUniversityRepository.Update(University);
                return _IUniversityRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteUniversity(int Id)
        {
            try
            {
                _IUniversityRepository.Delete(Id);
                return _IUniversityRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }

        public bool CheckCanDeleted(int Id)
        {
            try
            {
                return _IUniversityRepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
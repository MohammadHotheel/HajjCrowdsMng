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
    public class SSAManager
    {
        private readonly SSARepository _ISSARepository;
        public SSAManager()
        {
            _ISSARepository = new SSARepository();
        }

        public DAL.Entity.SaudiStudentAssociation GetSSA(int id)
        {
            try
            {
                return _ISSARepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.SaudiStudentAssociation> GetAllSSA()
        {
            try
            {
                return _ISSARepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public DAL.Entity.SaudiStudentAssociation GetSSAByUniversityId(int id)
        {
            try
            {
                return _ISSARepository.FindByUniversityId(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddSSA(DAL.Entity.SaudiStudentAssociation SSA)
        {
            try
            {
                _ISSARepository.Insert(SSA);
                return _ISSARepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateSSA(DAL.Entity.SaudiStudentAssociation SSA)
        {
            try
            {
                _ISSARepository.Update(SSA);
                return _ISSARepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteSSA(int Id)
        {
            try
            {
                _ISSARepository.Delete(Id);
                return _ISSARepository.Save();
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
                return _ISSARepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
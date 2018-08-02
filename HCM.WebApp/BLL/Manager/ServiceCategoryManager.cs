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
    public class ServiceCategoryManager
    {
        private readonly ServiceCategoryRepository _IServiceCategoryRepository;
        public ServiceCategoryManager()
        {
            _IServiceCategoryRepository = new ServiceCategoryRepository();
        }

        public DAL.Entity.ServiceCategory GetServiceCategory(int id)
        {
            try
            {
                return _IServiceCategoryRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.ServiceCategory> GetAllServiceCategory()
        {
            try
            {
                return _IServiceCategoryRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddServiceCategory(DAL.Entity.ServiceCategory ServiceCategory)
        {
            try
            {
                _IServiceCategoryRepository.Insert(ServiceCategory);
                return _IServiceCategoryRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateServiceCategory(DAL.Entity.ServiceCategory ServiceCategory)
        {
            try
            {
                _IServiceCategoryRepository.Update(ServiceCategory);
                return _IServiceCategoryRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteServiceCategory(int Id)
        {
            try
            {
                _IServiceCategoryRepository.Delete(Id);
                return _IServiceCategoryRepository.Save();
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
                return _IServiceCategoryRepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
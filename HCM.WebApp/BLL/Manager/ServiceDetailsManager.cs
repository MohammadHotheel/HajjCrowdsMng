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
    public class ServiceDetailsManager
    {
        private readonly ServiceDetailsRepository _IServiceDetailsRepository;
        public ServiceDetailsManager()
        {
            _IServiceDetailsRepository = new ServiceDetailsRepository();
        }

        public DAL.Entity.ServiceDetail GetServiceDetails(int id)
        {
            try
            {
                return _IServiceDetailsRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.ServiceDetail> GetAllServiceDetails()
        {
            try
            {
                return _IServiceDetailsRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.ServiceDetail> GetAllByServiceInfoId(int id)
        {
            try
            {
                return _IServiceDetailsRepository.AllByServiceInfoId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddServiceDetails(DAL.Entity.ServiceDetail ServiceDetails)
        {
            try
            {
                _IServiceDetailsRepository.Insert(ServiceDetails);
                return _IServiceDetailsRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateServiceDetails(DAL.Entity.ServiceDetail ServiceDetails)
        {
            try
            {
                _IServiceDetailsRepository.Update(ServiceDetails);
                return _IServiceDetailsRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteServiceDetails(int Id)
        {
            try
            {
                _IServiceDetailsRepository.Delete(Id);
                return _IServiceDetailsRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }

        public List<DAL.Entity.InfoType> GetAllInfoType()
        {
            try
            {
                return _IServiceDetailsRepository.AllInfoType();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
    }
}
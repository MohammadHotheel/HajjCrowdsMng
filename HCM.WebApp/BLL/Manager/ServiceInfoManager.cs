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
    public class ServiceInfoManager
    {
        private readonly ServiceInfoRepository _IServiceInfoRepository;
        public ServiceInfoManager()
        {
            _IServiceInfoRepository = new ServiceInfoRepository();
        }

        public DAL.Entity.ServiceInformation GetServiceInfo(int id)
        {
            try
            {
                return _IServiceInfoRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.ServiceInformation> GetAllServiceInfo()
        {
            try
            {
                return _IServiceInfoRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.ServiceInformation> GetAllBySSAId(int id)
        {
            try
            {
                return _IServiceInfoRepository.AllBySSAId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddServiceInfo(DAL.Entity.ServiceInformation ServiceInfo)
        {
            try
            {
                _IServiceInfoRepository.Insert(ServiceInfo);
                return _IServiceInfoRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateServiceInfo(DAL.Entity.ServiceInformation ServiceInfo)
        {
            try
            {
                _IServiceInfoRepository.Update(ServiceInfo);
                return _IServiceInfoRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteServiceInfo(int Id)
        {
            try
            {
                _IServiceInfoRepository.Delete(Id);
                return _IServiceInfoRepository.Save();
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
                return _IServiceInfoRepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
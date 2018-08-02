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
    public class FAQManager
    {
        private readonly FAQRepository _IFAQRepository;
        public FAQManager()
        {
            _IFAQRepository = new FAQRepository();
        }

        public DAL.Entity.FAQ GetFAQ(int id)
        {
            try
            {
                return _IFAQRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.FAQ> GetAllFAQ()
        {
            try
            {
                return _IFAQRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.FAQ> GetAllBySSAId(int id)
        {
            try
            {
                return _IFAQRepository.AllBySSAId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddFAQ(DAL.Entity.FAQ FAQ)
        {
            try
            {
                _IFAQRepository.Insert(FAQ);
                return _IFAQRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateFAQ(DAL.Entity.FAQ FAQ)
        {
            try
            {
                _IFAQRepository.Update(FAQ);
                return _IFAQRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteFAQ(int Id)
        {
            try
            {
                _IFAQRepository.Delete(Id);
                return _IFAQRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
    }
}
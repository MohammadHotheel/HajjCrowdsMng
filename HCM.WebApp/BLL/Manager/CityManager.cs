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
    public class CityManager
    {
        private readonly CityRepository _ICityRepository;
        public CityManager()
        {
            _ICityRepository = new CityRepository();
        }

        public DAL.Entity.City GetCity(int id)
        {
            try
            {
                return _ICityRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.City> GetAllCity()
        {
            try
            {
                return _ICityRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.City> GetAllByStateId(int id)
        {
            try
            {
                return _ICityRepository.AllByStateId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddCity(DAL.Entity.City City)
        {
            try
            {
                _ICityRepository.Insert(City);
                return _ICityRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateCity(DAL.Entity.City City)
        {
            try
            {
                _ICityRepository.Update(City);
                return _ICityRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteCity(int Id)
        {
            try
            {
                _ICityRepository.Delete(Id);
                return _ICityRepository.Save();
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
                return _ICityRepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
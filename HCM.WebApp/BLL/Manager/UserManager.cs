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
    public class UserManager
    {
        private readonly UserRepository _IUserRepository;
        public UserManager()
        {
            _IUserRepository = new UserRepository();
        }

        public DAL.Entity.AspNetUser GetAspNetUser(string id)
        {
            try
            {
                return _IUserRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.AspNetUser> GetAllAspNetUser()
        {
            try
            {
                return _IUserRepository.All().ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddAspNetUser(DAL.Entity.AspNetUser AspNetUser)
        {
            try
            {
                _IUserRepository.Insert(AspNetUser);
                return _IUserRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateAspNetUser(DAL.Entity.AspNetUser AspNetUser)
        {
            try
            {
                _IUserRepository.Update(AspNetUser);
                return _IUserRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteAspNetUser(string Id)
        {
            try
            {
                _IUserRepository.Delete(Id);
                return _IUserRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }

        public List<DAL.Entity.UserType> GetAllUserType()
        {
            try
            {
                return _IUserRepository.AllUserType();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
    }
}
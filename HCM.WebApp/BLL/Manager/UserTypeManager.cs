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
    public class UserTypeManager
    {
        private readonly UserTypeRepository _IUserTypeRepository;
        public UserTypeManager()
        {
            _IUserTypeRepository = new UserTypeRepository();
        }

        public DAL.Entity.UserType GetUserType(int id)
        {
            try
            {
                return _IUserTypeRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.UserType> GetAllUserType()
        {
            try
            {
                return _IUserTypeRepository.All().ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddUserType(DAL.Entity.UserType UserType)
        {
            try
            {
                _IUserTypeRepository.Insert(UserType);
                return _IUserTypeRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateUserType(DAL.Entity.UserType UserType)
        {
            try
            {
                _IUserTypeRepository.Update(UserType);
                return _IUserTypeRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteUserType(int Id)
        {
            try
            {
                _IUserTypeRepository.Delete(Id);
                return _IUserTypeRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
    }
}
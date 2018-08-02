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
    public class NotificationLevelManager
    {
        private readonly NotificationLevelRepository _INotificationLevelRepository;
        public NotificationLevelManager()
        {
            _INotificationLevelRepository = new NotificationLevelRepository();
        }

        public DAL.Entity.NotificationLevel GetNotificationLevel(int id)
        {
            try
            {
                return _INotificationLevelRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.NotificationLevel> GetAllNotificationLevel()
        {
            try
            {
                return _INotificationLevelRepository.All().ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddNotificationLevel(DAL.Entity.NotificationLevel NotificationLevel)
        {
            try
            {
                _INotificationLevelRepository.Insert(NotificationLevel);
                return _INotificationLevelRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateNotificationLevel(DAL.Entity.NotificationLevel NotificationLevel)
        {
            try
            {
                _INotificationLevelRepository.Update(NotificationLevel);
                return _INotificationLevelRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteNotificationLevel(int Id)
        {
            try
            {
                _INotificationLevelRepository.Delete(Id);
                return _INotificationLevelRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
    }
}
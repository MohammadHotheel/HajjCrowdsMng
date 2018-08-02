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
    public class NotificationManager
    {
        private readonly NotificationRepository _INotificationRepository;
        public NotificationManager()
        {
            _INotificationRepository = new NotificationRepository();
        }

        public DAL.Entity.Notification GetNotification(int id)
        {
            try
            {
                return _INotificationRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.Notification> GetAllNotification()
        {
            try
            {
                return _INotificationRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.Notification> GetAllBySSAId(int id)
        {
            try
            {
                return _INotificationRepository.AllByUserTypeId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddNotification(DAL.Entity.Notification Notification)
        {
            try
            {
                _INotificationRepository.Insert(Notification);
                return _INotificationRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateNotification(DAL.Entity.Notification Notification)
        {
            try
            {
                _INotificationRepository.Update(Notification);
                return _INotificationRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteNotification(int Id)
        {
            try
            {
                _INotificationRepository.Delete(Id);
                return _INotificationRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
    }
}
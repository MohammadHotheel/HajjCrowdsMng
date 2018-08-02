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
    public class MessageManager
    {
        private readonly MessageRepository _IMessageRepository;
        public MessageManager()
        {
            _IMessageRepository = new MessageRepository();
        }

        public DAL.Entity.Message GetMessage(int id)
        {
            try
            {
                return _IMessageRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.Message> GetAllMessage()
        {
            try
            {
                return _IMessageRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.Message> GetAllByMessageTypeId(int id)
        {
            try
            {
                return _IMessageRepository.AllByMessageTypeId(id).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddMessage(DAL.Entity.Message Message)
        {
            try
            {
                _IMessageRepository.Insert(Message);
                return _IMessageRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateMessage(DAL.Entity.Message Message)
        {
            try
            {
                _IMessageRepository.Update(Message);
                return _IMessageRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteMessage(int Id)
        {
            try
            {
                _IMessageRepository.Delete(Id);
                return _IMessageRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }

        public List<DAL.Entity.MessageType> GetAllMessageType()
        {
            try
            {
                return _IMessageRepository.AllMessageType();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
    }
}
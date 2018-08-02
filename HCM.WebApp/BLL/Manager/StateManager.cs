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
    public class StateManager
    {
        private readonly StateRepository _IStateRepository;
        public StateManager()
        {
            _IStateRepository = new StateRepository();
        }

        public DAL.Entity.State GetState(int id)
        {
            try
            {
                return _IStateRepository.Find(id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }
        public List<DAL.Entity.State> GetAllState()
        {
            try
            {
                return _IStateRepository.All().Where(w => w.DeletedFlag == false).ToList();
            }
            catch (Exception exception)
            {
                exception.Log();
                return null;
            }
        }

        public int AddState(DAL.Entity.State State)
        {
            try
            {
                _IStateRepository.Insert(State);
                return _IStateRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int UpdateState(DAL.Entity.State State)
        {
            try
            {
                _IStateRepository.Update(State);
                return _IStateRepository.Save();
            }
            catch (Exception exception)
            {
                exception.Log();
                return 0;
            }
        }
        public int DeleteState(int Id)
        {
            try
            {
                _IStateRepository.Delete(Id);
                return _IStateRepository.Save();
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
                return _IStateRepository.CheckCanDeleted(Id);
            }
            catch (Exception exception)
            {
                exception.Log();
                return false;
            }
        }
    }
}
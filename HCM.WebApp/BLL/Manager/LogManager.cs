using HCM.WebApp.BLL.Base;
using HCM.WebApp.DAL.Entity;
using HCM.WebApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCM.WebApp.BLL.Manager
{
    public class LogManager
    {
        private readonly LogRepository _ILogRepository;
        public LogManager()
        {
            _ILogRepository = new LogRepository();
        }

        public int AddLog(Log Log)
        {
            _ILogRepository.Insert(Log);
            return _ILogRepository.Save();
        }
    }

    public static class LogException
    {
        public static void Add(Exception exception)
        {
            var exceptionText =
                    string.Format(
                        "Message : {0}, \nStack Trace : {1}, \nInner Exception : {2}, \nInner Exception Stack trace : {3} ,\n Second Inner Exception {4} : ",
                        exception.Message, exception.StackTrace,
                        exception.InnerException?.Message ?? string.Empty,
                        exception.InnerException == null ? string.Empty : exception.InnerException.StackTrace, exception.InnerException?.InnerException != null ? exception.InnerException.Message : string.Empty);
            var hostName = System.Net.Dns.GetHostName();
            var source = exception.Source;

            var log = new Log()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CreatedBy = Common.CurrentUserName,
                Message = exceptionText,
                Host = hostName,
                Origin = source
            };

            LogManager _LogManager = new LogManager();
            int i = _LogManager.AddLog(log);
        }
    }
}
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCM.WebApp.BLL.Base
{
    public static class Common
    {
        public static void Log(this Exception exception)
        {
            LogException.Add(exception);
        }
        public static string CurrentUserName
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        var isActiveDirectoryUser = HttpContext.Current.User.Identity.Name.StartsWith("0#.w|");
                        if (!isActiveDirectoryUser)
                        {
                            return HttpContext.Current.User.Identity.Name;
                        }
                        else
                        {
                            return HttpContext.Current.User.Identity.Name.Split('|').Last().Split('\\').Last();
                        }
                    }
                    else
                    {
                        return "anonymous";
                    }
                }
                else
                {
                    return "anonymous";
                }
            }
        }

        public enum msgType
        {
            alertMessageMinimal,
            alertMessageDefault,
            alertMessageInfo,
            alertMessageWarning,
            alertMessageSuccess,
            alertMessageDanger,
        }
    }
}
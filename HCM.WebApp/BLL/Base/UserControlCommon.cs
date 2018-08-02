using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace HCM.WebApp.BLL.Base
{
    public class UserControlCommon : System.Web.UI.UserControl
    {
        public static int GetConfigurationPageSize()
        {
            int pageSize = 20;
            try
            {
                int.TryParse(ConfigurationManager.AppSettings["PageSize"], out pageSize);
            }
            catch { }
            return pageSize;
        }

        public int queryStringId
        {
            get
            {
                int id = 0;
                if (Request.QueryString["Id"] != null && !String.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
                {
                    if (int.TryParse(Request.QueryString["Id"].ToString(), out id))
                        return id;
                    else
                        return 0;
                }
                else
                    return 0;
            }
        }
        public int sessionId
        {
            get
            {
                int id = 0;
                if (Session["Id"] != null && !String.IsNullOrEmpty(Session["Id"].ToString()))
                {
                    if (int.TryParse(Session["Id"].ToString(), out id))
                        return id;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            set
            {
                Session["Id"] = value;
            }
        }
        public string queryStringIdStr
        {
            get
            {
                if (Request.QueryString["Id"] != null && !String.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
                {
                    return Request.QueryString["Id"].ToString();
                }
                else
                    return String.Empty;
            }
        }
        public string queryStringsIdStr
        {
            get
            {
                if (Request.QueryString["sId"] != null && !String.IsNullOrEmpty(Request.QueryString["sId"].ToString()))
                {
                    return Request.QueryString["sId"].ToString();
                }
                else
                    return String.Empty;
            }
        }
    }
}
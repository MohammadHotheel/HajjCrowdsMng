using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace HCM.WebApp.BLL.Base
{
    public class PageCommon : System.Web.UI.Page
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
        public int queryStringMId
        {
            get
            {
                int id = 0;
                if (Request.QueryString["MId"] != null && !String.IsNullOrEmpty(Request.QueryString["MId"].ToString()))
                {
                    if (int.TryParse(Request.QueryString["MId"].ToString(), out id))
                        return id;
                    else
                        return 0;
                }
                else
                    return 0;
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

        protected override void InitializeCulture()
        {
            string culture = "en";
            if (Session["CurrentLanguage"] != null)
            {
                //retrieve culture information from session
                culture = Session["CurrentLanguage"].ToString();
            }
            //check whether a culture is stored in the session
            if (culture.Length > 0) Culture = culture;

            //set culture to current thread
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            //call base class
            base.InitializeCulture();
        }

        private static CultureInfo _ArabicCulture;
        public static CultureInfo ArabicCulture
        {
            get
            {
                if (_ArabicCulture == null)
                {
                    _ArabicCulture = new CultureInfo("ar-SA");
                    _ArabicCulture.DateTimeFormat.Calendar = new UmAlQuraCalendar();
                }
                return _ArabicCulture;
            }
        }

        private static CultureInfo _EnglishCulture;
        public static CultureInfo EnglishCulture
        {
            get
            {
                if (_EnglishCulture == null)
                {
                    _EnglishCulture = new CultureInfo("en-US");
                    _EnglishCulture.DateTimeFormat.Calendar = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
                }
                return _EnglishCulture;
            }
        }

        public static string CurrentCultureinfo
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.ToString().Substring(0, 2);
            }
        }

        public static CultureInfo CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture;
            }
        }
    }
}
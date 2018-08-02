using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp
{
    public partial class ChangeLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var lang = Request.QueryString["lang"];
                var referer = Request.UrlReferrer;

                string Query = HttpContext.Current.Request.UrlReferrer.Query;

                if (lang != null)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                    //Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new UmAlQuraCalendar();
                    Session["CurrentLanguage"] = lang;
                }
                Response.Redirect(referer != null ? referer.AbsolutePath + Query : "~/Default.aspx", false);
            }
            catch (Exception exception)
            {
                //exception.Log();
                Response.Redirect("~/Default.aspx?Ex=" + exception.Message, false);
            }
        }
    }
}
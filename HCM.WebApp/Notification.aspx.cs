using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp
{
    public partial class Notification : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FillNotification();
                }
            }
            catch (Exception exception)
            {
                exception.Log();
            }
        }

        public void FillNotification()
        {
            NotificationManager _NotificationManager = new NotificationManager();
            var returnData = _NotificationManager.GetAllNotification();
            var locationData = (from obj in returnData
                                select new
                                {
                                    obj.Title,
                                    obj.Longitude,
                                    obj.Latitude,
                                    obj.Description
                                }).ToList();
            ucLocationsMap.Locations = new JavaScriptSerializer().Serialize(locationData);
        }
    }
}
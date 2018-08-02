using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.Security
{
    public partial class NotificationMang : PageCommon
    {
        public string Operation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null && user.Active == true)
                {
                    if (user.Roles.Count() > 0)
                    {
                        FillDDL();
                        FillData();
                    }
                    else
                    { ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccessDenied"), "", Common.msgType.alertMessageDanger, "~\\Msg.aspx"); }
                }
                else
                { ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccountNotActive"), "", Common.msgType.alertMessageDanger, "~\\Msg.aspx"); }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                NotificationManager _NotificationManager = new NotificationManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.Notification obj = _NotificationManager.GetNotification(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.Notification(); }

                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text.Replace("\r\n", "<br/>");

                string lat = ucLocation.Lat;
                string lng = ucLocation.Lng;

                if(!String.IsNullOrEmpty(lat) && !String.IsNullOrEmpty(lng))
                {
                    obj.Latitude = lat;
                    obj.Longitude = lng;
                }

                int ut = 0;
                if (int.TryParse(ddlUserType.SelectedValue, out ut) && ut != 0)
                { obj.UserTypeId = ut; }

                int nl = 0;
                if (int.TryParse(ddlNotificationLevel.SelectedValue, out nl) && nl != 0)
                { obj.NotificationLevelId = nl; }

                obj.Status = true;
               
                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _NotificationManager.AddNotification(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _NotificationManager.UpdateNotification(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Update");
                }
                if (i != 0)
                {
                    ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), Operation), "", Common.msgType.alertMessageSuccess);
                    FillData();
                }
                else
                {
                    ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationError"), Operation), "", Common.msgType.alertMessageDanger);
                }
            }
            else
            { Response.Redirect("/"); }
        }
        
        private void FillData()
        {
            if (!String.IsNullOrEmpty(queryStringIdStr))
            {
                NotificationManager _NotificationManager = new NotificationManager();
                var obj = _NotificationManager.GetNotification(queryStringId);
                if (obj != null)
                {
                    txtTitle.Text = obj.Title;
                    txtDescription.Text = obj.Description.Replace("<br/>", "\r\n");
                    
                    string lat = obj.Latitude;
                    string lng = obj.Longitude;

                    if (!String.IsNullOrEmpty(lat) && !String.IsNullOrEmpty(lng))
                    {
                        ucLocation.Lat = lat;
                        ucLocation.Lng = lng;
                    }

                    if (obj.UserTypeId.HasValue)
                    { ddlUserType.Items.FindByValue(obj.UserTypeId.Value.ToString()).Selected = true; }

                    if (obj.NotificationLevelId.HasValue)
                    { ddlNotificationLevel.Items.FindByValue(obj.NotificationLevelId.Value.ToString()).Selected = true; }

                    Operation = (String)GetGlobalResourceObject("HCMResource", "UpdateExisting");
                }
                else
                {
                    // نجتاج تعديل الموقع الافتراضي ويمكن قرائته من جدول المواقع
                    Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew");
                    ucLocation.Lat = "21.61698309756992";
                    ucLocation.Lng = "39.15627289310021";
                    ucLocation.Zoom = 19;
                }
            }
            else
            {
                Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew");
                ucLocation.Lat = "21.61698309756992";
                ucLocation.Lng = "39.15627289310021";
                ucLocation.Zoom = 19;
            }
        }
        private void FillDDL()
        {
            UserTypeManager _UserTypeManager = new UserTypeManager();
            var obj = _UserTypeManager.GetAllUserType();
            if (obj != null)
            {
                if (CurrentCultureinfo == "ar")
                { ddlUserType.DataTextField = "NameAr"; }
                else
                { ddlUserType.DataTextField = "NameEn"; }

                ddlUserType.DataValueField = "Id";
                ddlUserType.DataSource = obj.ToList();
            }
            ddlUserType.DataBind();

            NotificationLevelManager _NotificationLevelManager = new NotificationLevelManager();
            var lvl = _NotificationLevelManager.GetAllNotificationLevel();
            if (lvl != null)
            {
                if (CurrentCultureinfo == "ar")
                { ddlNotificationLevel.DataTextField = "NameAr"; }
                else
                { ddlNotificationLevel.DataTextField = "NameEn"; }

                ddlNotificationLevel.DataValueField = "Id";
                ddlNotificationLevel.DataSource = lvl.ToList();
            }
            ddlNotificationLevel.DataBind();
        }
        private void ClearData()
        {
            txtTitle.Text = String.Empty;
            txtDescription.Text = String.Empty;

            ddlNotificationLevel.SelectedIndex = 0;
            ddlUserType.SelectedIndex = 0;

            ucLocation.Lat = String.Empty;
            ucLocation.Lng = String.Empty;

            ucAlertMessage.Clear();
        }
    }
}
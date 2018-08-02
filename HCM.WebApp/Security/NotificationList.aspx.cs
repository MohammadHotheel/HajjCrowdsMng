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
    public partial class NotificationList : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                GridView1.PageSize = GetConfigurationPageSize();
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string un = AspNetSecurityHelper.GetCurrentUserName;
            NotificationManager _NotificationManager = new NotificationManager();

            if (e.CommandName == "DeleteUpdate")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    string operation = (String)GetGlobalResourceObject("HCMResource", "Delete");
                    int i = 0;//_NotificationManager.DeleteNotification(id);
                    DAL.Entity.Notification obj = _NotificationManager.GetNotification(id);
                    if (obj != null)
                    {
                        obj.DeletedFlag = true;
                        obj.LastUpdatedBy = un;
                        obj.LastUpdatedDate = DateTime.Now;
                        i = _NotificationManager.UpdateNotification(obj);
                    }
                    if (i != 0)
                    { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), operation), "", Common.msgType.alertMessageSuccess); }
                    else
                    { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationError"), operation), "", Common.msgType.alertMessageDanger); }

                    FillData();
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillData();
        }
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
        protected void ddlNotificationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            NotificationManager _NotificationManager = new NotificationManager();
            SSAManager _SSAManager = new SSAManager();
            var obj = _NotificationManager.GetAllNotification();
            if (obj != null)
            {
                var data = from tbl in obj
                           select new
                           {
                               tbl.Id,
                               tbl.Title,
                               tbl.Description,
                               UserTypeEn = tbl.UserType.NameEn,
                               UserTypeAr = tbl.UserType.NameAr,
                               NotificationLevelEn = tbl.NotificationLevel.NameEn,
                               NotificationLevelAr = tbl.NotificationLevel.NameAr,
                               tbl.Status
                           };
                GridView1.DataSource = data.ToList();
            }
            GridView1.DataBind();
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
    }
}
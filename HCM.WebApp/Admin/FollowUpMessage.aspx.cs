using Microsoft.AspNet.Identity;
using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.Admin
{
    public partial class FollowUpMessage : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                GridView1.PageSize = GetConfigurationPageSize();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null && user.Active == true && user.UserTypeId ==1)
                {
                    FillDDL();
                    FillData();
                }
                else
                {
                    ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccessDenied"), "", Common.msgType.alertMessageDanger, "~\\Msg.aspx");
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string un = AspNetSecurityHelper.GetCurrentUserName;
            MessageManager _MessageManager = new MessageManager();

            if (e.CommandName == "Close")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    string operation = (String)GetGlobalResourceObject("HCMResource", "Close");
                    int i = 0;//_StateManager.DeleteState(id);
                    DAL.Entity.Message obj = _MessageManager.GetMessage(id);
                    if (obj != null)
                    {
                        obj.Status = true;
                        obj.LastUpdatedBy = un;
                        obj.LastUpdatedDate = DateTime.Now;
                        i = _MessageManager.UpdateMessage(obj);
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

        protected void ddlMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            MessageManager _MessageManager = new MessageManager();
            var msg = _MessageManager.GetAllMessage();
            if (msg != null)
            {
                if (ddlStatus.SelectedIndex != 0)
                {
                    bool active = (ddlStatus.SelectedValue == "1" ? true : false);
                    msg = msg.Where(w => w.Status == active).ToList();
                }
                
                string typ = ddlMessageType.SelectedValue;
                int t = 0;
                if (int.TryParse(typ, out t) && t != 0)
                {
                    msg = msg.Where(w => w.MessageTypeId == t).ToList();
                }
                var data = from tbl in msg
                           select new
                           {
                               tbl.Id,
                               tbl.SenderName,
                               tbl.SenderEmail,
                               tbl.SenderMobile,
                               tbl.MessageText,
                               MessageType = (tbl.MessageTypeId.HasValue ? tbl.MessageType.Name : ""),
                               tbl.Status
                           };
                GridView1.DataSource = data.ToList();
            }
            GridView1.DataBind();
        }
        private void FillDDL()
        {
            MessageManager _MessageManager = new MessageManager();
            var obj = _MessageManager.GetAllMessageType();
            if (obj != null)
            {
                ddlMessageType.DataTextField = "Name";
                ddlMessageType.DataValueField = "Id";
                ddlMessageType.DataSource = obj.ToList();
            }
            ddlMessageType.DataBind();
        }
        public string GetRoleNameByRoleId(string roleId)
        {
            var role = AspNetSecurityHelper.FindRoleById(roleId);
            if (role != null)
            { return role.Name; }
            else
                return null;
        }
    }
}
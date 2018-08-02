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
    public partial class ManageAccount : PageCommon
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
            string operation = "";
            string userId = e.CommandArgument.ToString();
            if (!String.IsNullOrEmpty(userId))
            {
                var user = AspNetSecurityHelper.FindUserById(userId);
                if (user != null)
                {
                    if (e.CommandName == "ActiveUser")
                    {
                        if (user.LockoutEndDateUtc != null)
                        {
                            //user.Active = true;
                            user.AccessFailedCount = 0;
                            user.LockoutEndDateUtc = null;
                            operation = (String)GetGlobalResourceObject("HCMResource", "Active");
                        }
                        else
                        {
                            //user.Active = false;
                            user.AccessFailedCount = 5;
                            user.LockoutEndDateUtc = DateTime.Now.AddDays(365);
                            operation = (String)GetGlobalResourceObject("HCMResource", "Lock");
                        }
                    }
                    else if (e.CommandName == "GrantPermission")
                    {
                        user.Active = true;
                        var roles = user.Roles;
                        if (roles.Count() == 0)
                        {
                            var role = AspNetSecurityHelper.FindRoleByName("Supervisor");
                            if (role != null)
                            { AspNetSecurityHelper.InsertUserToRole(user.Id, role.Id); }
                        }
                        operation = (String)GetGlobalResourceObject("HCMResource", "GrantPermission");
                    }
                    IdentityResult r = AspNetSecurityHelper.UpdateUser(user);
                    if (r.Succeeded)
                    {
                        SSAManager _SSAManager = new SSAManager();
                        DAL.Entity.SaudiStudentAssociation obj = null;
                        if (user != null)
                        {
                            if (user.UniversityId.HasValue)
                            { obj = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value); }
                            //obj = _SSAManager.GetSSAByAdministratorId(user.Id);
                            if(obj == null)
                            { obj = new DAL.Entity.SaudiStudentAssociation(); }
                            obj.AdministratorId = user.Id;
                            
                            if (user.UniversityId.HasValue && user.UniversityId.Value != 0)
                            { obj.UniversityId = user.UniversityId.Value; }

                            int i = 0;
                            if (obj.Id == 0)
                            {
                                obj.CreatedBy = user.UserName;
                                obj.CreatedDate = DateTime.Now;
                                obj.DeletedFlag = false;
                                i = _SSAManager.AddSSA(obj);
                            }
                            else
                            {
                                obj.LastUpdatedBy = user.UserName;
                                obj.LastUpdatedDate = DateTime.Now;
                                i = _SSAManager.UpdateSSA(obj);
                            }
                        }

                        ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), operation), "", Common.msgType.alertMessageSuccess);
                    }
                    else
                    {
                        string errorStr = (String)GetGlobalResourceObject("HCMResource", "ActiveError");
                        foreach (string s in r.Errors)
                        { errorStr += ", " + s.ToString(); }
                        ucAlertMessage.AlertMessage(errorStr, "", Common.msgType.alertMessageDanger);
                    }
                }
                else
                { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationError"), operation), "", Common.msgType.alertMessageDanger); }
                FillData();
            }
            else
            { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationError"), operation), "", Common.msgType.alertMessageDanger); }
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
        protected void ddlActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
        protected void ddlPermmisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            UserManager _UserManager = new UserManager();
            var Users = _UserManager.GetAllAspNetUser();
            if (Users != null)
            {
                if (ddlPermmisions.SelectedIndex != 0)
                {
                    bool active = (ddlPermmisions.SelectedValue == "1" ? true : false);
                    Users = Users.Where(w => w.Active == active).ToList();
                }
                if (ddlActive.SelectedIndex != 0)
                {
                    bool value = (ddlActive.SelectedValue == "1" ? false : true);
                    Users = Users.Where(w => w.LockoutEndDateUtc.HasValue == value).ToList(); 
                }
                string typ = ddlUserType.SelectedValue;
                int t = 0;
                if (int.TryParse(typ, out t) && t != 0)
                {
                    Users = Users.Where(w => w.UserTypeId == t).ToList();
                }
                var data = from tbl in Users
                           select new
                           {
                               tbl.Id,
                               tbl.FullName,
                               tbl.Email,
                               tbl.UserName,
                               tbl.Mobile,
                               University = (tbl.UniversityId.HasValue ? tbl.University.Name : ""),
                               tbl.AspNetRoles,
                               tbl.Active,
                               tbl.AccessFailedCount,
                               tbl.LockoutEndDateUtc,
                               Count = tbl.AspNetRoles.Count
                           };
                GridView1.DataSource = data.ToList();
            }
            GridView1.DataBind();
        }
        private void FillDDL()
        {
            UserManager _UserManager = new UserManager();
            var obj = _UserManager.GetAllUserType();
            if (obj != null)
            {
                ddlUserType.DataTextField = "Name"; 
                ddlUserType.DataValueField = "Id";
                ddlUserType.DataSource = obj.ToList();
            }
            ddlUserType.DataBind();
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
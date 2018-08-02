using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.SSA
{
    public partial class ServiceInfoList : PageCommon
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
                        AdminView();
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
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();

            if (e.CommandName == "DeleteUpdate")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    bool chk = _ServiceInfoManager.CheckCanDeleted(id);
                    if (chk)
                    {
                        string operation = (String)GetGlobalResourceObject("HCMResource", "Delete");
                        int i = 0;//_ServiceInfoManager.DeleteServiceInfo(id);
                        DAL.Entity.ServiceInformation obj = _ServiceInfoManager.GetServiceInfo(id);
                        if (obj != null)
                        {
                            obj.DeletedFlag = true;
                            obj.LastUpdatedBy = un;
                            obj.LastUpdatedDate = DateTime.Now;
                            i = _ServiceInfoManager.UpdateServiceInfo(obj);
                        }
                        if (i != 0)
                        { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), operation), "", Common.msgType.alertMessageSuccess); }
                        else
                        { ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationError"), operation), "", Common.msgType.alertMessageDanger); }
                    }
                    else
                    { ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "CantDelete"), "", Common.msgType.alertMessageDanger); }
                    FillData();
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillData();
        }
        protected void ddlSSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(ddlSSA.SelectedValue, out i))
            {
                HttpContext.Current.Response.Redirect(String.Format("~/SSA/ServiceInfoMang.aspx?MId={0}", i), true);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/SSA/ServiceInfoMang.aspx", true);
            }
        }

        private void AdminView()
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                if (user.UserTypeId == 1) // Administrator
                {
                    divAdminView.Visible = true;
                    //GridView1.Columns[1].Visible = true;
                }
                else // Supervisor
                {
                    divAdminView.Visible = false;
                    //GridView1.Columns[1].Visible = false;
                }
            }
        }
        private void FillData()
        {
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
            SSAManager _SSAManager = new SSAManager();
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null) 
            {
                var obj = _ServiceInfoManager.GetAllServiceInfo();
                if (user.UserTypeId == 2) // Supervisor
                {
                    if (user.UniversityId.HasValue)
                    {
                        var ssa = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value);
                        //var ssa = _SSAManager.GetSSAByAdministratorId(user.Id);
                        if (ssa != null)
                        { obj = _ServiceInfoManager.GetAllBySSAId(ssa.Id); }
                        else
                        { obj = null; }
                    }
                }
                if (obj != null)
                {
                    var data = from tbl in obj
                               select new
                               {
                                   tbl.Id,
                                   tbl.Title,
                                   tbl.Description,
                                   tbl.Section,
                                   tbl.Address,
                                   ServiceCategory = tbl.ServiceCategory.Name,
                                   SSA = (String.IsNullOrEmpty(tbl.SaudiStudentAssociation.Name) ? "" : tbl.SaudiStudentAssociation.Name + " - ") + tbl.SaudiStudentAssociation.University.Name + (tbl.SaudiStudentAssociation.State != null ? " - " + tbl.SaudiStudentAssociation.State.Name : "") + (tbl.SaudiStudentAssociation.City != null ? " - " + tbl.SaudiStudentAssociation.City.Name : ""),
                                   ssaId = tbl.SaudiStudentAssociationId,
                                   ServiceDetailsCount = tbl.ServiceDetails.Where(w => w.DeletedFlag == false).Count()
                               };
                    string ssa = ddlSSA.SelectedValue;
                    int ssaId = 0;
                    if (int.TryParse(ssa, out ssaId) && ssaId != 0)
                    { data = data.Where(w => w.ssaId == ssaId).ToList(); }
                    GridView1.DataSource = data.ToList();
                }
            }
            GridView1.DataBind();
        }
        private void FillDDL()
        {
            SSAManager _SSAManager = new SSAManager();
            var obj = _SSAManager.GetAllSSA();
            if (obj != null)
            {
                var data = from tbl in obj
                           select new
                           {
                               tbl.Id,
                               Name = (String.IsNullOrEmpty(tbl.Name) ? "" : tbl.Name + " - ") +  tbl.University.Name + (tbl.State != null ? " - " + tbl.State.Name : "") + (tbl.City != null ? " - " + tbl.City.Name : "")
                           };
                ddlSSA.DataTextField = "Name";
                ddlSSA.DataValueField = "Id";
                ddlSSA.DataSource = data.ToList();
            }
            ddlSSA.DataBind();
        }
    }
}
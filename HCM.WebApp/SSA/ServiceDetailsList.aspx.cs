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
    public partial class ServiceDetailsList : PageCommon
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
            ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();

            if (e.CommandName == "DeleteUpdate")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    string operation = (String)GetGlobalResourceObject("HCMResource", "Delete");
                    int i = 0;//_ServiceDetailsManager.DeleteServiceDetails(id);
                    DAL.Entity.ServiceDetail obj = _ServiceDetailsManager.GetServiceDetails(id);
                    if (obj != null)
                    {
                        obj.DeletedFlag = true;
                        obj.LastUpdatedBy = un;
                        obj.LastUpdatedDate = DateTime.Now;
                        i = _ServiceDetailsManager.UpdateServiceDetails(obj);
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
        protected void ddlSSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
            SSAManager _SSAManager = new SSAManager();
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                sessionId = queryStringId;
                var mster = _ServiceInfoManager.GetServiceInfo(queryStringId);
                var obj = _ServiceDetailsManager.GetAllByServiceInfoId(queryStringId);
                if (mster != null)
                {
                    lblSSA.Text = mster.SaudiStudentAssociation.Name;
                    lblServiceInfo.Text = mster.Title;
                }
                if (obj != null)
                {
                    var data = from tbl in obj
                               select new
                               {
                                   tbl.Id,
                                   tbl.InfoTypeId,
                                   tbl.FileExt,
                                   InfoType = tbl.InfoType.Name,
                                   tbl.InformationContent,
                                   svcInfoId = tbl.ServiceInformationId,
                                   SSA = tbl.ServiceInformation.SaudiStudentAssociation.Name,
                                   SvcInfo = tbl.ServiceInformation.Title
                               };
                    GridView1.DataSource = data.ToList();
                }
            }
            GridView1.DataBind();
        }
    }
}
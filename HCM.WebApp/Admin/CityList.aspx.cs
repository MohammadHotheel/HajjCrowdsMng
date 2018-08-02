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
    public partial class CityList : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                GridView1.PageSize = GetConfigurationPageSize();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null && user.Active == true && user.UserTypeId == 1)
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
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(ddlState.SelectedValue, out i))
            {
                HttpContext.Current.Response.Redirect(String.Format("~/Admin/CityMang.aspx?MId={0}", i), true);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Admin/CityMang.aspx", true);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string un = AspNetSecurityHelper.GetCurrentUserName;
            CityManager _CityManager = new CityManager();

            if (e.CommandName == "DeleteUpdate")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    bool chk = _CityManager.CheckCanDeleted(id);
                    if (chk)
                    {
                        string operation = (String)GetGlobalResourceObject("HCMResource", "Delete");
                        int i = 0;//_CityManager.DeleteCity(id);
                        DAL.Entity.City obj = _CityManager.GetCity(id);
                        if (obj != null)
                        {
                            obj.DeletedFlag = true;
                            obj.LastUpdatedBy = un;
                            obj.LastUpdatedDate = DateTime.Now;
                            i = _CityManager.UpdateCity(obj);
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
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            CityManager _CityManager = new CityManager();
            SSAManager _SSAManager = new SSAManager();
            var user = AspNetSecurityHelper.currentAppUser;
            int s = 0;
            if (user != null && int.TryParse(ddlState.SelectedValue, out s)) 
            {
                var obj = _CityManager.GetAllByStateId(s);
                if (obj != null)
                {
                    GridView1.DataSource = obj.ToList();
                }
            }
            GridView1.DataBind();
        }
        private void FillDDL()
        {
            StateManager _StateManager = new StateManager();
            var obj = _StateManager.GetAllState();
            if (obj != null)
            {
                ddlState.DataTextField = "Name";
                ddlState.DataValueField = "Id";
                ddlState.DataSource = obj.ToList();
            }
            ddlState.DataBind();
        }
    }
}
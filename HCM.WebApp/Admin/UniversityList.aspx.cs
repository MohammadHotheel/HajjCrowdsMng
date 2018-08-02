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
    public partial class UniversityList : PageCommon
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
            UniversityManager _UniversityManager = new UniversityManager();

            if (e.CommandName == "DeleteUpdate")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id))
                {
                    bool chk = _UniversityManager.CheckCanDeleted(id);
                    if (chk)
                    {
                        string operation = (String)GetGlobalResourceObject("HCMResource", "Delete");
                        int i = 0;//_UniversityManager.DeleteUniversity(id);
                        DAL.Entity.University obj = _UniversityManager.GetUniversity(id);
                        if (obj != null)
                        {
                            obj.DeletedFlag = true;
                            obj.LastUpdatedBy = un;
                            obj.LastUpdatedDate = DateTime.Now;
                            i = _UniversityManager.UpdateUniversity(obj);
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
       
        private void FillData()
        {
            UniversityManager _UniversityManager = new UniversityManager();
            SSAManager _SSAManager = new SSAManager();
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null) 
            {
                var obj = _UniversityManager.GetAllUniversity();
                if (obj != null)
                {
                    GridView1.DataSource = obj.ToList();
                }
            }
            GridView1.DataBind();
        }
    }
}
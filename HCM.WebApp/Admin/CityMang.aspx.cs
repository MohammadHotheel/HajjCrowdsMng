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
    public partial class CityMang : PageCommon
    {
        public string Operation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null && user.Active == true && user.UserTypeId == 1)
                {
                    FillDDL();
                    if (queryStringMId.ToString() != "0")
                    { ddlState.Items.FindByValue(queryStringMId.ToString()).Selected = true; }
                    FillData();
                }
                else
                {
                    ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccessDenied"), "", Common.msgType.alertMessageDanger, "~\\Msg.aspx");
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                CityManager _CityManager = new CityManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.City obj = _CityManager.GetCity(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.City(); }

                obj.Name = txtCity.Text;

                int s = 0;
                if(int.TryParse(ddlState.SelectedValue, out s))
                { obj.StateId = s; }
                
                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _CityManager.AddCity(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _CityManager.UpdateCity(obj);
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
                CityManager _CityManager = new CityManager();
                var obj = _CityManager.GetCity(queryStringId);
                if (obj != null)
                {
                    txtCity.Text = obj.Name;

                    if (obj.StateId.HasValue)
                    { ddlState.Items.FindByValue(obj.StateId.Value.ToString()).Selected = true; }

                    Operation = (String)GetGlobalResourceObject("HCMResource", "UpdateExisting");
                }
                else
                { Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew"); }
            }
            else
            { Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew"); }
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
        private void ClearData()
        {
            txtCity.Text = String.Empty;
            ucAlertMessage.Clear();
        }
    }
}
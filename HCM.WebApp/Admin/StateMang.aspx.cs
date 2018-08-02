using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Web.UI;

namespace HCM.WebApp.SSA
{
    public partial class StateMang : PageCommon
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
                StateManager _StateManager = new StateManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.State obj = _StateManager.GetState(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.State(); }

                obj.Name = txtState.Text;
                
                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _StateManager.AddState(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _StateManager.UpdateState(obj);
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
                StateManager _StateManager = new StateManager();
                var obj = _StateManager.GetState(queryStringId);
                if (obj != null)
                {
                    txtState.Text = obj.Name;
                    Operation = (String)GetGlobalResourceObject("HCMResource", "UpdateExisting");
                }
                else
                { Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew"); }
            }
            else
            { Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew"); }
        }
        private void ClearData()
        {
            txtState.Text = String.Empty;
            ucAlertMessage.Clear();
        }
    }
}
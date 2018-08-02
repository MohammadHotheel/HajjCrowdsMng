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
    public partial class ServiceCategoryMang : PageCommon
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
                ServiceCategoryManager _ServiceCategoryManager = new ServiceCategoryManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.ServiceCategory obj = _ServiceCategoryManager.GetServiceCategory(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.ServiceCategory(); }

                obj.Name = txtServiceCategory.Text;
                
                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _ServiceCategoryManager.AddServiceCategory(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _ServiceCategoryManager.UpdateServiceCategory(obj);
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
                ServiceCategoryManager _ServiceCategoryManager = new ServiceCategoryManager();
                var obj = _ServiceCategoryManager.GetServiceCategory(queryStringId);
                if (obj != null)
                {
                    txtServiceCategory.Text = obj.Name;
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
            txtServiceCategory.Text = String.Empty;
            ucAlertMessage.Clear();
        }
    }
}
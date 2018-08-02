using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.UC
{
    public partial class ucSendMsg : UserControlCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                FillDDL();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null)
                { FillData(); }
            }            
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string Operation = String.Empty;
            MessageManager _MessageManager = new MessageManager();
            DAL.Entity.Message obj = new DAL.Entity.Message();

            obj.SenderId = hfId.Value.ToString();
            obj.SenderName = txtFullName.Text;
            obj.SenderMobile = txtMobile.Text;
            obj.SenderEmail = txtEmail.Text;
            obj.MessageText = txtMessage.Text;

            int typ = 0;
            if (int.TryParse(ddlMessageType.Text, out typ))
            { obj.MessageTypeId = typ; }

            obj.Status = false;

            string un = txtEmail.Text;

            int i = 0;
            if (obj.Id == 0)
            {
                obj.CreatedBy = un;
                obj.CreatedDate = DateTime.Now;
                obj.DeletedFlag = false;
                i = _MessageManager.AddMessage(obj);
                Operation = (String)GetGlobalResourceObject("HCMResource", "Send");
            }
            if (i != 0)
            {
                ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), Operation), "", Common.msgType.alertMessageSuccess);
                btnSend.Visible = false;
                btnClear.Visible = false;
            }
            else
            {
                ucAlertMessage.AlertMessage(String.Format((String)GetGlobalResourceObject("HCMResource", "OperationSuccess"), Operation), "", Common.msgType.alertMessageDanger);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void FillData()
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                txtFullName.Text = user.FullName;
                txtMobile.Text = user.Mobile;
                txtEmail.Text = user.Email;
                hfId.Value = user.Id.ToString();

                txtFullName.ReadOnly = true;
                txtMobile.ReadOnly = true;
                txtEmail.ReadOnly = true;
            }
        }

        private void ClearData()
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user == null)
            {
                txtFullName.Text = String.Empty;
                txtMobile.Text = String.Empty;
                txtEmail.Text = String.Empty;
            }
            txtMessage.Text = String.Empty;
            ddlMessageType.SelectedIndex = 0;
            ucAlertMessage.Clear();
        }
        private void FillDDL()
        {
            MessageManager _MessageReplyManager = new MessageManager();

            var obj = _MessageReplyManager.GetAllMessageType();
            if (obj != null)
            {
                ddlMessageType.DataTextField = "Name"; 
                ddlMessageType.DataValueField = "Id";
                ddlMessageType.DataSource = obj.ToList();
            }
            ddlMessageType.DataBind();
        }
    }
}
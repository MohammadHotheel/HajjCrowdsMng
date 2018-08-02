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
    public partial class FAQMang : PageCommon
    {
        public string Operation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucAlertMessage.Clear();
                var user = AspNetSecurityHelper.currentAppUser;
                if (user != null && user.Active == true)
                {
                    if (user.Roles.Count() > 0)
                    {
                        FillDDL();
                        if (queryStringMId.ToString() != "0")
                        { ddlSSA.Items.FindByValue(queryStringMId.ToString()).Selected = true; }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                FAQManager _FAQManager = new FAQManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.FAQ obj = _FAQManager.GetFAQ(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.FAQ(); }

                obj.Question = txtQuestion.Text.Replace("\r\n", "<br/>");
                obj.Answer = txtAnswer.Text.Replace("\r\n", "<br/>");
                
                if (user.UserTypeId == 2) // Supervisor
                {
                    if (user.UniversityId.HasValue)
                    {
                        var ssa = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value);
                        //var ssa = _SSAManager.GetSSAByAdministratorId(user.Id);
                        if (ssa != null)
                        {
                            obj.SaudiStudentAssociationId = ssa.Id;
                        }
                    }
                }
                else // Administrator
                {
                    string SSA = ddlSSA.SelectedValue;
                    int ssa = 0;
                    if (int.TryParse(SSA, out ssa) && ssa != 0)
                    {
                        obj.SaudiStudentAssociationId = ssa;
                    }
                }

                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _FAQManager.AddFAQ(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _FAQManager.UpdateFAQ(obj);
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

        private void AdminView()
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                if (user.UserTypeId == 1) // Administrator
                { divAdminView.Visible = true; }
                else // Supervisor
                { divAdminView.Visible = false; }
            }
        }
        private void FillData()
        {
            if (!String.IsNullOrEmpty(queryStringIdStr))
            {
                FAQManager _FAQManager = new FAQManager();
                var obj = _FAQManager.GetFAQ(queryStringId);
                if (obj != null)
                {
                    txtQuestion.Text = obj.Question.Replace("<br/>", "\r\n");
                    txtAnswer.Text = obj.Answer.Replace("<br/>", "\r\n");

                    if (obj.SaudiStudentAssociationId.HasValue)
                    { ddlSSA.Items.FindByValue(obj.SaudiStudentAssociationId.Value.ToString()).Selected = true; }

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
        private void ClearData()
        {
            txtQuestion.Text = String.Empty;
            txtAnswer.Text = String.Empty;
            ucAlertMessage.Clear();
        }
    }
}
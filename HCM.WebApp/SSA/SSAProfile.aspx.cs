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
    public partial class SSAProfile : PageCommon
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
                        FillData();
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
            int ssaId = 0;
            SSAManager _SSAManager = new SSAManager();
            DAL.Entity.SaudiStudentAssociation obj = null;
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                if (user.UserTypeId == 1 && int.TryParse(ddlSSA.SelectedValue, out ssaId)) // Administrator
                {
                    obj = _SSAManager.GetSSA(ssaId);
                }
                else
                {
                    if (user.UniversityId.HasValue)
                    { obj = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value); }
                    obj.AdministratorId = user.Id;
                }
                obj.Name = txtName.Text;
                obj.Website = txtWebsite.Text;
                obj.SocialInfo = txtSocialInfo.Text;
                obj.Phone = txtPhone.Text;
                obj.Fax = txtFax.Text;
                obj.Street = txtStreet.Text;

                int zipcode = 0;
                if (int.TryParse(txtZipCode.Text, out zipcode))
                { obj.ZipCode = zipcode; }

                int state = 0;
                if (int.TryParse(ddlState.SelectedValue, out state))
                { obj.StateId = state; }

                int city = 0;
                if (int.TryParse(ddlCity.SelectedValue, out city))
                { obj.CityId = city; }

                int uni = 0;
                if (int.TryParse(ddlUniversity.SelectedValue, out uni))
                { obj.UniversityId = uni; }
                
                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _SSAManager.AddSSA(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _SSAManager.UpdateSSA(obj);
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
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(ddlState.SelectedValue, out i))
            {
                FillCity(i);
            }
        }
        protected void ddlSSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            int ssaId = 0;
            SSAManager _SSAManager = new SSAManager();
            DAL.Entity.SaudiStudentAssociation obj = null;
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null)
            {
                if (user.UserTypeId == 1 && int.TryParse(ddlSSA.SelectedValue, out ssaId)) // Administrator
                {
                    obj = _SSAManager.GetSSA(ssaId);
                    ddlUniversity.Enabled = true;
                    divAdminView.Visible = true;
                }
                else
                {
                    if (user.UniversityId.HasValue)
                    { obj = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value); }
                    ddlUniversity.Enabled = false;
                    divAdminView.Visible = false;
                }
            }
            if (obj != null)
            {
                txtName.Text = obj.Name;
                txtWebsite.Text = obj.Website;
                txtSocialInfo.Text = obj.SocialInfo;
                txtPhone.Text = obj.Phone;
                txtFax.Text = obj.Fax;
                txtStreet.Text = obj.Street;

                if (obj.ZipCode.HasValue)
                { txtZipCode.Text = obj.ZipCode.Value.ToString(); }
                else
                { txtZipCode.Text = String.Empty; }

                if (obj.StateId.HasValue)
                {
                    ddlState.ClearSelection();
                    ddlState.Items.FindByValue(obj.StateId.Value.ToString()).Selected = true;
                    FillCity(obj.StateId.Value);
                }
                else
                { ddlState.SelectedIndex = 0; }

                if (obj.CityId.HasValue)
                {
                    ddlCity.ClearSelection();
                    ddlCity.Items.FindByValue(obj.CityId.Value.ToString()).Selected = true;
                }
                else
                { ddlCity.SelectedIndex = 0; }

                if (obj.UniversityId.HasValue)
                {
                    ddlUniversity.ClearSelection();
                    ddlUniversity.Items.FindByValue(obj.UniversityId.Value.ToString()).Selected = true;
                }
                else
                { ddlUniversity.SelectedIndex = 0; }

                Operation = (String)GetGlobalResourceObject("HCMResource", "UpdateExisting");
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

            StateManager _StateManager = new StateManager();
            var state = _StateManager.GetAllState();
            if (state != null)
            {
                ddlState.DataTextField = "Name";
                ddlState.DataValueField = "Id";
                ddlState.DataSource = state.ToList();
            }
            ddlState.DataBind();

            UniversityManager _UniversityManager = new UniversityManager();
            var uni = _UniversityManager.GetAllUniversity();
            if (uni != null)
            {
                ddlUniversity.DataTextField = "Name";
                ddlUniversity.DataValueField = "Id";
                ddlUniversity.DataSource = uni.ToList();
            }
            ddlUniversity.DataBind();
        }
        private void FillCity(int i)
        {
            ddlCity.Items.Clear();
            CityManager _CityManager = new CityManager();
            var city = _CityManager.GetAllByStateId(i);
            if (city != null)
            {
                ddlCity.Items.Add(new ListItem((String)GetGlobalResourceObject("HCMResource", "All"), "0"));

                ddlCity.DataTextField = "Name";
                ddlCity.DataValueField = "Id";
                ddlCity.DataSource = city.ToList();
            }
            ddlCity.DataBind();
        }
        private void ClearData()
        {
            txtName.Text = String.Empty;
            txtWebsite.Text = String.Empty;
            txtSocialInfo.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtStreet.Text = String.Empty;
            txtZipCode.Text = String.Empty;

            ddlState.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;

            ucAlertMessage.Clear();
        }       
    }
}
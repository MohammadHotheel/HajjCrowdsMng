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
    public partial class ServiceInfoMang : PageCommon
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
                ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.ServiceInformation obj = _ServiceInfoManager.GetServiceInfo(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.ServiceInformation(); }

                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text.Replace("\r\n", "<br/>");
                obj.Section = txtSection.Text;
                obj.Address = txtAddress.Text.Replace("\r\n", "<br/>");

                string lat = ucLocation.Lat;
                string lng = ucLocation.Lng;

                if(!String.IsNullOrEmpty(lat) && !String.IsNullOrEmpty(lng))
                {
                    obj.Latitude = lat;
                    obj.Longitude = lng;
                }

                int cat = 0;
                if (int.TryParse(ddlServiceCategory.SelectedValue, out cat) && cat != 0)
                { obj.ServiceCategoryId = cat; }

                if (user.UserTypeId == 2) // Supervisor
                {
                    if (user.UniversityId.HasValue)
                    {
                        var ssa = _SSAManager.GetSSAByUniversityId(user.UniversityId.Value);
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
                    i = _ServiceInfoManager.AddServiceInfo(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _ServiceInfoManager.UpdateServiceInfo(obj);
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
                ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
                var obj = _ServiceInfoManager.GetServiceInfo(queryStringId);
                if (obj != null)
                {
                    txtTitle.Text = obj.Title;
                    txtDescription.Text = obj.Description.Replace("<br/>", "\r\n");
                    txtSection.Text = obj.Section;
                    txtAddress.Text = obj.Address.Replace("<br/>", "\r\n");
                    
                    string lat = obj.Latitude;
                    string lng = obj.Longitude;

                    if (!String.IsNullOrEmpty(lat) && !String.IsNullOrEmpty(lng))
                    {
                        ucLocation.Lat = lat;
                        ucLocation.Lng = lng;
                    }

                    if (obj.SaudiStudentAssociationId.HasValue)
                    { ddlSSA.Items.FindByValue(obj.SaudiStudentAssociationId.Value.ToString()).Selected = true; }

                    if (obj.ServiceCategoryId.HasValue)
                    { ddlServiceCategory.Items.FindByValue(obj.ServiceCategoryId.Value.ToString()).Selected = true; }

                    Operation = (String)GetGlobalResourceObject("HCMResource", "UpdateExisting");
                }
                else
                {
                    Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew");
                    ucLocation.Lat = "36.63209344924568";
                    ucLocation.Lng = "-101.74928646693019";
                    ucLocation.Zoom = 5;
                }
            }
            else
            {
                Operation = (String)GetGlobalResourceObject("HCMResource", "AddNew");
                ucLocation.Lat = "36.63209344924568";
                ucLocation.Lng = "-101.74928646693019";
                ucLocation.Zoom = 5;
            }
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

            ServiceCategoryManager _ServiceCategoryManager = new ServiceCategoryManager();
            var cat = _ServiceCategoryManager.GetAllServiceCategory();
            if (cat != null)
            {
                ddlServiceCategory.DataTextField = "Name";
                ddlServiceCategory.DataValueField = "Id";
                ddlServiceCategory.DataSource = cat.ToList();
            }
            ddlServiceCategory.DataBind();
        }
        private void ClearData()
        {
            txtTitle.Text = String.Empty;
            txtDescription.Text = String.Empty;

            txtSection.Text = String.Empty;
            txtAddress.Text = String.Empty;

            ddlServiceCategory.SelectedIndex = 0;

            ucLocation.Lat = String.Empty;
            ucLocation.Lng = String.Empty;

            ucAlertMessage.Clear();
        }
    }
}
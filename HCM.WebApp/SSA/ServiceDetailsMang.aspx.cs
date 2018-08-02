using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.SSA
{
    public partial class ServiceDetailsMang : PageCommon
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
                        //string appPath = HttpContext.Current.Request.ApplicationPath;
                        //string physicalPath = HttpContext.Current.Request.MapPath(appPath);
                        //string ImagesFolderPath = physicalPath + "\\" + "DetailsImages";
                        //ucAlertMessage.AlertMessage(physicalPath, ImagesFolderPath, Common.msgType.alertMessageDanger);

                        FillDDL();
                        FillData();
                    }
                    else
                    { ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccessDenied"), "", Common.msgType.alertMessageDanger, "~~\\Msg.aspx"); }
                }
                else
                { ucAlertMessage.AlertMessage((String)GetGlobalResourceObject("HCMResource", "AccountNotActive"), "", Common.msgType.alertMessageDanger, "~~\\Msg.aspx"); }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = AspNetSecurityHelper.currentAppUser;
            if (user != null && sessionId != 0)
            {
                ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
                SSAManager _SSAManager = new SSAManager();

                DAL.Entity.ServiceDetail obj = _ServiceDetailsManager.GetServiceDetails(queryStringId);
                if (obj == null)
                { obj = new DAL.Entity.ServiceDetail(); }

                obj.InformationContent = txtInformationContent.Text;

                obj.ServiceInformationId = sessionId;

                int typ = 0;
                if (int.TryParse(ddlInfoType.SelectedValue, out typ) && typ != 0)
                { obj.InfoTypeId = typ; }

                int i = 0;
                if (obj.Id == 0)
                {
                    obj.CreatedBy = user.UserName;
                    obj.CreatedDate = DateTime.Now;
                    obj.DeletedFlag = false;
                    i = _ServiceDetailsManager.AddServiceDetails(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Add");
                    btnSave.Visible = false;
                }
                else
                {
                    obj.LastUpdatedBy = user.UserName;
                    obj.LastUpdatedDate = DateTime.Now;
                    i = _ServiceDetailsManager.UpdateServiceDetails(obj);
                    Operation = (String)GetGlobalResourceObject("HCMResource", "Update");
                }
                if (i != 0)
                {
                    if (obj.Id != 0 && obj.ServiceInformationId.HasValue)
                    { UploadImage(obj.Id, obj.ServiceInformationId.ToString(), obj.InfoTypeId.ToString()); }
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
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (sessionId != 0)
            {
                HttpContext.Current.Response.Redirect(String.Format("../SSA/ServiceDetailsList.aspx?Id={0}", sessionId), true);
            }
            else
            {
                HttpContext.Current.Response.Redirect("../SSA/ServiceInfoList.aspx", true);
            }
        }
        protected void ddlInfoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillInfoType();
        }

        private void FillData()
        {
            if (!String.IsNullOrEmpty(queryStringIdStr) && sessionId != 0)
            {
                ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
                var obj = _ServiceDetailsManager.GetServiceDetails(queryStringId);
                if (obj != null)
                {
                    txtInformationContent.Text = obj.InformationContent;

                    if (!String.IsNullOrEmpty(obj.InformationContent))
                    {
                        url.PostBackUrl = obj.InformationContent;
                        url.Text = obj.InformationContent;
                        file.PostBackUrl = String.Format("~/DetailsFiles/{0}_{1}.{2}", obj.ServiceInformationId.Value.ToString(), obj.Id.ToString(), obj.FileExt);
                        file.Text = obj.InformationContent;
                        img.ImageUrl = String.Format("~/DetailsImages/{0}_{1}.{2}", obj.ServiceInformationId.Value.ToString(), obj.Id.ToString(), obj.FileExt);
                        lnkImg.HRef = String.Format("~/DetailsImages/{0}_{1}.{2}", obj.ServiceInformationId.Value.ToString(), obj.Id.ToString(), obj.FileExt);
                    }
                    else
                    {
                        url.Visible = false;
                        file.Visible = false;
                        img.Visible = false;
                        lnkImg.Visible = false;
                    }

                    if (obj.InfoTypeId.HasValue)
                    {
                        ddlInfoType.Items.FindByValue(obj.InfoTypeId.Value.ToString()).Selected = true;
                        FillInfoType();
                    }

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
            ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
            var obj = _ServiceDetailsManager.GetAllInfoType();
            if (obj != null)
            {
                ddlInfoType.DataTextField = "Name";
                ddlInfoType.DataValueField = "Id";
                ddlInfoType.DataSource = obj.ToList();
            }
            ddlInfoType.DataBind();
        }
        private void ClearData()
        {
            txtInformationContent.Text = String.Empty;
            ddlInfoType.SelectedIndex = 0;
            ucAlertMessage.Clear();
        }
        private void UploadImage(int id, string svcInfoId, string folder)
        {
            try
            {
                if (FileUpload.HasFile == true)
                {
                    //if (FileUploadImages.PostedFile.ContentLength > ImageMaxSize)
                    //{
                    //    string s = "يجب أن لا يتجاوز حجم الملف عن " + (ImageMaxSize / 1024).ToString() + " MB";
                    //    ucMsg.statusMsg(s, msgtyp.error);
                    //}
                    //else
                    //{

                    string appPath = HttpContext.Current.Request.ApplicationPath;
                    string physicalPath = HttpContext.Current.Request.MapPath(appPath);
                    string folderName = (folder == "3" ? "DetailsImages" : "DetailsFiles");
                    string ImagesFolderPath = physicalPath + "\\" + folderName;
                    if (!Directory.Exists(ImagesFolderPath)) Directory.CreateDirectory(ImagesFolderPath);

                    //ImagesFolderPath = ImagesFolderPath + "\\" + svcInfoId;
                    //if (!Directory.Exists(ImagesFolderPath)) Directory.CreateDirectory(ImagesFolderPath); //Directory.Delete(ImagesFolderPath, true);

                    if (!String.IsNullOrEmpty(FileUpload.PostedFile.ToString()))
                    {
                        string ext = Path.GetExtension(FileUpload.PostedFile.FileName);
                        string imgName = FileUpload.FileName;
                        string fileName = svcInfoId + "_" + id + ext; //FileUpload.FileName.Split('.')[1];
                        string imgPath = ImagesFolderPath + "\\" + fileName;

                        if (!String.IsNullOrEmpty(imgPath))
                        {
                            string chkimgPath = imgPath;
                            FileInfo FInfo = new FileInfo(chkimgPath);
                            if (FInfo.Exists) { FInfo.Delete(); }
                        }

                        FileUpload.SaveAs(imgPath);

                        ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
                        DAL.Entity.ServiceDetail obj = _ServiceDetailsManager.GetServiceDetails(id);
                        if (obj != null)
                        {
                            obj.FileExt = ext.Replace(".", "");
                            int i = _ServiceDetailsManager.UpdateServiceDetails(obj);
                        }

                    }
                    //}
                }
            }
            catch (Exception exception)
            {
                exception.Log();
            }
        }
        private void FillInfoType()
        {
            int i = 0;
            if (int.TryParse(ddlInfoType.SelectedValue, out i) && i != 0)
            {
                switch (i)
                {
                    case 1: // Url
                        url.Visible = true;
                        file.Visible = false;
                        img.Visible = false;
                        FileUpload.Visible = false;
                        rfvFileUpload.Enabled = false;
                        revInformationContent.Enabled = true;
                        btnSave.Visible = true;
                        return;
                    case 2: // Pdf
                        url.Visible = false;
                        file.Visible = true;
                        img.Visible = false;
                        FileUpload.Visible = true;
                        rfvFileUpload.Enabled = true;
                        revInformationContent.Enabled = false;
                        btnSave.Visible = true;
                        return;
                    case 3: // Image
                        url.Visible = false;
                        file.Visible = false;
                        img.Visible = true;
                        FileUpload.Visible = true;
                        rfvFileUpload.Enabled = true;
                        revInformationContent.Enabled = false;
                        btnSave.Visible = true;
                        return;
                    default:
                        btnSave.Visible = false;
                        return;
                }
            }
            else
            {
                btnSave.Visible = false;
            }
        }
    }
}
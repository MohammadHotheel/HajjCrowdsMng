using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.UC
{
    public partial class ucServiceInfo : UserControlCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Page.MaintainScrollPositionOnPostBack = true;
                    FillServiceCategory();
                    FillServiceInfo();
                }
                ucServiceDetails.Visible = false;
            }
            catch (Exception exception)
            {
                exception.Log();
            }
        }
        protected void ddlServiceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillServiceInfo();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string un = AspNetSecurityHelper.GetCurrentUserName;
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();

            if (e.CommandName == "Details")
            {
                string Id = e.CommandArgument.ToString();
                int id = 0;
                if (int.TryParse(Id, out id) && id != 0)
                {
                    ucServiceDetails.Visible = true;
                    ucServiceDetails.svcInfoId = id;                    
                    ucServiceDetails.FillServiceDetails();
                    FillServiceInfo();
                }                
            }
        }

        public void FillServiceCategory()
        {
            ServiceCategoryManager _ServiceCategoryManager = new ServiceCategoryManager();
            ddlServiceCategory.DataSource = _ServiceCategoryManager.GetAllServiceCategory();
            ddlServiceCategory.DataTextField = "Name";
            ddlServiceCategory.DataValueField = "Id";
            ddlServiceCategory.DataBind();
        }
        public void FillServiceInfo()
        {
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
            if (queryStringId != 0)
            {
                var data = _ServiceInfoManager.GetAllBySSAId(queryStringId);
                string ServiceCategoryValue = ddlServiceCategory.SelectedItem.Value;
                int ServiceCategoryId = 0;
                if (int.TryParse(ServiceCategoryValue, out ServiceCategoryId) && ServiceCategoryId != 0)
                { data = data.Where(w => w.ServiceCategoryId == ServiceCategoryId).ToList(); }
                var returnData = (from obj in data
                                  select new
                                  {
                                      Id = obj.Id,
                                      Title = obj.Title,
                                      Description = obj.Description,
                                      Section = obj.Section,
                                      Address  = obj.Address,
                                      Longitude = obj.Longitude,
                                      Latitude = obj.Latitude,
                                      ServiceCategory = obj.ServiceCategory.Name,
                                      ServiceDetailsCount = obj.ServiceDetails.Where(w => w.DeletedFlag == false).Count()
                                  }).ToList();
                GridView1.DataSource = returnData;

                var locationData = (from obj in returnData
                                    select new
                                  {
                                      obj.Title,                                      
                                      obj.Longitude,
                                      obj.Latitude,
                                      obj.ServiceCategory
                                  }).ToList();
                ucLocationsMap.Locations = new JavaScriptSerializer().Serialize(locationData); 
            }
            GridView1.DataBind();
        }        
    }
}
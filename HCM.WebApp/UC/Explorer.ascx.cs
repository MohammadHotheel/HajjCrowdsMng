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
    public partial class Explorer : UserControlCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FillServiceCategory();
                }
            }
            catch (Exception exception)
            {
                exception.Log();
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
        public string FillServiceInfo()
        {
            string returnString = "";
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
                                      Title = obj.Title,
                                      Longitude = obj.Longitude,
                                      Latitude = obj.Latitude,
                                      ServiceCategory = obj.ServiceCategory.Name
                                  }).ToList();
                returnString = new JavaScriptSerializer().Serialize(returnData);
            }
            return returnString;
        }
    }
}
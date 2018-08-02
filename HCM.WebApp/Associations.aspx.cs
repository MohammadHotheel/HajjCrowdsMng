using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using HCM.WebApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp
{
    public partial class Associations : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDDL();
                FillData();
            }            
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(ddlState.SelectedValue, out i))
            {
                FillCity(i);
            }
            FillData();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
        protected void ddlServiceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            using (HajjCrawdsMngEntities cntx = new HajjCrawdsMngEntities())
            {
                var obj = (from m in cntx.SaudiStudentAssociations
                           join d in cntx.ServiceInformations
                           on m.Id equals d.SaudiStudentAssociationId into joined
                           from d in joined.DefaultIfEmpty()
                           select new
                           {
                               Id = m.Id,
                               m.StateId,
                               m.CityId,
                               d.ServiceCategoryId
                           }).ToList();

                string stateValue = ddlState.SelectedItem.Value;
                int stateId = 0;
                if (int.TryParse(stateValue, out stateId) && stateId != 0)
                {
                    obj = obj.Where(w => w.StateId == stateId).ToList();
                }
                string city = ddlCity.SelectedItem.Value;
                int cityid = 0;
                if (int.TryParse(city, out cityid) && cityid != 0)
                {
                    obj = obj.Where(w => w.CityId == cityid).ToList();
                }
                string svcCat = ddlServiceCategory.SelectedItem.Value;
                int svcCatId = 0;
                if (int.TryParse(svcCat, out svcCatId) && svcCatId != 0)
                {
                    obj = obj.Where(w => w.ServiceCategoryId == svcCatId).ToList();
                }
                if (obj != null)
                {
                    List<int> ids = obj.Select(ss => ss.Id).Distinct().ToList();
                    var data = (from m in cntx.SaudiStudentAssociations
                                where ids.Contains(m.Id)
                                select new
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    m.StateId,
                                    m.CityId,
                                    University = (m.University != null ? m.University.Name : ""),
                                    State = (m.State != null ? m.State.Name : ""),
                                    City = (m.City != null ? m.City.Name : ""),
                                    m.ZipCode,
                                    ServiceCount = m.ServiceInformations.Where(w=> w.DeletedFlag == false).Count()
                                }).Distinct().ToList();
                    rptdata.DataSource = data;
                }
            }
            rptdata.DataBind();
        }
        public void FillDDL()
        {
            StateManager _StateManager = new StateManager();
            ddlState.DataSource = _StateManager.GetAllState();
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "Id";
            ddlState.DataBind();

            ServiceCategoryManager _ServiceCategoryManager = new ServiceCategoryManager();
            ddlServiceCategory.DataSource = _ServiceCategoryManager.GetAllServiceCategory();
            ddlServiceCategory.DataTextField = "Name";
            ddlServiceCategory.DataValueField = "Id";
            ddlServiceCategory.DataBind();
        }
        private void FillCity(int i)
        {
            ddlCity.Items.Clear();
            CityManager _CityManager = new CityManager();
            var city = _CityManager.GetAllByStateId(i);
            if (city != null)
            {
                ddlCity.Items.Add(new ListItem((String)GetGlobalResourceObject("HCMResource", "AllCity"), "0"));

                ddlCity.DataTextField = "Name";
                ddlCity.DataValueField = "Id";
                ddlCity.DataSource = city.ToList();
            }
            ddlCity.DataBind();
        }
    }
}
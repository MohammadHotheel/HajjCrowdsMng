using HCM.WebApp.BLL.Base;
using HCM.WebApp.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp
{
    public partial class Navigation : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDDL();
                if (queryStringId != 0)
                {
                    ddlState.Items.FindByValue(queryStringId.ToString()).Selected = true;
                }
            }
            FillData();
        }
        public void FillDDL()
        {
            StateManager _StateManager = new StateManager();
            ddlState.DataSource = _StateManager.GetAllState();
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "Id";
            ddlState.DataBind();
        }
        private void FillData()
        {
            SSAManager _SSAManager = new SSAManager();
            string stateValue = ddlState.SelectedItem.Value;
            int stateId = 0;
            var obj = _SSAManager.GetAllSSA().ToList();

            if (int.TryParse(stateValue, out stateId) && stateId != 0)
            {
                obj = obj.Where(w => w.StateId == stateId).ToList();                
            }
            if (obj != null)
            {
                var data = from tbl in obj
                           select new
                           {
                               tbl.Name,
                               University = tbl.University.Name,
                               State = tbl.State.Name,
                               City = tbl.City.Name,
                               tbl.ZipCode,
                               ServiceCount = tbl.ServiceInformations.Where(w=> w.DeletedFlag ==false).Count()
                           };
                rptdata.DataSource = data;
            }
            rptdata.DataBind();
        }
    }
}
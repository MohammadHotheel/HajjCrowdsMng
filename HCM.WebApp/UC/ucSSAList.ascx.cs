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
    public partial class ucSSAList : UserControlCommon
    {
        public string SvcInfoCount { get; set; }
        public string AssCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            SSAManager _SSAManager = new SSAManager();
            var obj = _SSAManager.GetAllSSA();
            if (obj != null)
            {
                var data = from tbl in obj
                           where tbl.DeletedFlag == false
                           select new
                           {
                               tbl.Id,
                               tbl.Name,
                               University = (tbl.University != null ? tbl.University.Name : ""),
                               State = (tbl.State != null ? tbl.State.Name : ""),
                               City = (tbl.City != null ? tbl.City.Name : ""),
                               tbl.ZipCode,
                               tbl.Phone,
                               tbl.Fax,
                               tbl.Email,
                               tbl.Website,
                               tbl.SocialInfo,
                               tbl.Street,
                               ServiceCount = tbl.ServiceInformations.Where(w=> w.DeletedFlag ==false).Count()
                           };
                //rptdata.DataSource = data;
                AssCount = obj.Count().ToString();
            }
            else
            { AssCount = "0"; }
            //rptdata.DataBind();

            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
            var svc = _ServiceInfoManager.GetAllServiceInfo().Where(w => w.DeletedFlag == false);
            if (svc != null)
            { SvcInfoCount = svc.Count().ToString(); }
            else
            { SvcInfoCount = "0"; }
        }
    }
}
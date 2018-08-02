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
    public partial class ucSSA : UserControlCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        private void FillData()
        {
            if (queryStringId != 0)
            {
                SSAManager _SSAManager = new SSAManager();
                var obj = _SSAManager.GetSSA(queryStringId);
                if (obj != null)
                {
                    var objArr = new[] { obj };
                    var data = from tbl in objArr
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
                                   ServiceCount = tbl.ServiceInformations.Where(w => w.DeletedFlag == false).Count(),
                                   tbl.LastUpdatedDate
                               };
                    rptdata.DataSource = data;
                }
            }
            rptdata.DataBind();
        }
    }
}
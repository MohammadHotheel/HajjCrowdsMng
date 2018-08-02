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
    public partial class ucServiceDetails : UserControlCommon
    {
        public int svcInfoId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                exception.Log();
            }
        }

        public void FillServiceDetails()
        {
            ServiceDetailsManager _ServiceDetailsManager = new ServiceDetailsManager();
            if (svcInfoId != 0)
            {
                var data = _ServiceDetailsManager.GetAllByServiceInfoId(svcInfoId);

                var urlData = (from obj in data
                               where obj.InfoTypeId == 1
                               select obj).ToList();

                var fileData = (from obj in data
                                where obj.InfoTypeId == 2
                                select obj).ToList();

                var imgData = (from obj in data
                               where obj.InfoTypeId == 3
                               select obj).ToList();

                rptUrl.DataSource = urlData;
                //divLink.Visible = (urlData.Count != 0);
                rptFile.DataSource = fileData;
                //divFile.Visible = (fileData.Count != 0);
                rptImg.DataSource = imgData;
                //divImg.Visible = (imgData.Count != 0);
            }
            rptUrl.DataBind();
            rptFile.DataBind();
            rptImg.DataBind();
        }
    }
}
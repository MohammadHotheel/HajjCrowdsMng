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
    public partial class ucFAQ : UserControlCommon
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
                FAQManager _FAQManager = new FAQManager();
                var obj = _FAQManager.GetAllBySSAId(queryStringId).ToList();
                if (obj != null)
                { rptData.DataSource = obj; }
            }
            rptData.DataBind();
        }
    }
}
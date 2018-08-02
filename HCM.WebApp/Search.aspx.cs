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
    public partial class Search : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //FillData();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            SSAManager _SSAManager = new SSAManager();
            ServiceInfoManager _ServiceInfoManager = new ServiceInfoManager();
            string str = txtSearch.Text;
            if (!String.IsNullOrEmpty(str))
            {
                using (HajjCrawdsMngEntities cntx = new HajjCrawdsMngEntities())
                {
                    var obj = (from m in cntx.SaudiStudentAssociations
                               join d in cntx.ServiceInformations
                               on m.Id equals d.SaudiStudentAssociationId
                               where (m.Name.Contains(str)) || (m.Email.Contains(str)) || (m.SocialInfo.Contains(str))
                                     || (m.State != null && m.State.Name.Contains(str))
                                     || (m.City != null && m.City.Name.Contains(str))
                                     || (m.University != null && m.University.Name.Contains(str))
                                     || (d != null && d.ServiceCategory != null && d.ServiceCategory.Name.Contains(str))
                                     || (d != null && d.Title.Contains(str))
                               select new
                               {
                                   Id = m.Id,
                                   Name = m.Name,
                                   University = m.University.Name,
                                   State = m.State.Name,
                                   City = m.City.Name,
                                   m.ZipCode,
                                   ServiceCount = m.ServiceInformations.Where(w=>w.DeletedFlag == false).Count()
                               }).Distinct().ToList();
                    if (obj != null)
                    { rptdata.DataSource = obj; }
                }
            }
            rptdata.DataBind();
        }
    }
}
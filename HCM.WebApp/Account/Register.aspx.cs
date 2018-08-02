using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HCM.WebApp.Models;
using HCM.WebApp.BLL.Manager;
using HCM.WebApp.BLL.Base;

namespace HCM.WebApp.Account
{
    public partial class Register : PageCommon
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDDL();
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            int type = 2; // Supervisor
            bool active = false;

            string unv = ddlUniversity.SelectedValue;
            int u = 0;
            if (int.TryParse(unv, out u) && u != 0)
            {
                
            }
            var user = new ApplicationUser()
            {
                UserName = UserName.Text,
                Email = Email.Text,
                FullName = FullName.Text,
                Mobile = Mobile.Text,
                UserTypeId = type,
                Active = active,
                UniversityId = u
            };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void FillDDL()
        {
            UniversityManager _UniversityManager = new UniversityManager();

            var obj = _UniversityManager.GetAllUniversity();
            if (obj != null)
            {
                ddlUniversity.DataTextField = "Name";
                ddlUniversity.DataValueField = "Id";
                ddlUniversity.DataSource = obj.ToList();
            }
            ddlUniversity.DataBind();
        }
    }
}
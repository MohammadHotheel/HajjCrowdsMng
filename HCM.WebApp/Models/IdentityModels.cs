using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HCM.WebApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HCM.WebApp.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        [MaxLength(256)]
        public string FullName { get; set; }
        [MaxLength(10)]
        public string Mobile { get; set; }
        
        public int? UserTypeId { get; set; } // [Administrator, Supervisor]
        public int? UniversityId { get; set; } //
        public bool Active { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

#region Helpers
namespace HCM.WebApp
{
    // AspNetSecurityHelper //
    public static class AspNetSecurityHelper
    {
        public static string GetCurrentUserName
        {
            get
            {
                string un = String.Empty;
                //string un = "dalal@gmail.com";
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        var isActiveDirectoryUser = HttpContext.Current.User.Identity.Name.StartsWith("0#.w|");
                        if (!isActiveDirectoryUser)
                        {
                            un = HttpContext.Current.User.Identity.Name;
                        }
                        else
                        {
                            un = HttpContext.Current.User.Identity.Name.Split('|').Last().Split('\\').Last();
                        }
                    }
                }
                return un;
            }
        }

        private static RoleManager<IdentityRole> _roleManager = null;
        public static RoleManager<IdentityRole> roleManager
        {
            get
            {
                if (_roleManager == null)
                { _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())); }
                return _roleManager;
            }
        }

        private static UserManager<ApplicationUser> _userManager = null;
        public static UserManager<ApplicationUser> userManager
        {
            get
            {
                if (_userManager == null)
                {
                    //_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    ApplicationUserManager aum = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    _userManager = aum;
                }
                return _userManager;
            }
        }

        private static ApplicationUser _currentAppUser = null;
        public static ApplicationUser currentAppUser
        {
            get
            {
                if (userManager != null)
                {
                    _currentAppUser = userManager.FindByName(GetCurrentUserName);
                }
                return _currentAppUser;
            }
        }

        // Application User Services 
        public static List<ApplicationUser> GetAllUsers()
        {
            if (userManager != null && userManager.Users != null && userManager.Users.Count() != 0)
            { return userManager.Users.ToList(); }
            else
            { return null; }
        }
        public static ApplicationUser FindUserById(string userId)
        {
            if (userManager != null)
            { return userManager.FindById(userId); }
            else
            { return null; }
        }
        public static ApplicationUser FindUserByEmail(string userEmail)
        {
            if (userManager != null)
            { return userManager.FindByEmail(userEmail); }
            else
            { return null; }
        }
        public static ApplicationUser FindUserByName(string userName)
        {
            if (userManager != null)
            { return userManager.FindByName(userName); }
            else
            { return null; }
        }

        public static IdentityResult InsertUser(ApplicationUser user, string pw)
        {
            if (userManager != null)
            {
                IdentityResult result = userManager.Create(user, pw);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult UpdateUser(ApplicationUser user)
        {
            if (userManager != null)
            {
                IdentityResult result = userManager.Update(user);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult DeleteUser(ApplicationUser user)
        {
            if (userManager != null)
            {
                IdentityResult result = userManager.Delete(user);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult DeleteUserByUserId(string userId)
        {
            ApplicationUser user = FindUserById(userId);
            if (user != null & userManager != null)
            {
                IdentityResult result = userManager.Delete(user);
                return result;
            }
            else
            { return null; }
        }

        // Role Services 
        public static List<IdentityRole> GetAllRoles()
        {
            if (roleManager != null && roleManager.Roles != null && roleManager.Roles.Count() != 0)
            { return roleManager.Roles.ToList(); }
            else
            { return null; }
        }
        public static IdentityRole FindRoleById(string roleId)
        {
            if (roleManager != null)
            { return roleManager.FindById(roleId); }
            else
            { return null; }
        }
        public static IdentityRole FindRoleByName(string roleName)
        {
            if (roleManager != null)
            { return roleManager.FindByName(roleName); }
            else
            { return null; }
        }

        public static IdentityResult InsertRole(IdentityRole role)
        {
            if (roleManager != null)
            {
                IdentityResult result = roleManager.Create(role);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult UpdateRole(IdentityRole role)
        {
            if (roleManager != null)
            {
                IdentityResult result = roleManager.Update(role);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult DeleteRole(IdentityRole role)
        {
            if (roleManager != null)
            {
                IdentityResult result = roleManager.Delete(role);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult DeleteRoleByRoleId(string roleId)
        {
            IdentityRole role = FindRoleById(roleId);
            if (role != null && roleManager != null)
            {
                IdentityResult result = roleManager.Delete(role);
                return result;
            }
            else
            { return null; }
        }

        // User Roles Services
        public static List<IdentityUserRole> FindUserRolesByRoleId(string roleId)
        {
            IdentityRole role = FindRoleById(roleId);
            if (role != null)
            { return role.Users.ToList(); }
            else
            { return null; }
        }
        public static List<IdentityUserRole> FindUserRolesByUserId(string userId)
        {
            IdentityUser user = FindUserById(userId);
            if (user != null)
            { return user.Roles.ToList(); }
            else
            { return null; }
        }
        public static List<ApplicationUser> FindAllUsersByRoleId(string roleId)
        {
            var allUsers = GetAllUsers();
            if (allUsers != null)
            {
                var users = allUsers.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleId));
                return users.ToList();
            }
            else
            { return null; }
        }
        public static List<IdentityRole> FindAllRolesByUserId(string userId)
        {
            var allRoles = GetAllRoles();
            if (allRoles != null)
            {
                var roles = allRoles.Where(x => x.Users.Select(y => y.UserId).Contains(userId));
                return roles.ToList();
            }
            else
            { return null; }
        }

        public static IdentityResult InsertUserToRole(string userId, string roleId)
        {
            var user = FindUserById(userId);
            var role = FindRoleById(roleId);
            if (user != null && role != null && userManager != null)
            {
                IdentityResult result = userManager.AddToRole(user.Id, role.Name);
                return result;
            }
            else
            { return null; }
        }
        public static IdentityResult DeleteUserFromRole(string userId, string roleId)
        {
            var user = FindUserById(userId);
            var role = FindRoleById(roleId);
            if (user != null && role != null && userManager != null)
            {
                IdentityResult result = userManager.RemoveFromRole(user.Id, role.Name);
                return result;
            }
            else
            { return null; }
        }
    }

    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion

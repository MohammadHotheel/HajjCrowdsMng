using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCM.WebApp.Startup))]
namespace HCM.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

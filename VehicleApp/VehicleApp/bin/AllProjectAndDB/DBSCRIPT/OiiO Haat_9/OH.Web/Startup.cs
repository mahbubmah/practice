using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OH.Web.Startup))]
namespace OH.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

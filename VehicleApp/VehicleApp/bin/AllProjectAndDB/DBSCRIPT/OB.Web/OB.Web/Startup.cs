using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OB.Web.Startup))]
namespace OB.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

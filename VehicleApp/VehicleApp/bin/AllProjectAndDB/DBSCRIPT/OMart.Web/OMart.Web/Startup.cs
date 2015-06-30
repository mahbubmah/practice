using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OMart.Web.Startup))]
namespace OMart.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

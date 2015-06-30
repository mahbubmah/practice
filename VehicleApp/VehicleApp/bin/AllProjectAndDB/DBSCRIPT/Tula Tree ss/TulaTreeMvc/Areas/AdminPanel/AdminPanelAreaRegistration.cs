using System.Linq.Expressions;
using System.Web.Mvc;

namespace TulaTreeMvc.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}",
                new { controller = "Admin", action = "Default" }
            );
        }
    }
}

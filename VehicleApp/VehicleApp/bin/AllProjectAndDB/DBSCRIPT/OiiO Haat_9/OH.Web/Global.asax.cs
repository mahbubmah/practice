using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Configuration;
using System.Collections;

namespace OH.Web
{
    public class Global : HttpApplication
    {
        private static int totalNumberOfUsers = 0;
        private static int currentNumberOfUsers = 0;
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            //Application.Lock();
            totalNumberOfUsers += 1;
            currentNumberOfUsers += 1;
            //Application.UnLock();
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            //Application.Lock();
            currentNumberOfUsers -= 1;
            //Application.UnLock();
        }

        public static int TotalNumberOfUsers
        {
            get
            {
                return totalNumberOfUsers;
            }
            set
            {
                totalNumberOfUsers = value;
            }
        }

        public static int CurrentNumberOfUsers
        {
            get
            {
                return currentNumberOfUsers;
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Response.Write("Error encountered.");
        }

    }
}
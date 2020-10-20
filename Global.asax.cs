using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.net_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("loggedin", 0);
            HttpContext.Current.Session.Add("loggedin_admin", 0);


            HttpContext.Current.Session.Add("userid", 0);

            HttpContext.Current.Session.Add("userfname", null);
            HttpContext.Current.Session.Add("userlname", null);
            HttpContext.Current.Session.Add("promotion", null);

            HttpContext.Current.Session.Add("userid_foraskhim", 0);


            HttpContext.Current.Session.Add("question_id", 0);


        }
    }
}

using System.Web.Mvc;
using System.Web.Routing;

namespace Catalogue_Produit_App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}

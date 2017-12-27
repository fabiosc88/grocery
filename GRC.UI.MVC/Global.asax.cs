using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GRC.UI.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SimpleInjectorConfig.Config();

            //Registrar os mapeamentos de Models/Entidade de Domínio
            AutoMapperConfig.RegisterMappings();

            //Format Decimal Values
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}

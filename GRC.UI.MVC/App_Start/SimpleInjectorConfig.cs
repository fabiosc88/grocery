using Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace GRC.UI.MVC
{
    public class SimpleInjectorConfig
    {
        public static void Config()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // 2. Configure the container (register)
            // Register your types, for instance using the scoped lifestyle:
            BootStrapper.Resolve(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //Check the container
            container.Verify();

            // 4. Register the container as MVC IDependencyResolver.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using PayrollApi.Data;

namespace PayrollApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<DbContextOracle>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityDependencyResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

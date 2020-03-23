
using System.Web.Http;
using Owin;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;


namespace leonasa.Tools.SelfHostWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            appBuilder.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(SelfHostWebApi.Configuration.Container))
                {
                    await next();
                }
            });

            var config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SelfHostWebApi.Configuration.Container)
            };
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            //TODO: FIND PACKAGE
            //appBuilder.UseWebApi(config);
        }
    }
}
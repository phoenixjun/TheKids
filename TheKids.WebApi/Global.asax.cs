using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace TheKids.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IocConfig.RegisterComponents(GlobalConfiguration.Configuration);

        }
    }
}

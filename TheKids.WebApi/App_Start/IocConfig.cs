using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TheKids.Domain.Interfaces;
using TheKids.Infrastructure.Storage.EF;

namespace TheKids.WebApi
{
    public static class IocConfig
    {
        public static void RegisterComponents(HttpConfiguration configuration)
        {
            var container = new ContainerBuilder();

            container.RegisterType<TheKidsDbContext>().As<IUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();

            container.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            container.RegisterWebApiFilterProvider(configuration);

            var newContainer = container.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(newContainer);
        }

    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheKids.Website.Startup))]
namespace TheKids.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

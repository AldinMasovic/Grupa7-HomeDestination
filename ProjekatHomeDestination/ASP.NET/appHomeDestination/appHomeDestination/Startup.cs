using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(appHomeDestination.Startup))]
namespace appHomeDestination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

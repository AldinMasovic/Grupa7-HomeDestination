using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeDestination.Startup))]
namespace HomeDestination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

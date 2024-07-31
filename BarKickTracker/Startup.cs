using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarKickTracker.Startup))]
namespace BarKickTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

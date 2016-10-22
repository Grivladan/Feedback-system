using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecallSystem.WebHost.Startup))]
namespace RecallSystem.WebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

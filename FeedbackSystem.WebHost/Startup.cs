using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeedbackSystem.WebHost.Startup))]
namespace FeedbackSystem.WebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

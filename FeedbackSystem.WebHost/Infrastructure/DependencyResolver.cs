using FeedbackSystem.Logic.Interfaces;
using FeedbackSystem.Logic.Services;
using Ninject.Modules;

namespace FeedbackSystem.WebHost.Infrastructure
{
    public class WebHostModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IFeedbackService>().To<FeedbackService>();
        }
    }
}
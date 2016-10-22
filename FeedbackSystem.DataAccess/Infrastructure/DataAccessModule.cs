using FeedbackSystem.DataAccess.EF;
using FeedbackSystem.DataAccess.Interfaces;
using FeedbackSystem.DataAccess.Repository;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace FeedbackSystem.DataAccess.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().ToFactory();
            Bind<ApplicationDbContext>().ToSelf();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}

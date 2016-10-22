using FeedbackSystem.DataAccess.EF;
using FeedbackSystem.DataAccess.Repository;
namespace FeedbackSystem.DataAccess.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(ApplicationDbContext context) where T : class, IEntity; 
    }
}

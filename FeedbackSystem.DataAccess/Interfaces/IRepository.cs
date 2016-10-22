using FeedbackSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackSystem.DataAccess.Repository
{
    public interface IRepository<T> where T:class, IEntity 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

        IQueryable<T> Query { get; }
    }
}

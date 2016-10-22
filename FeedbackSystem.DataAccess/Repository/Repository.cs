using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FeedbackSystem.DataAccess.Repository
{
    class Repository<T> : IRepository<T> where T: class, IEntity
    {
        private readonly IdentityDbContext<ApplicationUser> _context;
        private DbSet<T> _entities;

        public Repository(IdentityDbContext<ApplicationUser> context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Query.ToList();
        }

        public T GetById(int id)
        {
            return Query.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException("item");
                Entities.Add(item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException("item");
                _context.Entry(item).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Remove(entity);
            }
            catch(Exception ex){
                throw ex;
            }
        }

        protected IDbSet<T> Entities {
            get { return _entities ??( _entities = _context.Set<T>()); }
        }

        public IQueryable<T> Query
        {
            get { return Entities;  }
        }

    }
}

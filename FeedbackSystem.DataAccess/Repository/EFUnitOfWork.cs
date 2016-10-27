using FeedbackSystem.DataAccess.EF;
using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace FeedbackSystem.DataAccess.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private bool _isDisposed;
        private readonly IRepositoryFactory _repositoryFactory;

        public EFUnitOfWork(ApplicationDbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        private UserManager<ApplicationUser> _manager;
        private IRepository<Feedback> _feedbacksRepository;
        private IRepository<Vote> _likesRepository;

        public UserManager<ApplicationUser> UserManager
        {
            get
            {
                return _manager ?? (_manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context)));
            }
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                return _feedbacksRepository ?? (_feedbacksRepository = _repositoryFactory.CreateRepository<Feedback>(_context));
            }
        }

        public IRepository<Vote> Likes
        {
            get
            {
                return _likesRepository ?? (_likesRepository = _repositoryFactory.CreateRepository<Vote>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _manager.Dispose();
                }
            }

            _isDisposed = false;
        }
    }
}

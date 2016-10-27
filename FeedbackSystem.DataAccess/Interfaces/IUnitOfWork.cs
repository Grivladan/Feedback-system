using System;
using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Repository;
using Microsoft.AspNet.Identity;

namespace FeedbackSystem.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Feedback> Feedbacks { get;}
        IRepository<Vote> Likes { get; }
        UserManager<ApplicationUser> UserManager { get; }

        void Save();
    }
}

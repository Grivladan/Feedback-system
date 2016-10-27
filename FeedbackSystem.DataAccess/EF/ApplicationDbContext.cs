using Microsoft.AspNet.Identity.EntityFramework;
using FeedbackSystem.DataAccess.Entities;
using System.Data.Entity;

namespace FeedbackSystem.DataAccess.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {}

        public DbSet<Feedback> Feedbacks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

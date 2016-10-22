using Microsoft.AspNet.Identity.EntityFramework;
using FeedbackSystem.DataAccess.Entities;

namespace FeedbackSystem.DataAccess.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

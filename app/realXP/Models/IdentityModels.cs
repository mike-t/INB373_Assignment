using Microsoft.AspNet.Identity.EntityFramework;

namespace realxp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<realxp.venue> venues { get; set; }

        public System.Data.Entity.DbSet<realxp.seat> seats { get; set; }

        public System.Data.Entity.DbSet<realxp.camera> cameras { get; set; }

        public System.Data.Entity.DbSet<realxp.user> users { get; set; }

        public System.Data.Entity.DbSet<realxp.venue_review> venue_review { get; set; }
    }
}
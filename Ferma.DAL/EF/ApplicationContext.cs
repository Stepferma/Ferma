using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ferma.DAL.Entities;

namespace Ferma.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("name=DefaultConnection") { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Farms> Farms { get; set; }  
        public DbSet<Stocks> Stocks { get; set; }
    }
}

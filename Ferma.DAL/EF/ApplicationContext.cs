using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ferma.DAL.Entities;

namespace Ferma.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("name=DefaultConnection") { }

        public DbSet<UsersProfiles> UsersProfiles { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Farms> Farms { get; set; }  
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<TypeBuildings> TypeBuildings { get; set; }
        public DbSet<Cells> Cells { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}

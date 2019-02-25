using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ferma.DAL.Entities;

namespace Ferma.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("name=DefaultConnection") { }

        public DbSet<ClientProfile> ClientProfile { get; set; }
    }
}

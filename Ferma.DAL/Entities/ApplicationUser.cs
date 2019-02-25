using Microsoft.AspNet.Identity.EntityFramework;

namespace Ferma.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}

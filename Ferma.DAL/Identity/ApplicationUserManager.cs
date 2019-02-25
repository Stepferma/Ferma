using Ferma.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace Ferma.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}

using Ninject.Modules;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.BLL.Services;

namespace Ferma.Modules
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceUsers<UserDTO>>().To<UserService>();
        }
    }
}
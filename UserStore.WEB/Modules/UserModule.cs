using Ninject.Modules;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;

namespace UserStore.Modules
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<UserDTO>>().To<UserService>();
        }
    }
}
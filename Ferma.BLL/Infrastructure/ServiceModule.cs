using Ninject.Modules;
using Ferma.DAL.Interfaces;
using Ferma.DAL.Repositories;

namespace Ferma.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.BLL.Services;
using Ninject.Modules;

namespace Ferma.Modules
{
    public class TypeBuildModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<TypeBuildingsDTO>>().To<TypeBuildingService>();
        }
    }
}
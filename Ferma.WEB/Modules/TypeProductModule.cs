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
    public class TypeProductModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IService<TypeProductsDTO>>().To<TypeProductsService>();
        }
    }
}
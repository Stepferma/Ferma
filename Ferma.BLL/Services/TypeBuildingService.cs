using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Ferma.BLL.Services
{
    public class TypeBuildingService : IService<TypeBuildingsDTO>
    {
        IUnitOfWork Database { get; set; }

        public TypeBuildingService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(TypeBuildingsDTO typeBuildingDTO)
        {
            TypeBuildings typeBuilding = new TypeBuildings
            {
                BuildTime=typeBuildingDTO.BuildTime,
                IdTypeBuilding=typeBuildingDTO.IdTypeBuilding,
                Name=typeBuildingDTO.Name,
                Price=typeBuildingDTO.Price
            };

            Database.TypeBuildings.Create(typeBuilding);

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public TypeBuildingsDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var typeBuildings = Database.TypeBuildings.GetID(id);
            if (typeBuildings == null)
            {
                return null;
            }
            return new TypeBuildingsDTO {
                IdTypeBuilding = typeBuildings.IdTypeBuilding,
                IdTypeProduct = typeBuildings.IdTypeProduct,
                Name = typeBuildings.Name,
                Price = typeBuildings.Price,
                BuildTime = typeBuildings.BuildTime
            };
        }

        public IEnumerable<TypeBuildingsDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeBuildings, TypeBuildingsDTO>()).CreateMapper();
            var typeBuilding = mapper.Map<IEnumerable<TypeBuildings>, List<TypeBuildingsDTO>>(Database.TypeBuildings.GetAll());
            return typeBuilding;
        }
    }
}

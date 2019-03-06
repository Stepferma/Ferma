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

namespace Ferma.BLL.Services
{
    public class BuildingService : IService<BuildingDTO>
    {
        IUnitOfWork Database { get; set; }
        public BuildingService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(BuildingDTO buildingDTO)
        {
            Buildings building = new Buildings()
            {
                IdBuilding = buildingDTO.IdBuilding,
                IdTypeBuilding = buildingDTO.IdTypeBuilding,
                IsActive = buildingDTO.IsActive
            };
            Database.Buildings.Create(building);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public BuildingDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var building = Database.Buildings.GetID(id);
            if (building == null)
            {
                return null;
            }
            return new BuildingDTO { IdBuilding = building.IdBuilding, IdTypeBuilding = building.IdTypeBuilding, IsActive = building.IsActive };
        }
        public IEnumerable<BuildingDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Buildings, BuildingDTO>()).CreateMapper();
            var buildings = mapper.Map<IEnumerable<Buildings>, List<BuildingDTO>>(Database.Buildings.GetAll());
            return buildings;
        }
    }
}

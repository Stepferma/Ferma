using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.Services
{
    public class FarmService : IService<FarmDTO>
    {
        IUnitOfWork Database { get; set; }

        public FarmService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(FarmDTO farmDTO)
        {
            Farms farm = new Farms
            {
                IdFarm = farmDTO.IdFarm,
                IdPlayer = farmDTO.IdPlayer,
                IdStock = farmDTO.IdStock
            };

            Database.Farms.Create(farm);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public FarmDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var farm = Database.Farms.GetID(id);
            if (farm == null)
            {
                return null;
            }
            return new FarmDTO { IdPlayer = farm.IdPlayer, IdFarm = farm.IdFarm, IdStock = farm.IdStock };
        }

        public IEnumerable<FarmDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Farms, FarmDTO>()).CreateMapper();
            var farm = mapper.Map<IEnumerable<Farms>, List<FarmDTO>>(Database.Farms.GetAll());
            return farm;
        }
    }
}

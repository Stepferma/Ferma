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
    public class FiledService : IService<FieldDTO>
    {
        IUnitOfWork Database { get; set; }

        public FiledService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void BeginBuilding(BuildingDTO building)
        {

        }
        public void Create(FieldDTO fieldDTO)
        {
            Fields field = new Fields
            {
                IdBuilding = fieldDTO.IdBuilding,
                IdFarm = fieldDTO.IdFarm,
                IdField = fieldDTO.IdField
            };

            Database.Fields.Create(field);
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public FieldDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var field = Database.Fields.GetID(id);
            if (field == null)
            {
                return null;
            }
            return new FieldDTO { IdBuilding = field.IdBuilding, IdFarm = field.IdFarm, IdField = field.IdField };
        }
        public IEnumerable<FieldDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Fields, FieldDTO>()).CreateMapper();
            var field = mapper.Map<IEnumerable<Fields>, List<FieldDTO>>(Database.Fields.GetAll());
            return field;
        }
    }
}

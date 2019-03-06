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
    public class FieldService : IService<FieldDTO>
    {
        IUnitOfWork Database { get; set; }

        public FieldService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public bool BeginBuilding(int idField, int idTypeBuilding,string idUser)
        {
            TypeBuildings type = Database.TypeBuildings.Find(tb => tb.IdTypeBuilding == idTypeBuilding).FirstOrDefault();
            Fields field = Database.Fields.Find(f => f.IdField == idField).FirstOrDefault();
            Players player = Database.Players.Find(p => p.IdUser == idUser).FirstOrDefault();
            if (player.Money < type.Price)
            {
                return false;
            }  
            else
            {
                Buildings building = new Buildings()
                {
                    IdTypeBuilding = type.IdTypeBuilding,
                    IsActive = false,
                    DateStart = DateTime.Now
                };
                Database.Buildings.Create(building);
                field.IdBuilding = building.IdBuilding;
                return true;
            }
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

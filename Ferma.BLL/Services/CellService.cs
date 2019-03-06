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
    public class CellService : IService<CellDTO>
    {
        IUnitOfWork Database { get; set; }
        public CellService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(CellDTO cellDTO)
        {
            Cells cell = new Cells()
            {
                IdCell = cellDTO.IdCell,
                IdProduct = cellDTO.IdProduct,
                IdField = cellDTO.IdField,
                IsActive = cellDTO.IsActive
            };
            Database.Cells.Create(cell);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public CellDTO GetID(int id)
        {
            Cells cell = Database.Cells.GetID(id);
            return new CellDTO()
            {
                IdCell = cell.IdCell,
                IdField = cell.IdField,
                IdProduct = cell.IdProduct,
                DateStart = cell.DateStart,
                IsActive = cell.IsActive
            };
        }

        public IEnumerable<CellDTO> GetList()
        {
            IMapper mapper = new MapperConfiguration(config => config.CreateMap<Cells, CellDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Cells>, List<CellDTO>>(Database.Cells.GetAll());
        }

        public void IsActive(ProductDTO product)
        {
            Cells cell = Database.Cells.Find(x => x.IdProduct == product.IdProduct).FirstOrDefault();

            TimeSpan isReady = cell.DateStart - DateTime.Now;
            if (isReady.TotalMinutes > product.BuildTime)
            {
                cell.IsActive = true;
            }
        } 
    }
}

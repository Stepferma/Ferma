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
            throw new NotImplementedException();
        }

        public CellDTO GetID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CellDTO> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

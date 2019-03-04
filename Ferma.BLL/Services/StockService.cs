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
    public class StockService : IService<StockDTO>
    {

        IUnitOfWork Database { get; set; }

        public StockService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(StockDTO stockDTO)
        {
            Stocks stock = new Stocks
            {
                IdPlayer = stockDTO.IdPlayer,
                IdStock = stockDTO.IdStock,
                Meat = stockDTO.Meat,
                Millet = stockDTO.Millet,
                Corn = stockDTO.Corn,
                Eggs = stockDTO.Eggs

            };

            Database.Stocks.Create(stock);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public StockDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var stock = Database.Stocks.GetID(id);
            if (stock == null)
            {
                return null;
            }
            return new StockDTO { IdPlayer = stock.IdPlayer,  Corn= stock.Corn,IdStock= stock.IdStock,Eggs= stock.Eggs,Meat= stock.Meat,Millet= stock.Millet };
        }

        public IEnumerable<StockDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stocks, StockDTO>()).CreateMapper();
            var stock = mapper.Map<IEnumerable<Stocks>, List<StockDTO>>(Database.Stocks.GetAll());
            return stock;
        }
    }
}

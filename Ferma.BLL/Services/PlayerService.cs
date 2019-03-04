using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ferma.BLL.Services
{
    public class PlayerService : IService<PlayerDTO>
    {

        IUnitOfWork Database { get; set; }
        public PlayerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(PlayerDTO playerDTO)
        {
 
            //Players plsyer = new Players { Money=playerDTO.Money,IdUser=Use}
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PlayerDTO GetID(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerDTO> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

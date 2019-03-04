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
    public class PlayerService : IService<PlayerDTO>
    {

        IUnitOfWork Database { get; set; }
        public PlayerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(PlayerDTO playerDTO)
        {

            Players player = new Players
            {
                Money = playerDTO.Money,
                IdUser = playerDTO.IdUser
            };

            Database.Players.Create(player);

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public PlayerDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var player = Database.Players.GetID(id);
            if (player == null)
            {
                return null;
            }
            return new PlayerDTO { IdPlayer = player.IdPlayer, IdUser = player.IdUser, Money = player.Money};
        }

        public IEnumerable<PlayerDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Players, PlayerDTO>()).CreateMapper();
            var player = mapper.Map<IEnumerable<Players>, List<PlayerDTO>>(Database.Players.GetAll());
            return player;
        }
    }
}

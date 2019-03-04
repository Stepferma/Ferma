using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Infrastructure;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace Ferma.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(UserDTO userDTO)
        {
            ApplicationUser user =  Database.UserManager.FindById(userDTO.Id);
            if (user != null)
            {
                UsersProfiles Client = new UsersProfiles
                {
                    UserName = userDTO.UserName,
                    ApplicationUser = user,
                    Password = userDTO.Password,
                    Email = user.Email,
                    Id = user.Id
                };
                Database.Users.Create(Client);
                Players player = new Players { IdUser = user.Id, Money = 500 };
                Database.Players.Create(player);
                player = Database.Players.Find(i => i.IdUser == user.Id).FirstOrDefault();
                Stocks stock = new Stocks { Eggs = 0, Meat = 0, Millet = 0,Corn = 0 , IdPlayer = player.IdPlayer};
                Database.Stocks.Create(stock);
                stock = Database.Stocks.Find(i => i.IdPlayer == player.IdPlayer).FirstOrDefault();
                Farms farm = new Farms {IdPlayer = player.IdPlayer, IdStock = stock.IdStock};
                Database.Farms.Create(farm);
                farm = Database.Farms.Find(i => i.IdPlayer == player.IdPlayer).FirstOrDefault();
                Fields field = new Fields {IdBuilding = 0, IdFarm = farm.IdFarm};
                Database.Fields.Create(field);
                Database.Save();              
            } 
        }

        public IEnumerable<UserDTO> GetList()
        {
            var asd = Database.Users.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersProfiles, UserDTO>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UsersProfiles>, List<UserDTO>>(Database.Users.GetAll());
            return users;
        }

        public UserDTO GetID(string id)
        {
            if (id == null)
            {
                return null;
            }

            var user = Database.Users.GetID(id);
            if (user == null) { 
                return null;
            }  
            return new UserDTO { UserName = user.UserName, Id = user.Id, Password = user.ApplicationUser.PasswordHash, Email = user.ApplicationUser.Email};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
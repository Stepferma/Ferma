using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Infrastructure;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<OperationDetails> Create(UserDTO userDTO)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser { UserName = userDTO.UserName, Email = userDTO.Email, PasswordHash = userDTO.Password};
                Users Client = new Users
                {
                    UserName = userDTO.UserName,
                    ApplicationUser = user,
                    Id = user.Id
                };
                Database.Users.Create(Client);
                Database.Save();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public IEnumerable<UserDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetID(string id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона");
            var user = Database.Users.GetID(id);
            if (user == null)
                throw new ValidationException("Телефон не найден");

            return new UserDTO { UserName = user.UserName, Id = user.Id, Password = user.ApplicationUser.PasswordHash, Email = user.ApplicationUser.Email};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
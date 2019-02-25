using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.BLL.Services
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
                ClientProfile Client = new ClientProfile
                {
                    UserName = userDTO.UserName,
                    ApplicationUser = user,
                    Id = user.Id
                };
                Database.ClientProfile.Create(Client);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ClientProfile>, List<UserDTO>>(Database.ClientProfile.GetAll());
        }

        public UserDTO GetID(string id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона");
            var user = Database.ClientProfile.GetID(id);
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
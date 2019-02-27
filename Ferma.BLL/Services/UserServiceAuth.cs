using System;
using Ferma.BLL.DTO;
using Ferma.BLL.Infrastructure;
using Ferma.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Ferma.BLL.Interfaces;
using System.Collections.Generic;
using Ferma.DAL.Interfaces;

namespace Ferma.BLL.Services
{
    public class UserServiceAuth : IUserServiceAuth
    {
        IUnitOfWorkAuth Database { get; set; }

        public UserServiceAuth(IUnitOfWorkAuth uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName, PasswordHash = userDto.Password};
                await Database.UserManager.CreateAsync(user, userDto.Password);

                // await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                UsersProfiles clientProfile = new UsersProfiles { ApplicationUser = user,Id = user.Id, UserName = userDto.UserName, Password = userDto.Password, Email = userDto.Email};
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if(user!=null)
                claim= await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        //public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        //{
        //    foreach (string roleName in roles)
        //    {
        //        var role = await Database.RoleManager.FindByNameAsync(roleName);
        //        if (role == null)
        //        {
        //            role = new ApplicationRole { Name = roleName };
        //            await Database.RoleManager.CreateAsync(role);
        //        }
        //    }

        //    await Create(adminDto);
        //}
        public void Dispose()
        {
            Database.Dispose();
        }
    }

    
}

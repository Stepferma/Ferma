using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Ferma.BLL.DTO;
using Ferma.BLL.Infrastructure;

namespace Ferma.BLL.Interfaces
{
    public interface IUserServiceAuth : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
     //   Task SetInitialData(UserDTO adminDto, List<string> roles);
    } 
}

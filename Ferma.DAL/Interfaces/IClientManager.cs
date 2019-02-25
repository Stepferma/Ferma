using Ferma.DAL.Entities;
using System;

namespace Ferma.DAL.Interfaces
{
    public interface IClientManager:IDisposable
    {
        void Create(ClientProfile user);
    }
}

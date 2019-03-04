﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ferma.BLL.Infrastructure;

namespace Ferma.BLL.Interfaces
{
    public interface IService<T>
    {
        void Create(T userDTO);
        T GetID(int id);
        IEnumerable<T> GetList();
        void Dispose();
    }
}
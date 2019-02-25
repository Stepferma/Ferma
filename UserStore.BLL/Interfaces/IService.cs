using System.Collections.Generic;
using System.Threading.Tasks;
using UserStore.BLL.Infrastructure;

namespace UserStore.BLL.Interfaces
{
    public interface IService<T>
    {
        Task<OperationDetails> Create(T userDTO);
        T GetID(string id);
        IEnumerable<T> GetList();
        void Dispose();
    }
}
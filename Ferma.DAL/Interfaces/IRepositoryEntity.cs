using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Interfaces
{
    public interface IRepositoryEntity<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetID(int Id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}

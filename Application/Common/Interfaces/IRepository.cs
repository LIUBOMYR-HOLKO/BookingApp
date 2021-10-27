using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T item);
        Task Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        void Update(T item);
    }
}

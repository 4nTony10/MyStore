using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public interface IRepo<T>
    {
        void Save();
        T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T data);
        void Update(T data);
        void Remove(int id);
    }
}

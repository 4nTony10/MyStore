using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataManager
{
    public interface IDataManager<T>
    {
        void Save(T data);
        T Load();
    }
}

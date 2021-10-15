using DAL.DataManager;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ElectronicsRepo : IRepo<Electronics>
    {
        IDataManager<IEnumerable<Electronics>> manager;
        IEnumerable<Electronics> electros;

        public ElectronicsRepo(IDataManager<IEnumerable<Electronics>> manager)
        {
            this.manager = manager;
            electros = manager.Load() ?? new List<Electronics>();
        }
        public void Create(Electronics data)
        {
            (electros as List<Electronics>).Add(data);
        }

        public Electronics Get(int id)
        {
            return electros.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Electronics> GetAll()
        {
            return electros;
        }

        public void Remove(int id)
        {
            Electronics el = Get(id);
            (electros as List<Electronics>).Remove(el);
        }

        public void Save()
        {
            manager.Save(electros);
        }

        public void Update(Electronics data)
        {
            Electronics el = Get(data.Id);
            el = data;
        }
    }
}

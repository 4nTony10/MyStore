using AutoMapper;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;

namespace BAL.Services
{
    class ElectronicsService : IService<ElectronicsBAL>
    {
        IRepo<Electronics> repository;
        IMapper mapper;

        public ElectronicsService(IRepo<Electronics> repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Electronics, ElectronicsBAL>();
                cfg.CreateMap<ElectronicsBAL, Electronics>();
            });

            mapper = config.CreateMapper();
        }

        public void Create(ElectronicsBAL data)
        {
            Electronics el = mapper.Map<Electronics>(data);
            repository.Create(el);
        }

        public ElectronicsBAL Get(int id)
        {
            Electronics el = repository.Get(id);
            return mapper.Map<ElectronicsBAL>(el);
        }

        public IEnumerable<ElectronicsBAL> GetAll()
        {
            return repository.GetAll().Select(x => mapper.Map<ElectronicsBAL>(x));
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Save()
        {
            repository.Save();
        }

        public void Update(ElectronicsBAL data)
        {
            Electronics el = mapper.Map<Electronics>(data);
            repository.Update(el);
        }
    }
}

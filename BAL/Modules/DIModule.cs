using BAL.Models;
using BAL.Services;
using DAL.DataManager;
using DAL.Models;
using DAL.Repos;
using DAL.DataManager.JSON;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Modules
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataManager<IEnumerable<Electronics>>>().To<JSONMG>();

            Bind<IRepo<Electronics>>().To<ElectronicsRepo>();

            Bind<IService<ElectronicsBAL>>().To<ElectronicsService>();

        }
    }
}

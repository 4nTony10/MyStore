using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataManager.JSON
{
    public class JSONMG : IDataManager<IEnumerable<Electronics>>
    {
        public IEnumerable<Electronics> Load()
        {
            if (!File.Exists("Electronics.json"))
                return null;

            string json = File.ReadAllText("Electronics.json");
            return JsonConvert.DeserializeObject<IEnumerable<Electronics>>(json);
        }

        public void Save(IEnumerable<Electronics> data)
        {
            if(!File.Exists("Electronics.json"))
                File.Create("Electronics.json");

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("Electronics.json", json);
        }
    }
}

using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataManager.TXT
{
    public class TXTMGI : IDataManager<IEnumerable<Electronics>>
    {
        public void Save(IEnumerable<Electronics> data)
        {
            List<string> lines = new List<string>();
            foreach (var item in data)
                lines.Add($"{item.Id};{item.Name};{item.Description};{item.Information};" +
                    $"{item.ImagePath};{item.Rating};{item.Price}");

            if (!File.Exists("Electronics.txt"))
                File.CreateText("Electronics.txt");

            File.WriteAllLines("Electronics.txt", lines);
        }

        IEnumerable<Electronics> IDataManager<IEnumerable<Electronics>>.Load()
        {
            if (!File.Exists("Electronics.txt"))
                return null;

            List<string> lines = File.ReadAllLines("Electronics.txt").ToList();
            List<Electronics> electros = new List<Electronics>();

            foreach (var line in lines)
            {
                string[] str = line.Split(';');
                electros.Add(new Electronics
                {
                    Id = Convert.ToInt32(str[0]),
                    Name = str[1],
                    Description = str[2],
                    Information = str[3],
                    ImagePath = str[4],
                    Price = Convert.ToInt32(str[6]),
                    Rating = Convert.ToByte(str[5])
                });
            }

            return electros;
        }
    }
}

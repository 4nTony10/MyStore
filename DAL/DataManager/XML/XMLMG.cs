using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.DataManager.XML
{
    public class XMLMG : IDataManager<IEnumerable<Electronics>>
    {
        public IEnumerable<Electronics> Load()
        {
            if (!File.Exists("Electronics.xml"))
                return null;

            List<Electronics> electronics = new List<Electronics>();

            foreach (var elem in XDocument.Load(@"Electronics.xml").Root.Elements())
            {
                Electronics electro = new Electronics();

                electro.Id = Convert.ToInt32(elem.Element("Id").Value);
                electro.Name = elem.Element("Name").Value;
                electro.Information = elem.Element("Information").Value;
                electro.Description = elem.Element("Description").Value;
                electro.ImagePath = elem.Element("ImagePath").Value;
                electro.Rating = Convert.ToByte(elem.Element("Rating").Value);
                electro.Price = Convert.ToInt32(elem.Element("Price").Value);

                electronics.Add(electro);
            }

            return electronics;
        }

        public void Save(IEnumerable<Electronics> data)
        {
            if (!File.Exists("Electronics.xml"))
                Directory.CreateDirectory("Electronics.xml");

            XDocument doc = new XDocument();

            XElement electronics = new XElement("Electronics");

            foreach (var elem in data)
            {
                XElement electro = new XElement("Electronic");

                electro.Add(new XElement("Id", elem.Id));
                electro.Add(new XElement("Name", elem.Name));
                electro.Add(new XElement("Information", elem.Information));
                electro.Add(new XElement("Description", elem.Description));
                electro.Add(new XElement("ImagePath", elem.ImagePath));
                electro.Add(new XElement("Rating", elem.Rating));
                electro.Add(new XElement("Price", elem.Price));

                electronics.Add(electro);
            }

            doc.Add(electronics);
            doc.Save("Departments.xml");
        }
    }
}


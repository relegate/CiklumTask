using CiklumTask.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CiklumTask.Modules.ItemsParser
{
    public class ParserJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string url = @"https://fashionup.ua/api.php?act=pages&format=1";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)httpRequest.GetResponse();

            var receiveStream = response.GetResponseStream();

            var sourceDocument = new XmlDocument();
            sourceDocument.Load(receiveStream);
            XDocument document = XDocument.Parse(sourceDocument.OuterXml);

            List<Product> products = (from d in document.Descendants("offer")
                                      select new Product
                                      {
                                          Id = int.Parse(d.Attribute("id").Value),
                                          name = d.Element("name").Value,
                                          desc = d.Element("description").Value,
                                          currency = d.Element("currencyId").Value,
                                          price = int.Parse(d.Element("price").Value),
                                          model = d.Element("model").Value,
                                          color = d.Element("color").Value,
                                          brand = d.Element("param").Attribute("name").Parent.Value,
                                          Pics = (from p in d.Elements("picture").ToList()
                                                  select new Pics
                                                  {
                                                      id_product = int.Parse(d.Attribute("id").Value),
                                                      url_pic = p.Value
                                                  }).ToList(),
                                          Price = new HashSet<Price>() { new Price {
                                              id_product = int.Parse(d.Element("price").Value),
                                              date = DateTime.Now
                                          } }
                                      }).ToList();    
            receiveStream.Close();

            ItemsHandler itemsHandler = new ItemsHandler();
            itemsHandler.SaveItems(products);
        }
    }
}
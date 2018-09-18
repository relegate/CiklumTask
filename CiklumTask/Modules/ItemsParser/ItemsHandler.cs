using CiklumTask.Models;
using CiklumTask.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Hosting;

namespace CiklumTask.Modules.ItemsParser
{
    public class ItemsHandler
    {
        private IUnitOfWork db;

        public ItemsHandler()
        {
            db = new UnitOfWork();
        }

        public ItemsHandler(IUnitOfWork db)
        {
            this.db = db;
        }

        public void SaveItems(List<Product> products)
        {
            List<Product> exist = db.ProductRepository.GetAll().ToList();

            foreach (var item in products)
            {
                if (exist.Contains(item))
                {
                        db.PriceRepository.Add(new Price { id_product = item.Id, date = DateTime.Now, price = item.price });
                        db.Save();
                }
                else if (item.Pics != null)
                {
                    foreach (var img in item.Pics)
                    {
                        WebClient webClient = new WebClient();
                        string imageName = Path.GetFileNameWithoutExtension(img.url_pic.Substring(img.url_pic.LastIndexOf('/') + 1));
                        string path = HostingEnvironment.MapPath("~/Content/Images/Items/" + imageName + ".jpg");
                        webClient.DownloadFile(img.url_pic, path);
                        img.url_pic = "/Content/Images/Items/" + imageName + ".jpg";
                    }
                }
            }
            products = products.Except(exist).ToList();
            db.ProductRepository.Add(products);
            db.Save();
        }
    }
}
using CiklumTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CiklumTask.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private ShopEntities db;

        public ProductRepository(ShopEntities context)
        {
            db = context;
        }

        public void Add(Product item)
        {
            db.Product.Add(item);
        }

        public void Add(IEnumerable<Product> items)
        {
            db.Product.AddRange(items);
        }

        public void Delete(int id)
        {
            Product item = db.Product.Find(id);
            if (item != null)
                db.Product.Remove(item);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product.ToList();
        }

        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
using CiklumTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CiklumTask.Repository
{
    public class PriceRepository : IRepository<Price>
    {
        private ShopEntities db;

        public PriceRepository(ShopEntities context)
        {
            db = context;
        }

        public void Add(Price item)
        {
            db.Price.Add(item);
        }

        public void Add(IEnumerable<Price> items)
        {
            db.Price.AddRange(items);
        }

        public void Delete(int id)
        {
            Price item = db.Price.Find(id);
            if (item != null)
                db.Price.Remove(item);
        }

        public IEnumerable<Price> GetAll()
        {
            return db.Price.ToList();
        }

        public Price Get(int id)
        {
            return db.Price.Find(id);
        }

        public void Update(Price item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
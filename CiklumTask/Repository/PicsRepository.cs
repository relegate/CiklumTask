using CiklumTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CiklumTask.Repository
{
    public class PicsRepository : IRepository<Pics>
    {
        private ShopEntities db;

        public PicsRepository(ShopEntities context)
        {
            db = context;
        }

        public void Add(Pics item)
        {
            db.Pics.Add(item);
        }

        public void Add(IEnumerable<Pics> items)
        {
            db.Pics.AddRange(items);
        }

        public void Delete(int id)
        {
            Pics item = db.Pics.Find(id);
            if (item != null)
                db.Pics.Remove(item);
        }

        public IEnumerable<Pics> GetAll()
        {
            return db.Pics.ToList();
        }

        public Pics Get(int id)
        {
            return db.Pics.Find(id);
        }

        public void Update(Pics item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
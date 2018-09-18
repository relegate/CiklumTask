using CiklumTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiklumTask.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ShopEntities db = new ShopEntities();
        private ProductRepository productRepository { get; }
        private PicsRepository picsRepository { get; }
        private PriceRepository priceRepository { get; }

        IRepository<Product> IUnitOfWork.ProductRepository => new ProductRepository(db);

        IRepository<Pics> IUnitOfWork.PicsRepository => new PicsRepository(db);

        IRepository<Price> IUnitOfWork.PriceRepository => new PriceRepository(db);

        public void Save()
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
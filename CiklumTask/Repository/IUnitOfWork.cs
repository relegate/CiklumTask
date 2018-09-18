using CiklumTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiklumTask.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Pics> PicsRepository { get; }
        IRepository<Price> PriceRepository { get; }

        void Save();
    }
}

namespace CiklumTask.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopEntities : DbContext
    {
        public ShopEntities()
            : base("name=ShopEntities")
        {
        }

        public virtual DbSet<Pics> Pics { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Pics)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.id_product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Price)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.id_product);
        }
    }
}

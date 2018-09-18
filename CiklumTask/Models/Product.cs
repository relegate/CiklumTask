namespace CiklumTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Pics = new HashSet<Pics>();
            Price = new HashSet<Price>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        public string desc { get; set; }

        [StringLength(50)]
        public string currency { get; set; }

        public double? price { get; set; }

        [StringLength(100)]
        public string model { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        [StringLength(500)]
        public string brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pics> Pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Price { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Id == product.Id &&
                   name == product.name &&
                   desc == product.desc &&
                   currency == product.currency &&
                   model == product.model &&
                   color == product.color &&
                   brand == product.brand;
        }

        public override int GetHashCode()
        {
            var hashCode = -1116584104;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(desc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(currency);
            hashCode = hashCode * -1521134295 + EqualityComparer<double?>.Default.GetHashCode(price);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(color);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(brand);
            return hashCode;
        }
    }
}

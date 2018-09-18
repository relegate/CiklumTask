namespace CiklumTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Price")]
    public partial class Price
    {
        public int Id { get; set; }

        public int? id_product { get; set; }

        [Column("price")]
        public double? price { get; set; }

        public DateTime? date { get; set; }

        public virtual Product Product { get; set; }
    }
}

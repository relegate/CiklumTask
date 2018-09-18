namespace CiklumTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PriceVM
    {
        public int Id { get; set; }

        public int? Id_product { get; set; }

        public double? Price { get; set; }

        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }
    }
}

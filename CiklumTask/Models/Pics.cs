namespace CiklumTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pics
    {
        public int Id { get; set; }

        public int? id_product { get; set; }

        public string url_pic { get; set; }

        public virtual Product Product { get; set; }
    }
}

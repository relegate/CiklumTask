namespace CiklumTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PicsVM
    {
        public int Id { get; set; }

        public int? Id_product { get; set; }

        public string Url_pic { get; set; }

        public virtual Product Product { get; set; }
    }
}

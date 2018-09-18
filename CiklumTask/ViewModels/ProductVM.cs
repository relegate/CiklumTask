namespace CiklumTask.ViewModels
{
    using System.Collections.Generic;

    public class ProductVM
    {
        public ProductVM()
        {
            Images = new List<string>();
        }

        public int Id { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Currency { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public List<string> Images { get; set; }

        public virtual string FrontImage { get; set; }
    }
}

using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccessModel
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Storage { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Display { get; set; }
        public string Details { get; set; }
        public List<ProductPhotoViewModel> Photos { get; set; }
    }
}

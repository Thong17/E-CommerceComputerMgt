using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ListProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string CreatedBy { get; set; }                                      
        public DateTime CreatedDate { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<ProductDetailsViewModel> Products { get; set; }
        public List<ProductPhotoViewModel> Photos { get; set; }
    }
}

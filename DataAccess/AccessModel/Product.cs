using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccessModel
{
    public class Product : ProductBrand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Details { get; set; }
        [Required]
        public List<ProductBrand> Brands { get; set; }
        [Required]
        public List<ProductCategory> Categories { get; set; }
    }
}

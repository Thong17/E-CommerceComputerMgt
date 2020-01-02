using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccessModel
{
    public class ProductBrand : ProductCategory
    {
        public int BrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Details")]
        public string BrandDetails { get; set; }
    }
}

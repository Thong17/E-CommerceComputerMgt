using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccessModel
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Details")]
        public string CategoryDetails { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.ViewModel
{
    public class AddProductDetailsViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Storage { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string Display { get; set; }
        public int ProductId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Upload)]
        public string PhotoPath { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoSrc { get; set; }
    }
}

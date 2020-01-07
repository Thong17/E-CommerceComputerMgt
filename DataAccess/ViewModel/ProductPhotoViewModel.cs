using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ProductPhotoViewModel
    {
        public int Id { get; set; }
        public string PhotoSrc { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoTitle { get; set; }
        public int DetailsId { get; set; }
    }
}

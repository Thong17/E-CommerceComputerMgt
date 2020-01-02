using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceComMgt.ViewModel
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
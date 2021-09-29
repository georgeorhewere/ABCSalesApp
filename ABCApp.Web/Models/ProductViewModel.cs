using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCApp.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }        
        public decimal Price { get; set; }
    }
}

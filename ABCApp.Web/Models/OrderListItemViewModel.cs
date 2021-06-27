using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCApp.Web.Models
{
    public class OrderListItemViewModel
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }        
        public string Country { get; set; }        
        public string Region { get; set; }        
        public string City { get; set; }        
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Date Of Sale")]
        public DateTime DateOfSale { get; set; }        
        public string Product { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("Total Sale")]
        public decimal TotalSale { get; set; }
    }
}

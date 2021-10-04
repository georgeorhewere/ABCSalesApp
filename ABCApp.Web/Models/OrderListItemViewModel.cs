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
        public OrderListItemViewModel()
        {
            Quantity = 1;
        }
        public int ProductId { get; set; }        
        public string Name { get; set; }      
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get { return UnitPrice * Quantity; } }
    }
}

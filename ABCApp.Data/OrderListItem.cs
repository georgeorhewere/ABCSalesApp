using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data
{
    [Keyless]
    public class OrderListItem
    {
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSale { get; set; }
        public string Product { get; set; }
        public decimal TotalSale { get; set; }
    }
}

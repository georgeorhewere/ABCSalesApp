using System;

namespace ABCApp.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSale { get; set; }
        public decimal OrderTotal { get; set; }
        public int RegionId { get; set; }
        public int CityCode { get; set; }
        public int CountryId { get; set; }        
        
    }
}
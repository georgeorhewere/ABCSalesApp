using System.Collections.Generic;

namespace ABCApp.Data
{
    public class City
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }        
        public string RegionCode { get; set; }
        public ICollection<Order> OrdersList { get; set; }
    }
}
using System.Collections.Generic;

namespace ABCApp.Data
{
    public class City
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }        
        public int RegionId { get; set; }
        public ICollection<Order> OrdersList { get; set; }
    }
}
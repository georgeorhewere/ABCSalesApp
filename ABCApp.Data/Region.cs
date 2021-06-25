using System.Collections.Generic;

namespace ABCApp.Data
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string CountryCode { get; set; }
        public ICollection<City> CityList { get; set; }
        public ICollection<Order> OrdersList { get; set; }
    }
}
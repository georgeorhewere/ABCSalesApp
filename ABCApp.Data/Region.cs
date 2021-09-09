using System.Collections.Generic;

namespace ABCApp.Data
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public int CountryId { get; set; }
        public ICollection<City> CityList { get; set; }
        public ICollection<Order> OrdersList { get; set; }
    }
}
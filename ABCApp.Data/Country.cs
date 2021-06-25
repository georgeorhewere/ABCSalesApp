using System.Collections.Generic;

namespace ABCApp.Data
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public ICollection<Region> RegionList { get; set; }
        public ICollection<Order> OrdersList { get; set; }
    }
}
using ABCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Service.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Region> GetRegions(int countryCode);
        IEnumerable<City> GetCities(int regionCode);
    }
}

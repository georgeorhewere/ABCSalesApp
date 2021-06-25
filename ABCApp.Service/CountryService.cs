using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Service
{
    public class CountryService : ICountryService
    {
        private IRepository abcRepository;
        public CountryService(IRepository _abcRepository)
        {
            abcRepository = _abcRepository;
        }
        public IEnumerable<City> GetCities(string regionCode)
        {
            return abcRepository.GetRegionCities(regionCode);
        }

        public IEnumerable<Country> GetCountries()
        {
            return abcRepository.GetCountries();
        }

        public IEnumerable<Region> GetRegions(string countryCode)
        {
            return abcRepository.GetCountryRegions(countryCode);
        }
    }
}

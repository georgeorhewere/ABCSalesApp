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
        private ICountryRepository countryRepository;
        public CountryService(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }
        public IEnumerable<City> GetCities(string regionCode)
        {
            try
            {
                return countryRepository.GetRegionCities(regionCode);
            }
            catch (Exception ex)
            {

                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Cities", ErrorOn = DateTime.UtcNow };
                //abcRepository.SaveError(errorObj);
                return new List<City>();
            }
        }

        public IEnumerable<Country> GetCountries()
        {
            try
            {
                return countryRepository.GetCountries();
            }
            catch (Exception ex)
            {

                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Countries", ErrorOn = DateTime.UtcNow };
               // abcRepository.SaveError(errorObj);
                return new List<Country>();
            }
        }

        public IEnumerable<Region> GetRegions(string countryCode)
        {
            try
            {
                // check country coe is valid
                // if not valid return empty list
                // if valid return list

                return countryRepository.GetCountryRegions(countryCode);
            }
            catch (Exception ex)
            {
                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Regions", ErrorOn = DateTime.UtcNow };
                // abcRepository.SaveError(errorObj);
                return new List<Region>();
            }
        }

    }
}

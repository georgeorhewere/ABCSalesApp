using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCApp.Tests.Mocks.Repositories
{
    public class MockCountryRepository : Mock<ICountryRepository>
    {

        private readonly List<Country> countries = new()
        {
            new Country { CountryId = 1, CountryCode="AF", CountryName= "Afghanistan" },
            new Country { CountryId = 2, CountryCode = "AL", CountryName = "Albania" },
            new Country { CountryId = 3, CountryCode = "BY", CountryName = "Belarus" },
            new Country { CountryId = 4, CountryCode = "BE", CountryName = "Belguim" },
            new Country { CountryId = 5, CountryCode = "CM", CountryName = "Cameroon" },
        };

        private readonly List<Region> regions = new()
        {
            new Region { RegionId = 1, CountryId =1, RegionName= "Badakhshan" },
            new Region { RegionId = 2, CountryId = 1, RegionName= "Badgis" },
            new Region { RegionId = 3, CountryId = 2, RegionName= "Bulqize" },
            new Region { RegionId = 4, CountryId = 2, RegionName= "Delvine" },
            new Region { RegionId = 5, CountryId = 5, RegionName= "La Massana" },
        };
               

        private readonly List<City> cities = new()
        {
            new City { CityCode = 1, RegionId = 1, CityName = "Eshkashem" },
            new City { CityCode = 2, RegionId = 1, CityName = "Fayzabad" },
            new City { CityCode = 3, RegionId = 4, CityName = "Balkh" },
            new City { CityCode = 4, RegionId = 4, CityName = "Dawlatabad" },
            new City { CityCode = 5, RegionId = 5, CityName = "Maymanah" },
            new City { CityCode = 6, RegionId = 5, CityName = "Shahrak" },
        };

        public MockCountryRepository MockGetCountries()
        {
            Setup(x => x.GetCountries())
                .Returns(countries);

            return this;
        }

        public MockCountryRepository VerifyGetCountries(Times times)
        {
            Verify(x => x.GetCountries(), times);
            return this;
        }

        public MockCountryRepository MockGetRegions(int countryId)
        {
            Setup(x => x.GetCountryRegions(It.IsAny<int>()))
                .Returns(regions.Where(r => r.CountryId == countryId).ToList());

            return this;
        }

    }
}

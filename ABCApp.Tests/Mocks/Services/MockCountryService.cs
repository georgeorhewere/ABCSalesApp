using ABCApp.Service.Interfaces;
using ABCApp.Tests.Mocks.Repositories;
using Moq;
using System;

namespace ABCApp.Tests.Mocks.Services
{
    public class MockCountryService : Mock<ICountryService>
    {

        public MockCountryService MockGetCountries()
        {
            var mockCountryRepo = new MockCountryRepository().MockGetCountries();
            Setup(x => x.GetCountries())
                .Returns(mockCountryRepo.Object.GetCountries());

            return this;
        }


        public MockCountryService VerifyGetCountries(Times times)
        {
            Verify(x => x.GetCountries(), times);
            return this;
        }


        public MockCountryService MockGetRegions(int countryId)
        {
            var mockCountryRepo = new MockCountryRepository()
                .MockGetRegions(countryId);

            Setup(x => x.GetRegions(It.IsAny<int>()))
                .Returns(mockCountryRepo.Object.GetCountryRegions(countryId));

            return this;
        }

        public MockCountryService MockGetCities(int regionId)
        {
            var mockCountryRepo = new MockCountryRepository()
                    .MockGetCities(regionId);

            Setup(x => x.GetCities(It.IsAny<int>()))
                .Returns(mockCountryRepo.Object.GetRegionCities(regionId));

            return this;
        }
    }
}

﻿using ABCApp.Service.Interfaces;
using ABCApp.Tests.Mocks.Repositories;
using Moq;


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
    }
}

using System;
using Xunit;
using System.IO;
using System.Linq;
using ABCApp.Tests.Mocks.Repositories;
using ABCApp.Service;
using System.Collections.Generic;
using ABCApp.Data;
using Moq;

namespace ABCApp.Tests.Services
{
    public class CountryServiceTests
    {
        [Fact]
        public void CountryService_GetCountries_ReturnsList()
        {
            //Arrange - set up the repo and service
            var countryMockRepo = new MockCountryRepository().MockGetCountries();
            var countryService = new CountryService(countryMockRepo.Object);

            //Act
            var countries = countryService.GetCountries();

            // Assert

            // not empty
            Assert.NotEmpty(countries);
            
            // is List of Countries
            Assert.IsType<List<Country>>(countries);
            
            // count =5
            Assert.Equal(5, countries.Count());
            
            //verify called -- may not needed in this case
            countryMockRepo.VerifyGetCountries(Times.Once());
        }


    }
}

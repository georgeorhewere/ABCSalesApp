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


        [Fact]
        public void CountryService_GetRegions_ReturnsEmptyListForInvalidId()
        {
            // Arrange
            int testCountryId = 7;
            var countryMockRepo = new MockCountryRepository()
                                        .MockGetRegions(testCountryId);
            var countryService = new CountryService(countryMockRepo.Object);

            // Act
            // invalid Id -- 7
            var regions = countryService.GetRegions(testCountryId);
            //Assert
            Assert.Empty(regions);

        }

        [Fact]
        public void CountryService_GetRegions_ReturnsListForValidId()
        {
            // Arrange
            int testCountryId = 1;
            var countryMockRepo = new MockCountryRepository()
                                        .MockGetRegions(testCountryId);
            var countryService = new CountryService(countryMockRepo.Object);

            // Act
            // valid Id -- 1
            var regions = countryService.GetRegions(testCountryId);

            //Assert
            //Not empty
            Assert.NotEmpty(regions);
            // return 2 states
            Assert.Equal(2, regions.Count());
            //type is list of region
            Assert.IsType<List<Region>>(regions);

        }

        [Fact]
        public void CountryService_GetCities_ReturnsEmptyListForInvalidId()
        {
            //Arrange
            int testRegionId = 9;
            var countryMockRepository = new MockCountryRepository()
                                                    .MockGetCities(testRegionId);

            var countryService = new CountryService(countryMockRepository.Object);

            //Act
            var cities = countryService.GetCities(testRegionId);

            //Assert
            // Empty list
            Assert.Empty(cities);
        }

        [Fact]
        public void CountryService_GetCities_ReturnsList_Of2Items_ForValidId()
        {
            //Assert
            var regionId = 4;
            var mockCountryRepository = new MockCountryRepository()
                                                .MockGetCities(regionId);
            var countryService = new CountryService(mockCountryRepository.Object);

            //Act
            var cities = countryService.GetCities(regionId);

            //Arrange
            // not empty
            Assert.NotEmpty(cities);
            // type of cities
            Assert.IsType<List<City>>(cities);
            // count is 2
            Assert.Equal(2, cities.Count());

        }


    }
}

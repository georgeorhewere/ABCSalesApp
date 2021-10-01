using ABCApp.Tests.Mocks;
using ABCApp.Tests.Mocks.Services;
using ABCApp.Web.Controllers;
using ABCApp.Web.Models;
using Moq;
using System.Linq;
using Xunit;


namespace ABCApp.Tests.Controller
{
    public class CountryControllerTests
    {
        [Fact]
        public void CountryController_Countries_ReturnsDropDownViewModel()
        {
            // Arrange set up service
            var mockCountryServiice = new MockCountryService().MockGetCountries();
            var countryController = new CountryController(mockCountryServiice.Object);

            // Act
            var countries = countryController.Countries();

            //Assert
            // is dropdown view model type
            Assert.IsType<DropDownViewModel>(countries);
            // contains country list
            Assert.NotEmpty(countries.Results);
            // status is true
            Assert.True(countries.Success);
            // count of countries = 5
            Assert.Equal(5, countries.Results.Count());



        }

        }
}

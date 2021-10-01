using ABCApp.Service.Interfaces;
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
    }
}

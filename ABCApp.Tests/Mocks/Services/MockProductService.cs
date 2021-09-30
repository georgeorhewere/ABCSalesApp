using ABCApp.Service.Interfaces;
using ABCApp.Tests.Mocks.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Tests.Mocks
{
    public class MockProductService : Mock<IProductService>
    {

        public MockProductService MockGetProducts()
        {
            var mockProductRepo = new MockProductRepository().MockGetProducts();
            Setup(x => x.GetProducts())
                .Returns(mockProductRepo.Object.GetProducts());

            return this;
        }



    }
}

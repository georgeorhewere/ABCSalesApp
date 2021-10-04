﻿using ABCApp.Service.Interfaces;
using ABCApp.Tests.Mocks.Repositories;
using Moq;

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

        public MockProductService VerifyGetProducts(Times times)
        {
            Verify(x => x.GetProducts(), times);
            return this;
        }

        public MockProductService MockGetProductById(int productId) {

            var mockProductrepo = new MockProductRepository().MockGetProductById(productId);

            Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(mockProductrepo.Object.GetProductById(productId));

            return this;
        
        
        }

    }
}

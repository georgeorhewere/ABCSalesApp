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
    public class ProductServiceTests
    {
        [Fact]
        public void ProductService_GetProducts_ReturnsList()
        {
            // Arrange -- setup repo and service
            var productRepo = new MockProductRepository()
                                        .MockGetProducts();

            var productService = new ProductService(productRepo.Object);

            // Act 
            var products = productService.GetProducts();

            //Assert 
            //isList
            Assert.IsType<List<Product>>(products);
            // count = 5
            Assert.NotEmpty(products);
            Assert.Equal(5, products.Count());

            // Verify
            productRepo.VerifyGetProducts(Times.Once());

                                        
        }


        [Fact]
        public void ProductService_GetProductById_ReturnsNullForInvalidId()
        {
            // arrange
            int invalidProductId = 7;
            var mockProductRepo = new MockProductRepository().MockGetProductById(invalidProductId);
            var productService = new ProductService(mockProductRepo.Object);

            // act
            var product = productService.GetProductById(invalidProductId);

            //assert
            // is null 
            Assert.Null(product);

        }


        [Fact]
        public void ProductService_GetProductById_ReturnsProductForValidId()
        {
            // arrange
            int productId = 2;
            var mockProductRepo = new MockProductRepository()
                                           .MockGetProductById(productId);
            var productService = new ProductService(mockProductRepo.Object);

            // act
            var product = productService.GetProductById(productId);

            // assert
            // not null
            Assert.NotNull(product);
            // type is product
            Assert.IsType<Product>(product);
            // confirm Id
            Assert.Equal(2, product.ProductId);

        }


    }
}

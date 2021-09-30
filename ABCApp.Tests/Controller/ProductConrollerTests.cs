using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using ABCApp.Tests.Mocks;
using ABCApp.Web.Controllers;
using ABCApp.Web.Models;

namespace ABCApp.Tests.Controller
{
    public class ProductConrollerTests
    {

        [Fact]
        public void ProductController_Index_ReturnsProductViewModels()
        {
            // Arrange
            var productService = new MockProductService().MockGetProducts();
            var productController = new ProductController(productService.Object);

            // Act
            var products = productController.Index();

            //Assert
            //Not Empty
            Assert.NotEmpty(products);
            // product view model type 
            Assert.IsType<List<ProductViewModel>>(products);

            //count = 5
            Assert.Equal(5, products.Count());
            // verify called
            productService.VerifyGetProducts(Times.Once());

        }
    }
}

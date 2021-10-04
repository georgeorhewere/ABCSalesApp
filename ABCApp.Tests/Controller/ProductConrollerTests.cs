using ABCApp.Tests.Mocks;
using ABCApp.Web.Controllers;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

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
            Assert.NotEmpty(products.Results);
            // product view model type 
            Assert.IsType<DropDownViewModel>(products);

            //count = 5
            Assert.Equal(5, products.Results.Count());
            // verify called
            productService.VerifyGetProducts(Times.Once());

        }


        [Fact]
        public void ProductController_ProductById_ReturnsPartialView_ForValidId()
        {
            // arrange
            int productId = 1;
            var mockProductService = new MockProductService()
                                            .MockGetProductById(productId);

            var productController = new ProductController(mockProductService.Object);

            //act
            var result = (PartialViewResult)productController.ProductById(productId);

            //assert
            Assert.Equal("_OrderItem", result.ViewName);
            Assert.IsType<OrderListItemViewModel>(result.ViewData.Model);
            Assert.Equal(1, ((OrderListItemViewModel)result.ViewData.Model).ProductId);

        }
    }
}

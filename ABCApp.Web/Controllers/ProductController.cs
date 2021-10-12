using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ABCApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        // GET: /Products/
        public DropDownViewModel Index()
        {
            var products = productService.GetProducts()
                                           .Select(x => new DropDownItemViewModel
                                           {
                                               Value= x.ProductId,
                                               Name= x.ProductName,
                                               Text = x.ProductName
                                           })
                                           .ToList();

            return new DropDownViewModel(products, true);
        }


        public IActionResult ProductById(int productId)
        {

            var product = productService.GetProductById(productId);
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                OrderListItemViewModel model = new OrderListItemViewModel()
                {
                    ProductId = product.ProductId,
                    Name = product.ProductName,
                    UnitPrice = product.Price,
                    ItemId = $"{Guid.NewGuid().ToString()}"
                };

                return PartialView("_OrderItem", model);
            }
        }

    }
}

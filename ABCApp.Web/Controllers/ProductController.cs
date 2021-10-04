using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
            OrderListItemViewModel model = new OrderListItemViewModel() 
                                                    {
                                                         ProductId = 24,
                                                         Name = "SkyRun Washing Maching",
                                                         UnitPrice = 23.54m,
                                                         Quantity = 1                                                         
                                                    };


            return PartialView("_OrderItem",model) ;
        }

    }
}

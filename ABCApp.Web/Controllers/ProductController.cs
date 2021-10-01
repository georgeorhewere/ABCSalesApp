using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

using ABCApp.Data;
using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ABCApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        public OrderController(ICountryService _countryService, IProductService _productService, IOrderService _orderService)
        {
            countryService = _countryService;
            productService = _productService;
            orderService = _orderService;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var model = new OrderViewModel();
            model.Countries = countryService.GetCountries()
                                            .Select(x => new SelectListItem { 
                                                                Text = x.CountryName, 
                                                                Value = x.CountryCode })
                                            .ToList();
            model.Products = productService.GetProducts()
                                            .Select(x => new SelectListItem
                                            {
                                                Text = $"{x.ProductName} (${x.Price})",
                                                Value = x.ProductId.ToString()
                                            })
                                            .ToList();


            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Save order
                    Order salesOrder = new Order();
                    salesOrder.CustomerName = collection["CustomerName"];
                    salesOrder.ProductId = Convert.ToInt32(collection["Products"]);
                    salesOrder.Quantity = Convert.ToInt32(collection["Quantity"]);
                    salesOrder.DateOfSale = DateTime.ParseExact(collection["DateOfSale"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    salesOrder.OrderTotal = Convert.ToDecimal(collection["TotalSale"]);
                    salesOrder.CountryCode = collection["Countries"];
                    salesOrder.RegionCode = collection["Regions"];
                    salesOrder.CityCode = Convert.ToInt32(collection["Cities"]);
                    // redirect to index with Id
                    orderService.SaveOrder(salesOrder);
                    return View();
                    // return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetRegions(string countryCode)
        {
            List<SelectListItem> regions = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(countryCode))
            {
                var countryRegions = countryService.GetRegions(countryCode).Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionCode }).ToList();
                regions = regions.Concat(countryRegions).ToList();
            }
            return Json(regions);
        }

        [HttpPost]
        public ActionResult GetCities(string regionCode)
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(regionCode))
            {
                var regionCities = countryService.GetCities(regionCode).Select(x => new SelectListItem { Text = x.CityName, Value = x.CityCode.ToString() }).ToList();
                cities = cities.Concat(regionCities).ToList();
            }

            return Json(cities);
        }

        [HttpPost]
        public ActionResult GetSaleTotal(int productId, int quantity)
        {
            decimal totalSale = 0;
            if(productId != null && productId > 0)
            {
                decimal productPrice = productService.GetProductPrice(productId);
                totalSale = productPrice * quantity;
            }

            return Json(totalSale.ToString());

        }


    }
}

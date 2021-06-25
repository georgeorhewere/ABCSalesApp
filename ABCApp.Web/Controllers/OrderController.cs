using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICountryService countryService;
        public OrderController(ICountryService _countryService)
        {
            countryService = _countryService;
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
            

            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


    }
}

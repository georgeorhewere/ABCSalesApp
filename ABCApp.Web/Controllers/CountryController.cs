using ABCApp.Service.Interfaces;
using ABCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCApp.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;                    
        }

        public DropDownViewModel Countries()
        {
            DropDownViewModel model;
            var countries = countryService.GetCountries().Select(c=> new DropDownItemViewModel
            {
                Text = c.CountryName,
                Value = c.CountryId,
                Name = c.CountryName
            }).ToList();
            model = new DropDownViewModel(countries, true);

            return model;
        }
    }
}

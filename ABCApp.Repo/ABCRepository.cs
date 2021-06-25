using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCApp.Repo
{
    public class ABCRepository : IRepository
    {
        private readonly ABCDbContext context;    
        string errorMessage = string.Empty;

        public ABCRepository(ABCDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Product> GetAll()
        {            
             return context.Products.AsQueryable<Product>();
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.FromSqlRaw("[dbo].[GetCountries]").ToList();
        }

        public IEnumerable<Region> GetCountryRegions(string countryCode)
        {
            return context.Regions.FromSqlRaw($"[dbo].[GetCountryRegions] {countryCode}").ToList();
        }

        public IEnumerable<City> GetRegionCities(string regionCode)
        {
            return context.Cities.FromSqlRaw($"[dbo].[GetRegionCities] {regionCode}").ToList();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

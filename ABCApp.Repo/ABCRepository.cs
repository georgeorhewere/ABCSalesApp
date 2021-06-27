using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
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
        public IEnumerable<Product> GetProducts()
        {            
             return context.Products.FromSqlRaw($"{DbProcedures.LoadProducts}").ToList();
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.FromSqlRaw($"{DbProcedures.LoadCountries}").ToList();
        }

        public IEnumerable<Region> GetCountryRegions(string countryCode)
        {
            return context.Regions.FromSqlRaw($"{DbProcedures.LoadRegions} {countryCode}").ToList();
        }

        public IEnumerable<City> GetRegionCities(string regionCode)
        {
            return context.Cities.FromSqlRaw($"{DbProcedures.LoadCities} {regionCode}").ToList();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.FromSqlRaw($"{DbProcedures.GetProductByID} {productId}").AsEnumerable().FirstOrDefault();
        }
    }
}

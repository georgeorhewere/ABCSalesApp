using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
using Microsoft.Data.SqlClient;
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

        public void InsertOrder(Order entity)
        {
            try
            {
                List<SqlParameter> insertParams = new List<SqlParameter>
                                    { 
                                        // Create parameters    
                                        new SqlParameter { ParameterName = "@CustomerName", Value = entity.CustomerName },
                                        new SqlParameter { ParameterName = "@DateOfSale", Value = entity.DateOfSale },
                                        new SqlParameter { ParameterName = "@ProductId", Value = entity.ProductId },
                                        new SqlParameter { ParameterName = "@Quantity", Value = entity.Quantity },
                                        new SqlParameter { ParameterName = "@OrderTotal", Value = entity.OrderTotal },
                                        new SqlParameter { ParameterName = "@CountryCode", Value = entity.CountryCode },
                                        new SqlParameter { ParameterName = "@RegionCode", Value = entity.RegionCode },
                                        new SqlParameter { ParameterName = "@CityCode", Value = entity.CityCode },
                                        new SqlParameter { ParameterName = "@OrderId", SqlDbType=System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output, Size = Int32.MaxValue }
                                        };                
                int affectedRows = context.Database.ExecuteSqlRaw($"{DbProcedures.SaveOrderInfo} @CustomerName, @DateOfSale, @ProductId, @Quantity, @OrderTotal, @CountryCode, @RegionCode, @CityCode, @OrderId", insertParams.ToArray());

                var OrderId = insertParams.Where(x => x.ParameterName == "@OrderId").FirstOrDefault().Value;

                SaveChanges();
            }
            catch (Exception ex)
            {
                // save exception to error table
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


        }

        private void SaveChanges()
        {
            context.SaveChangesAsync();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.FromSqlRaw($"{DbProcedures.GetProductByID} {productId}").AsEnumerable().FirstOrDefault();
        }
    }
}

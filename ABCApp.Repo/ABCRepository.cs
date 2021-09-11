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
            int countryId = Convert.ToInt32(countryCode);
            return context.Regions.FromSqlRaw($"{DbProcedures.LoadRegions} {countryId}").ToList();
        }

        public IEnumerable<City> GetRegionCities(string regionCode)
        {
            int regionId = Convert.ToInt32(regionCode);
            return context.Cities.FromSqlRaw($"{DbProcedures.LoadCities} {regionId}").ToList();
        }

        public void InsertOrder(Order entity)
        {
            List<SqlParameter> insertParams = new List<SqlParameter>
                                    { 
                                        // Create parameters    
                                        new SqlParameter { ParameterName = "@CustomerName", Value = entity.CustomerName },
                                        new SqlParameter { ParameterName = "@DateOfSale", Value = entity.DateOfSale },
                                        new SqlParameter { ParameterName = "@ProductId", Value = entity.ProductId },
                                        new SqlParameter { ParameterName = "@Quantity", Value = entity.Quantity },
                                        new SqlParameter { ParameterName = "@OrderTotal", Value = entity.OrderTotal },
                                        new SqlParameter { ParameterName = "@CountryCode", Value = entity.CountryId },
                                        new SqlParameter { ParameterName = "@RegionCode", Value = entity.RegionId },
                                        new SqlParameter { ParameterName = "@CityCode", Value = entity.CityCode },
                                        new SqlParameter { ParameterName = "@OrderId", SqlDbType=System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output, Size = Int32.MaxValue }
                                        };
            int savedRows = context.Database.ExecuteSqlRaw($"{DbProcedures.SaveOrderInfo} @CustomerName, @DateOfSale, @ProductId, @Quantity, @OrderTotal, @CountryCode, @RegionCode, @CityCode, @OrderId", insertParams.ToArray());
            var OrderId = insertParams.Where(x => x.ParameterName == "@OrderId").FirstOrDefault().Value;
            SaveChanges();

        }

        private void SaveChanges()
        {
            context.SaveChangesAsync();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.FromSqlRaw($"{DbProcedures.GetProductByID} {productId}").AsEnumerable().FirstOrDefault();
        }

        public void SaveError(DbError error)
        {
            List<SqlParameter> errorParams = new List<SqlParameter>
                                    { 
                                        // Create parameters    
                                        new SqlParameter { ParameterName = "@ErrorDetail", Value = error.ErrorDetail },
                                        new SqlParameter { ParameterName = "@ErrorBy", Value = error.ErrorBy },
                                        new SqlParameter { ParameterName = "@ErrorOn", Value = error.ErrorOn },
                                        };
            int savedRows = context.Database.ExecuteSqlRaw($"{DbProcedures.SaveErrorInfo} @ErrorDetail, @ErrorBy, @ErrorOn", errorParams.ToArray());
            SaveChanges();
        }

        public IEnumerable<OrderListItem> GetOrderItems(string countryCode, string regionCode, int? cityCode, DateTime? salesDate)
        {
            List<SqlParameter> orderItemParams = new List<SqlParameter>
                                    { 
                                        // Create parameters    
                                        new SqlParameter { ParameterName = "@DateOfSale", Value = salesDate.HasValue ? salesDate.Value: DBNull.Value, SqlDbType=System.Data.SqlDbType.DateTime2, IsNullable= true },
                                        new SqlParameter { ParameterName = "@CountryCode", Value = string.IsNullOrEmpty(countryCode) ? DBNull.Value :countryCode , IsNullable= true },
                                        new SqlParameter { ParameterName = "@RegionCode", Value = string.IsNullOrEmpty(regionCode) ? DBNull.Value :regionCode, IsNullable= true },
                                        new SqlParameter { ParameterName = "@CityCode", Value = cityCode.HasValue ? cityCode.Value: DBNull.Value, IsNullable= true },
                                      };
            var results =  context.OrderListItems.FromSqlRaw($"{DbProcedures.GetProductOrders} @DateOfSale, @CountryCode, @RegionCode, @CityCode", orderItemParams.ToArray()).ToList();
            return results;
        }
    }
}

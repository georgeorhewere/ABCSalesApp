using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {        
        public OrderRepository(ABCDbContext _context) : base(_context)
        {
            
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
            var results = context.OrderListItems.FromSqlRaw($"{DbProcedures.GetProductOrders} @DateOfSale, @CountryCode, @RegionCode, @CityCode", orderItemParams.ToArray()).ToList();
            return results;
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
    }
}

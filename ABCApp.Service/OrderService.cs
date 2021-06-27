using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Service
{
    public class OrderService : IOrderService
    {
        private IRepository abcRepository;

        public OrderService(IRepository dbRepository)
        {
            abcRepository = dbRepository;
        }

        public IEnumerable<OrderListItem> GetOrderListItems(int? cityCode, DateTime? salesDate, string countryCode = null, string regionCode = null)
        {
            try
            {
                return abcRepository.GetOrderItems(countryCode, regionCode, cityCode, salesDate);
            }
            catch (Exception ex)
            {

                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Orders", ErrorOn = DateTime.UtcNow };
                abcRepository.SaveError(errorObj);
                return new List<OrderListItem>();
            }

        }

        public bool SaveOrder(Order entity)
        {
            try
            {
                abcRepository.InsertOrder(entity);
                return true;
            }
            catch (Exception ex)
            {
                // save exception to error table                
                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Add Order", ErrorOn = DateTime.UtcNow };
                abcRepository.SaveError(errorObj);
                return false;
            }
        }
    }
}

using ABCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Service.Interfaces
{
    public interface IOrderService
    {
        bool SaveOrder(Order entity);
        IEnumerable<OrderListItem> GetOrderListItems(int? cityCode, DateTime? salesDate, string countryCode = null, string regionCode=null);

    }
}

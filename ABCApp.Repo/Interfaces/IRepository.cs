using ABCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        IEnumerable<Country> GetCountries();
        IEnumerable<Region> GetCountryRegions(string countryCode);
        IEnumerable<City> GetRegionCities(string regionCode);
        IEnumerable<OrderListItem> GetOrderItems(string countryCode, string regionCode, int? cityCode, DateTime? salesDate);
        void InsertOrder(Order entity);
        void SaveError(DbError error);


    }
}

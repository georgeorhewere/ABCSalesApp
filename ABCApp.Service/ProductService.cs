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
    public class ProductService : IProductService
    {
        private IProductRepository abcRepository;        

        public ProductService(IProductRepository dbRepository)
        {
            abcRepository = dbRepository;            
        }

        public decimal GetProductPrice(int productId)
        {
            try
            {
                return abcRepository.GetProductById(productId).Price;
            }
            catch (Exception ex)
            {
                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Product Price", ErrorOn = DateTime.UtcNow };
                //abcRepository.SaveError(errorObj);
                return 0;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return abcRepository.GetProducts();
            }
            catch (Exception ex)
            {

                DbError errorObj = new DbError { ErrorDetail = ex.Message, ErrorBy = "Get Products", ErrorOn = DateTime.UtcNow };
                //abcRepository.SaveError(errorObj);
                return new List<Product>();
            }
        }
    }
}

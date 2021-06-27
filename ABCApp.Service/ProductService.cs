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
        private IRepository abcRepository;        

        public ProductService(IRepository dbRepository)
        {
            abcRepository = dbRepository;            
        }

        public decimal GetProductPrice(int productId)
        {
            return abcRepository.GetProductById(productId).Price;
        }

        public IEnumerable<Product> GetProducts()
        {
            return abcRepository.GetProducts();
        }
    }
}

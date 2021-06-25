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
        public IQueryable<Product> GetProducts()
        {
            return abcRepository.GetAll();
        }
    }
}

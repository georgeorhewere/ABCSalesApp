using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ABCDbContext context;
        public ProductRepository(ABCDbContext _context)
        {
            context = _context;
        }

        public Product GetProductById(int productId)
        {
            return context.Products.FromSqlRaw($"{DbProcedures.GetProductByID} {productId}").AsEnumerable().FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.FromSqlRaw($"{DbProcedures.LoadProducts}").ToList();
        }
    }
}

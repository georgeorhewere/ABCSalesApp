using ABCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        decimal GetProductPrice(int productId);
    }
}

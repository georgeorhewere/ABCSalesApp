using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ABCApp.Tests.Mocks.Repositories
{
    public class MockProductRepository : Mock<IProductRepository>
    {

        private readonly List<Product> products = new() {
                    new Product{ ProductId = 1, ProductName= "IPhone 10" , Price = 599.99m }
                    ,new Product{ ProductId = 2, ProductName= "Lux Premium Shirts" , Price = 5.99m }
                    ,new Product{ ProductId = 3, ProductName= "Binatone Standing Fan" , Price = 12.45m }
                    ,new Product{ ProductId = 4, ProductName= "SkyRun 10kg Washing Machine" , Price = 135.99m }
                    ,new Product{ ProductId = 5, ProductName= "LG 1.5Hp Cooling AC" , Price = 234.99m }
                };

        public MockProductRepository MockGetProducts()
        {
            Setup(x => x.GetProducts())
                .Returns(products);

            return this;
        }

        public MockProductRepository VerifyGetProducts(Times times)
        {
            Verify(x => x.GetProducts(), times);
            return this;
        }

        public MockProductRepository MockGetProductById()
        {
            Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(products.Where(x => It.IsAny<int>() == x.ProductId).FirstOrDefault());

            return this;
        }

        public MockProductRepository VerifyIsValid(Times times)
        {
            Verify(x => x.GetProductById(It.IsAny<int>()), times);

            return this;
        }


    }
}

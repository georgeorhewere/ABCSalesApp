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
        public void SaveOrder(Order entity)
        {
            abcRepository.InsertOrder(entity);
        }
    }
}

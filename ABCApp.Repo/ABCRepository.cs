using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ABCApp.Repo
{
    public class ABCRepository : IRepository
    {
        private readonly ABCDbContext context;    
        string errorMessage = string.Empty;

        public ABCRepository(ABCDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Product> GetAll()
        {
            //throw new NotImplementedException();
             return context.Products.AsQueryable<Product>();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BrandService : IBrandService
    {
        private BookStoreDbContext dbContext;

        public BrandService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Brand> GetBrands()
        {
            var brands = dbContext.Brands.AsNoTracking().ToList();
            return brands;
        }
    }
}

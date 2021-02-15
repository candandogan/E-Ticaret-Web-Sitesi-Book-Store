using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class FakeCategoryService : ICategoryService
    {
        public IList<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {Id=1, Name="Türler"},
                new Category {Id=2, Name="Yayınevleri"},
                new Category {Id=3, Name="Yazarlar"},
                new Category {Id=4, Name="Basım Dili"},
            };
        }
    }
}

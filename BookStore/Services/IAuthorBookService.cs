using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;



namespace BookStore.Services
{
   public interface IAuthorBookService
    {
        List<AuthorBook> GetAuthorBooks();
        List<AuthorBook> GetBooksByAuthorId(int brandId);
    }
}

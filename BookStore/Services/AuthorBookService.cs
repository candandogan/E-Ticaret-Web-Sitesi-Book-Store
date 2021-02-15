using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private BookStoreDbContext dbContext;

        public AuthorBookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<AuthorBook> GetAuthorBooks()
        {
            var authorbooks = dbContext.AuthorBook.AsNoTracking().ToList();
            return authorbooks;
        }

        public List<AuthorBook> GetBooksByAuthorId(int authorId)
        {
            return dbContext.AuthorBook.AsNoTracking().Where(p => p.AuthorId == authorId).ToList();
        }
    }
}

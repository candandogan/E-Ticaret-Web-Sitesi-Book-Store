using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private BookStoreDbContext dbContext;

        public AuthorService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Author> GetAuthors()
        {
            var authors = dbContext.Authors.AsNoTracking().ToList();
            return authors;
        }
    }
}

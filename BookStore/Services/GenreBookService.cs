using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class GenreBookService : IGenreBookService
    {
        private BookStoreDbContext dbContext;

        public GenreBookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GenreBook> GetGenreBooksByGenreId(int genreId)
        {
            return dbContext.GenreBook.AsNoTracking().Where(p => p.GenreId == genreId).ToList();
        }

        public List<GenreBook> GetGenreBooks()
        {
            var genrebooks = dbContext.GenreBook.AsNoTracking().ToList();
            return genrebooks;
        }
    }
}

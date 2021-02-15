using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public interface IGenreBookService
    {
        List<GenreBook> GetGenreBooks();

        List<GenreBook> GetGenreBooksByGenreId(int genreId);
    }
}

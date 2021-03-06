﻿using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class GenreService : IGenreService
    {
        private BookStoreDbContext dbContext;

        public GenreService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Genre> GetGenres()
        {
            var genres = dbContext.Genres.AsNoTracking().ToList();
            return genres;
        }
    }
}

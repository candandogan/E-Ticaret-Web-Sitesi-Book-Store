using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class LanguageService : ILanguageService
    {
        private BookStoreDbContext dbContext;

        public LanguageService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Language> GetLanguages()
        {
            var languages = dbContext.Languages.AsNoTracking().ToList();
            return languages;
        }
    }
}

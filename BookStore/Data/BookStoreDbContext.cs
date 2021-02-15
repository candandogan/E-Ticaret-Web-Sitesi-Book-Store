using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext :DbContext
    {
      public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set;  }

        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<GenreBook> GenreBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(brand => brand.Book)
                .WithOne(book => book.Brands)
                .HasForeignKey(book => book.BrandId);

            modelBuilder.Entity<Language>()
               .HasMany(language => language.Book)
               .WithOne(book => book.Languages)
               .HasForeignKey(book => book.LanguageId);

            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.BookId, ab.AuthorId });

            modelBuilder.Entity<GenreBook>()
                .HasKey(ab => new { ab.BookId, ab.GenreId });


        }
    }
}

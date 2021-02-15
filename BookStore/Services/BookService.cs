using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private BookStoreDbContext dbContext;

        public BookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public void DeleteBook(Book deletingBook)
        {
            dbContext.Books.Remove(deletingBook);
            dbContext.SaveChanges();

        }

        public void DetailsBook(Book detailsBook)
        {
           
        }

        public int EditBook(Book book)
        {
           dbContext.Entry(book).State = EntityState.Modified;
           return dbContext.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return dbContext.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            var books = dbContext.Books.AsNoTracking().ToList();
            return books;
        }

        

        public List<Book> GetBooksByBrandId(int brandId)
        {
            return dbContext.Books.AsNoTracking().Where(p => p.BrandId == brandId).ToList();
        }

        public List<Book> GetBooksByLanguageId(int languageId)
        {
            return dbContext.Books.AsNoTracking().Where(p => p.LanguageId == languageId).ToList();
        }

        public List<Book> GetBooksByGenreId(int genreId)
        {
          
            return dbContext.Books.Where(item => item.GenreBooks.Any(j => j.GenreId == genreId)).ToList();



            //return dbContext.GenreBook.AsNoTracking().Where(p => p.GenreId == genreId).ToList();
        }

        public List<Book> GetBooksByAuthorId(int authorId)
        {

            return dbContext.Books.Where(item => item.AuthorBooks.Any(j => j.AuthorId == authorId)).ToList();



            //return dbContext.GenreBook.AsNoTracking().Where(p => p.GenreId == genreId).ToList();
        }


    }
}

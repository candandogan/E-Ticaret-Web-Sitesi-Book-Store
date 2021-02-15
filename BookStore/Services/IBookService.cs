using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        
        List<Book> GetBooksByBrandId(int brandId);
       
        List<Book> GetBooksByLanguageId(int languageId);

        List<Book> GetBooksByGenreId(int genreId);
        List<Book> GetBooksByAuthorId(int genreId);
        public void AddBook(Book book);
        Book GetBookById(int id);
        public int EditBook(Book book);
        void DeleteBook(Book deletingBook);
        void DetailsBook(Book detailsBook);
    }
}
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Card
    {
        private BookStoreDbContext dbContext;

        private List<BookInCard> books = new List<BookInCard>();
        public void AddItem(Book book, int quantity)
        {
            var existingBook = books.FirstOrDefault(x => x.Book.BookId == book.BookId);
            if (existingBook == null)
            {
                books.Add(new BookInCard { Book = book, Quantity = quantity });
            }
            else
            {
                existingBook.Quantity += quantity;
            }
        }

       
        public void Remove(Book book) => books.RemoveAll(x => x.Book.BookId == book.BookId);

        public void Clear() => books.Clear();

        public decimal GetTotalValue() => books.Sum(x => x.Book.Price * x.Quantity);

        public IEnumerable<BookInCard> Books => books;
    }
}

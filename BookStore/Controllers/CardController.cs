using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CardController : Controller
    {
        private IBookService bookService;
        private List<BookInCard> books = new List<BookInCard>();
        public CardController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Index(string returnUrl)
        {
            var card = GetCard();
            ViewBag.returnUrl = returnUrl;
            return View(card);
        }

        [HttpPost]
        public IActionResult AddToCard(int id, string returnUrl)
        {
            var selectedBook = bookService.GetBookById(id);
            if(selectedBook == null)
            {
                return NotFound();
            }

            Card card = GetCard() ?? new Card();
            card.AddItem(selectedBook, 1);
            SaveCard(card);
            return RedirectToAction(nameof(Index),nameof(Card), new {returnUrl=returnUrl});
        }

        [HttpPost]
        public IActionResult DeleteToCard(int id, string returnUrl)
        {
            var selectedBook = bookService.GetBookById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }

            Card card = GetCard() ?? new Card();
            card.AddItem(selectedBook, -1);
            SaveCard(card);
            return RedirectToAction(nameof(Index), nameof(Card), new { returnUrl = returnUrl });
        }


        [HttpPost]
        public IActionResult RemoveCard(int id, string returnUrl)
        {
            var selectedBook = bookService.GetBookById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }

            Card card = GetCard() ?? new Card();
            card.Remove(selectedBook);
           
            SaveCard(card);
            return RedirectToAction(nameof(Index), nameof(Card), new { returnUrl = returnUrl });
        }

        Card GetCard()
        {
            var data = HttpContext.Session.GetString("sepetim");
            if (data == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Card>(data);
            }
        }

        public void SaveCard(Card card)
        {
            HttpContext.Session.SetString("sepetim", JsonConvert.SerializeObject(card));
        }


    }
}

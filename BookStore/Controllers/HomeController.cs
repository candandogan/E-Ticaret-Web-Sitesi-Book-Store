using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;
        private IBrandService brandService;
        private ILanguageService languageService;
        private IGenreService genreService;
        private IGenreBookService genreBookService;
        private IAuthorService authorService;
        private IAuthorBookService authorBookService;

        public HomeController(ILogger<HomeController> logger , IBookService bookService, IBrandService brandService, ILanguageService languageService, IGenreService genreService, IGenreBookService genreBookService, IAuthorService authorService, IAuthorBookService authorBookService)
        {
            _logger = logger;
            this.bookService = bookService;
            this.brandService = brandService;
            this.languageService = languageService;
            this.genreService = genreService;
            this.genreBookService = genreBookService;
            this.authorService = authorService;
            this.authorBookService = authorBookService;
        }

        public IActionResult Index(int page=1,int languageId=0)
        {
            var pageSize = 8;
            var books = languageId == 0 ? bookService.GetBooks() : bookService.GetBooksByLanguageId(languageId);
            
            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page-1)*pageSize)
                                   .Take(pageSize);

            ViewBag.LanguageId = languageId;

            var totalPage = Math.Ceiling((decimal)totalBook/pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        }

        public IActionResult Brands()
        {
            List<SelectListItem> selectListBrands = getBrandsForSelect();
            ViewBag.Brands = selectListBrands;

            return View();
        }

        [HttpPost]

        public IActionResult Brands(int brandId=0, int page = 1)
        {
           
            var pageSize = 8;
            var books = brandId == 0 ? bookService.GetBooks() : bookService.GetBooksByBrandId(brandId);

            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);

            ViewBag.BrandId = brandId;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);



        }

        public IActionResult Brands_son(int brandId = 0, int page = 1)
        {
            var pageSize = 8;
            var books = brandId == 0 ? bookService.GetBooks() : bookService.GetBooksByBrandId(brandId);

            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);

            ViewBag.BrandId = brandId;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        }
        public IActionResult Languages()
        {
            List<SelectListItem> selectListLanguages = getLanguagesForSelect();
            ViewBag.Languages = selectListLanguages;

            return View();
        }

        public IActionResult LanguagesSelect(int languageId = 0, int page = 1)
        {
            var pageSize = 8;
            var books = languageId == 0 ? bookService.GetBooks() : bookService.GetBooksByLanguageId(languageId);

            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);

            ViewBag.LanguageId = languageId;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        }

        public IActionResult Genres()
        {
            List<SelectListItem> selectListGenres = getGenresForSelect();
            ViewBag.Genres = selectListGenres;

            return View();
        }

        public IActionResult Genres_son(int genreId = 0, int page = 1)
        {
            var pageSize = 8;
            var books = genreId == 0 ? bookService.GetBooks() : bookService.GetBooksByGenreId(genreId);

            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);

            ViewBag.GenreId = genreId;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        }

        public IActionResult Authors()
        {
            List<SelectListItem> selectListAuthors = getAuthorsForSelect();
            ViewBag.Authors = selectListAuthors;

            return View();
        }

        public IActionResult AuthorsForSelect(int authorId = 0, int page = 1)
        {
            var pageSize = 8;
            var books = authorId == 0 ? bookService.GetBooks() : bookService.GetBooksByAuthorId(authorId);

            var totalBook = books.Count;

            var pagingBooks = books.OrderBy(b => b.BookId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);

            ViewBag.authorId = authorId;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        }
        private List<SelectListItem> getLanguagesForSelect()
        {
            var languages = languageService.GetLanguages();
            List<SelectListItem> selectListLanguages = new List<SelectListItem>();
            languages.ToList().ForEach(language => selectListLanguages.Add(new SelectListItem { Text = language.Name, Value = language.LanguageId.ToString() }));
            return selectListLanguages;
        }

        private List<SelectListItem> getGenresForSelect()
        {
            var genres = genreService.GetGenres();


            List<SelectListItem> selectListGenres = new List<SelectListItem>();
            genres.ToList().ForEach(genre => selectListGenres.Add(new SelectListItem { Text = genre.Name, Value = genre.GenreId.ToString() }));
            return selectListGenres;
        }

        private List<SelectListItem> getAuthorsForSelect()
        {
            var authors = authorService.GetAuthors();


            List<SelectListItem> selectListAuthors = new List<SelectListItem>();
            authors.ToList().ForEach(author => selectListAuthors.Add(new SelectListItem { Text = author.Name + " "+author.LastName, Value = author.AuthorId.ToString() }));
            return selectListAuthors;
        }
        private List<SelectListItem> getBrandsForSelect()
        {
            var brands = brandService.GetBrands();


            List<SelectListItem> selectListBrands = new List<SelectListItem>();
            brands.ToList().ForEach(brand => selectListBrands.Add(new SelectListItem { Text = brand.Name, Value = brand.BrandId.ToString() }));
            return selectListBrands;
        }

        public IActionResult Message()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Message(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
                MessageUsers.Add(userResponse);
                // TODO 1: Her şey doğruysa bu kısım çalışacak... 
                return View("Thanx",userResponse);
            }
            return View();
        }


        public IActionResult CompleteShopping()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompleteShopping(CompleteShopping completeShopping)
        {
            if (ModelState.IsValid)
            {
                ShoppingResult.Add(completeShopping);
                return View("Thanks1", completeShopping);
            }
            return View();
        }

        public IActionResult Shopping()
        {
            return View(ShoppingResult.shoppingUsers);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

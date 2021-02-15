using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BooksController : Controller
    {
        private IBookService bookService;
        private IBrandService brandService;
        private ILanguageService languageService;

        public BooksController(IBookService bookService, IBrandService brandService, ILanguageService languageService)
        {
            this.bookService = bookService;
            this.brandService = brandService;
            this.languageService = languageService;
        }
        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            List<SelectListItem> selectListBrands = getBrandsForSelect();
            ViewBag.Brands = selectListBrands;
            List<SelectListItem> selectListLanguages = getLanguagesForSelect();
            ViewBag.Languages = selectListLanguages;


            return View();
        }

        public IActionResult Delete(int id)
        {
            var deletingBook = bookService.GetBookById(id);

            //Eğer ajax kullanılmazsa bu view döndürülür
            return View(deletingBook);

            //return Json(deletingBook.Name);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteOk(int id)
        {
            var deletingBook = bookService.GetBookById(id);
            bookService.DeleteBook(deletingBook);

            //Eğer ajax kullanılmazsa bu view döndürülür
            return RedirectToAction(nameof(Index));

            //return Json("OK");
        }
        public IActionResult Details(int id)
        {
            var detailBook = bookService.GetBookById(id);
            return View(detailBook);
        }

        [HttpPost, ActionName("Details")]
        public IActionResult DetailsOk(int id)
        {
            var detailsBook = bookService.GetBookById(id);
            bookService.DetailsBook(detailsBook);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]

        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> selectListBrands = getBrandsForSelect();
            ViewBag.Brands = selectListBrands;
            List<SelectListItem> selectListLanguages = getLanguagesForSelect();
            ViewBag.Languages = selectListLanguages;
            return View();
        }


        public IActionResult Edit(int id)
        {
            var existingBook = bookService.GetBookById(id);
            if (existingBook==null)
            {
                return NotFound();
            }
            //ViewBag.Languages = getLanguagesForSelect();
            //ViewBag.Brands = getBrandsForSelect();

            List<SelectListItem> selectListBrands = getBrandsForSelect();
            ViewBag.Brands = selectListBrands;
            List<SelectListItem> selectListLanguages = getLanguagesForSelect();
            ViewBag.Languages = selectListLanguages;
            return View(existingBook);
        }

       
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = bookService.EditBook(book);
                string message = affectedRowsCount > 0 ? $"{book.Name} isimli kitap güncellendi. " : "Bir problem oluştu. ";

                return Json(message);
            }
            List<SelectListItem> selectListBrands = getBrandsForSelect();
            ViewBag.Brands = selectListBrands;
            List<SelectListItem> selectListLanguages = getLanguagesForSelect();
            ViewBag.Languages = selectListLanguages;
            return View();

        }


        private List<SelectListItem> getLanguagesForSelect()
        {
            var languages = languageService.GetLanguages();
            List<SelectListItem> selectListLanguages = new List<SelectListItem>();
            languages.ToList().ForEach(language => selectListLanguages.Add(new SelectListItem { Text = language.Name, Value = language.LanguageId.ToString() }));
            return selectListLanguages;
        }

        private List<SelectListItem> getBrandsForSelect()
        {
            var brands = brandService.GetBrands();


            List<SelectListItem> selectListBrands = new List<SelectListItem>();
            brands.ToList().ForEach(brand => selectListBrands.Add(new SelectListItem { Text = brand.Name, Value = brand.BrandId.ToString() }));
            return selectListBrands;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreBooksController : Controller
    {
        private readonly BookStoreDbContext _context;

        public GenreBooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: GenreBooks
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.GenreBook.Include(g => g.Book).Include(g => g.Genre);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: GenreBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .Include(g => g.Book)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // GET: GenreBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Name");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            return View();
        }

        // POST: GenreBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,GenreId")] GenreBook genreBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Name", genreBook.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name", genreBook.GenreId);
            return View(genreBook);
        }

        // GET: GenreBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook.FindAsync(id);
            if (genreBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Name", genreBook.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name", genreBook.GenreId);
            return View(genreBook);
        }

        // POST: GenreBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,GenreId")] GenreBook genreBook)
        {
            if (id != genreBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreBookExists(genreBook.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Name", genreBook.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name", genreBook.GenreId);
            return View(genreBook);
        }

        // GET: GenreBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .Include(g => g.Book)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // POST: GenreBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreBook = await _context.GenreBook.FindAsync(id);
            _context.GenreBook.Remove(genreBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreBookExists(int id)
        {
            return _context.GenreBook.Any(e => e.BookId == id);
        }
    }
}

using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.DTOs;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .OrderByDescending(r => r.IsAvailable)
                .ToListAsync();
            return View(books);
        }

        public IActionResult RegisterBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterBook(BookDTO bookDTO)
        {
            Book book = new Book
            {
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Publisher = bookDTO.Publisher,
                PublishYear = bookDTO.PublishYear
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(int id, BookDTO bookDTO)
        {
            var book = await _context.Books.FindAsync(id);
            book.Title = bookDTO.Title;
            book.Author = bookDTO.Author;
            book.Publisher = bookDTO.Publisher;
            book.PublishYear = bookDTO.PublishYear;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult SearchBooks(string searchString)
        {
            if (searchString.IsNullOrEmpty())
            {
                return RedirectToAction("Index");
            }

            var books = _context.Books
                .Where(b => b.Title.Contains(searchString) ||
                            b.Author.Contains(searchString) ||
                            b.Publisher.Contains(searchString))
                .OrderByDescending(r => r.IsAvailable)
                .ToList();

            return View("Index", books);
        }
    }
}

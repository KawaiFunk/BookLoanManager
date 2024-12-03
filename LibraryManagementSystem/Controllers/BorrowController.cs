using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.DTOs;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibraryContext _context;

        public BorrowController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.MemberID = id;
            var records = await _context.BorrowingRecords
                .Include(r => r.Book)
                .Where(r => r.MemberID == id)
                .Where(r => r.IsReturned == false)
                .ToListAsync();
            return View(records);
        }

        public async Task<IActionResult> History(int id)
        {
            ViewBag.MemberID = id;
            var records = await _context.BorrowingRecords
                .Include(r => r.Book)
                .Where(r => r.MemberID == id)
                .ToListAsync();
            return View(records);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            var record = new BorrowingRecordDTO
            {
                BookID = id,
                BookTitle = book.Title
            };

            return View(record);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowingRecordDTO record)
        {
            var book = await _context.Books.FindAsync(record.BookID);

            if (!ModelState.IsValid)
            {
                if (book != null)
                {
                    record.BookTitle = book.Title;
                }
                return View(record);
            }

            var member = await _context.Members.FindAsync(record.MemberID);
            if (member == null)
            {
                ModelState.AddModelError(nameof(record.MemberID), "Member not found");
                if (book != null)
                {
                    record.BookTitle = book.Title;
                }

                return View(record);
            }

            if (book == null || !book.IsAvailable)
            {
                ModelState.AddModelError("BookID", "Book is not available");

                if (book != null)
                {
                    record.BookTitle = book.Title;
                }

                return View(record);
            }

            var newRecord = new BorrowingRecord
            {
                BookID = record.BookID,
                MemberID = record.MemberID,
                BorrowDate = DateTime.Now,
                IsReturned = false
            };

            book.IsAvailable = false;

            _context.BorrowingRecords.Add(newRecord);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Borrow", new { id = record.MemberID });
        }


        [HttpGet]
        public async Task<IActionResult> GetBookTitle(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookID == bookId);
            if (book == null || !book.IsAvailable)
            {
                return NotFound("Book not found.");
            }
            return Json(new { title = book.Title });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Returned(int ID)
        {
            var record = await _context.BorrowingRecords.FindAsync(ID);

            if(record == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(record.BookID);
            book.IsAvailable = true;
            record.IsReturned = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Borrow", new { id = record.MemberID });
        }
    }
}

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

        public IActionResult Create(int id)
        {
            var record = new BorrowingRecord
            {
                MemberID = id,
                BorrowDate = DateTime.Now
            };
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowingRecordDTO recordDTO)
        {
            if (!ModelState.IsValid)
            {
                var record = new BorrowingRecord
                {
                    MemberID = recordDTO.MemberID,
                    BorrowDate = DateTime.Now
                };
                ViewBag.Books = new SelectList(_context.Books, "BookID", "Title");
                return View(record);
            }

            //Check if book exists
            if (!_context.Books.Any(b => b.BookID == recordDTO.BookID))
            {
                ModelState.AddModelError("BookID", "Book not found");
                var record = new BorrowingRecord
                {
                    MemberID = recordDTO.MemberID,
                    BorrowDate = DateTime.Now
                };
                ViewBag.Books = new SelectList(_context.Books, "BookID", "Title");
                return View(record);
            }

            // Save the record
            var newRecord = new BorrowingRecord
            {
                BookID = recordDTO.BookID,
                MemberID = recordDTO.MemberID,
                BorrowDate = DateTime.Now,
                IsReturned = false
            };

            _context.BorrowingRecords.Add(newRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Borrow", new { id = newRecord.MemberID });
        }

        [HttpGet]
        public async Task<IActionResult> GetBookTitle(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookID == bookId);
            if (book == null)
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

            record.IsReturned = true;
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Borrow", new { id = record.MemberID });
        }
    }
}

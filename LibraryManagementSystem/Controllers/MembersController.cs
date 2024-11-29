using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.DTOs;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly LibraryContext _context;

        public MembersController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberDTO memberDTO)
        {
            if (ModelState.IsValid)
            {
                var member = new Member
                {
                    LastName = memberDTO.LastName,
                    FirstName = memberDTO.FirstName,
                    Birthday = memberDTO.Birthday
                };

                _context.Members.Add(member);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(memberDTO);
        }

        [HttpGet("Edit/{ID}")]
        public IActionResult Edit(int ID)
        {
            var member = _context.Members.Find(ID);

            if (member == null)
            {
                return NotFound();
            }

            var memberDTO = new MemberDTO
            {
                LastName = member.LastName,
                FirstName = member.FirstName,
                Birthday = member.Birthday
            };

            ViewData["MemberID"] = member.ID;
            return View(memberDTO);
        }

        [HttpPost("Edit/{ID}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, MemberDTO memberDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(memberDTO);
            }

            Member member = await _context.Members.FindAsync(ID);

            if (member == null)
            {
                return NotFound();
            }

            member.FirstName = memberDTO.FirstName;
            member.LastName = memberDTO.LastName;
            member.Birthday = memberDTO.Birthday;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Delete/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            Member member = await _context.Members.FindAsync(ID);

            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

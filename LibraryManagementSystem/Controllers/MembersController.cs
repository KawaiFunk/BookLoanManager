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
    }
}

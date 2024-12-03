using System.Diagnostics;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LibraryContext libraryContext)
        {
            _logger = logger;
            _context = libraryContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        [HttpGet]
        public IActionResult SearchMember(int searchString)
        {
            if (searchString == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Members
                .Where(b => b.ID == searchString)
                .ToList();

            return View("Index", user);
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

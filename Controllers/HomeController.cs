using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WDP2022A2Win.Data;
using WDP2022A2Win.Models;

namespace WDP2022A2Win.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILogger<HomeController> _logger;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
                
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.ToListAsync());
        
        }
        public async Task<IActionResult> Companies()
        {
            return View(await _context.Company.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Companies(int id, [Bind("Id,CompanyName,Summary,ImageFilename,AnchorLink,Like,canIncreaseLike")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
         
                var adlike = new Company { Id = id, CompanyName=company.CompanyName,Summary=company.Summary,ImageFilename=company.ImageFilename,AnchorLink=company.AnchorLink, Like = company.Like + 1 , canIncreaseLike=company.canIncreaseLike };
                _context.Update(adlike);
                await _context.SaveChangesAsync();
            
            return View(await _context.Company.ToListAsync());
        }
        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
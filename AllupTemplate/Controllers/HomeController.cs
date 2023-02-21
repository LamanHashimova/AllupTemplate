using AllupTemplate.DataAccessLayer;
using AllupTemplate.Models;
using AllupTemplate.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            HomeVM homeVM = new HomeVM {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Categories = await _context.Categories.Where(s => s.IsDeleted == false && s.IsMain).ToListAsync(),
                NewArrival=await _context.Products.Where(s=>s.IsDeleted== false && s.IsNewArrival).ToListAsync(),
                BestSeller=await _context.Products.Where(s=>s.IsDeleted== false && s.IsBestSeller).ToListAsync(),
                Featured=await _context.Products.Where(s=>s.IsDeleted== false && s.IsFeatured).ToListAsync(),
            };
            return View(homeVM);
        }
    }
}

using AllupTemplate.DataAccessLayer;
using AllupTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupTemplate.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Modal(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Product products = await _context.Products.Include(s => s.ProductImages).FirstOrDefaultAsync(s=>s.IsDeleted==false && s.Id==id);
            if (products==null)
            {
                return BadRequest();
            }
            return Json(products);
        }  
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DAL;
using ProniaTask.Models;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Shippings = _context.Shippings.ToList();
            ViewBag.Slides = _context.Slides.ToList();
            ViewBag.Clients = _context.Clients.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(_context.Products.ToList());
        }
        public IActionResult Shop()
        {
            ViewBag.Colors = _context.Colors.Include(c => c.Products).ToList();
            ViewBag.Categories = _context.Categories.Include(c=>c.Products).ToList();
            int? colorCount = 0;
            int? categoryCount = 0;
            foreach (Color color in ViewBag.Colors)
            {
                colorCount += color.Products?.Count;
            }
            foreach (Category category in ViewBag.Categories)
            {
                categoryCount += category.Products?.Count;
            }
            ViewBag.ColorCount = colorCount;
            ViewBag.CategoryCount = categoryCount;
            return View(_context.Products.ToList());
        }
        public IActionResult SingleProduct()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult LoginRegister()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DAL;
using ProniaTask.Models;

namespace ProniaTask.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        AppDbContext _context { get; }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.Include(p=>p.Color).Include(p=>p.Size).Include(p=>p.Category).ToList());
        }
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product is null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            ViewBag.Sizes = _context.Sizes;
            ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Sizes = _context.Sizes;
                ViewBag.Colors = _context.Colors;
                ViewBag.Categories = _context.Categories;
                return View();
            } 
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            ViewBag.Sizes = _context.Sizes;
            ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;
            Product product = _context.Products.Find(id);
            if (product is null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int? id, Product product)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Sizes = _context.Sizes;
                ViewBag.Colors = _context.Colors;
                ViewBag.Categories = _context.Categories;
                return View();
            }
            if (id is null || id != product.Id) return BadRequest();
            Product exist = _context.Products.Find(id);
            if (exist is null) return NotFound();
            exist.Name = product.Name;
            exist.ImageUrl = product.ImageUrl;
            exist.Price = product.Price;
            exist.Desc = product.Desc;
            exist.ColorId = product.ColorId;
            exist.CategoryId = product.CategoryId;
            exist.SizeId = product.SizeId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}

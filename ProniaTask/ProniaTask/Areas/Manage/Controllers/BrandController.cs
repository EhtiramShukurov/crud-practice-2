using Microsoft.AspNetCore.Mvc;
using ProniaTask.DAL;
using ProniaTask.Models;

namespace ProniaTask.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandController : Controller
    {
        AppDbContext _context { get; }
        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Brands.ToList());
        }
        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand is null) return NotFound();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            Brand brand = _context.Brands.Find(id);
            if (brand is null) return NotFound();
            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(int? id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null || id != brand.Id) return BadRequest();
            Brand exist = _context.Brands.Find(id);
            if (exist is null) return NotFound();
            exist.ImageUrl = brand.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

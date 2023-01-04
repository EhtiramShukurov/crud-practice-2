using Microsoft.AspNetCore.Mvc;
using ProniaTask.DAL;
using ProniaTask.Models;

namespace ProniaTask.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class SliderController : Controller
    {
        AppDbContext _context { get; }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Slides.ToList());
        }
        public IActionResult Delete(int id)
        {
            Slide slide = _context.Slides.Find(id);
            if (slide is null) return NotFound();
            _context.Slides.Remove(slide);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Slides.Add(slide);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            Slide slide = _context.Slides.Find(id);
            if (slide is null) return NotFound();
            return View(slide);
        }
        [HttpPost]
        public IActionResult Update(int? id, Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null || id != slide.Id) return BadRequest();
            Slide exist = _context.Slides.Find(id);
            if (exist is null) return NotFound();
            exist.Offer = slide.Offer;
            exist.ImageUrl = slide.ImageUrl;
            exist.Title = slide.Title;
            exist.Desc = slide.Desc;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

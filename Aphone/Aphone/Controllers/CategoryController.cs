using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aphone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aphone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Categories> categories = _appDbContext.Categories.Include(p => p.products);
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Add(categories);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categories = _appDbContext.Categories.Find(id);
            if (categories == null) return NotFound();

            return View(categories);
        }

        [HttpPost]
        public IActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Update(categories);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categories);

        }
    }
}

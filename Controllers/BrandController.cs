using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestStore.Data;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BrandController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Brand> objList = _db.Brand;
            return View(objList);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand obj)
        {
            _db.Brand.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Brand.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Brand obj)
        {
            if (ModelState.IsValid)
            {
                _db.Brand.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Brand.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Brand obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.Brand.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}



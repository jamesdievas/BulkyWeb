using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //tempData ( will be shown on the page temporarily
                TempData["success"] = "Category created successfuly";
                // Se o Index estiver dentro de um controller diferente como o "Category"
                //return RedirectToAction("Index","Category");
                return RedirectToAction("Index");

            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }

            // this options works for all collomns
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
           // var category1 = _db.Categories.Where(c=> c.Id== id).FirstOrDefault();

            // this options is for primary key only
            //var category = _db.Categories.Find(id);
            if (category == null) {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // if obj.id ==0, this function will create a new item on the table
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfuly";
                // Se o Index estiver dentro de um controller diferente como o "Category"
                //return RedirectToAction("Index","Category");
                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // this options works for all collomns
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            // var category1 = _db.Categories.Where(c=> c.Id== id).FirstOrDefault();

            // this options is for primary key only
            //var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = _db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfuly";
            return RedirectToAction("Index");
        }
    }
}

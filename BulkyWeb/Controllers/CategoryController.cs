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
             List<Category> objCategoryList = _db.MyProperty.ToList();   
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
                ModelState.AddModelError("name", "The Display order cannot exactly match the Name");
            }
            if(obj.Name!=null && obj.Name.ToLower()== "test")
            {
                ModelState.AddModelError("", "Test is an invaid value");
            }
            if (ModelState.IsValid)
            {
                _db.MyProperty.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Create Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {   
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.MyProperty.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
          
            if (ModelState.IsValid)
            {
                _db.MyProperty.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
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
            Category? categoryFromDb =  _db.MyProperty.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.MyProperty.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.MyProperty.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
           
        }
    }
}

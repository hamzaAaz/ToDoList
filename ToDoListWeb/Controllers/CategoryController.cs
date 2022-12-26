using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListWeb.Data;
using ToDoListWeb.Models;

namespace ToDoListWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
            _db = db;
    }
    [Authorize(Roles = "admin" )]
    public IActionResult Index()
    {   
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }
    public IActionResult Create()
    {
        
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {    
        if (obj.Name == obj.CreateDateTime1.ToString())
        {
            ModelState.AddModelError("name", "the date cannot exactly match the Name");
        }
        if (ModelState.IsValid) {
        _db.Categories.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("index");
        }
        return View(obj);
    }


    public IActionResult Edit(int? Id)
    {
        if(Id == null || Id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(Id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
       // var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.CreateDateTime1.ToString())
        {
            ModelState.AddModelError("name", "the date cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        return View(obj);
    }
    public IActionResult Delete(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(Id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
        // var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? Id)
    {
          var obj = _db.Categories.Find(Id);
        if( obj == null)
        {
            return NotFound();
        }
        
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        
        
    }
}

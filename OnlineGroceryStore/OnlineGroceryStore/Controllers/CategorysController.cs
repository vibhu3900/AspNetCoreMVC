using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.Linq;

namespace OnlineGroceryStore.Models
{
    public class CategorysController : Controller
    {
        // GET: CategorysController
        public ActionResult Index(int PageNumber=1)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            var categories = ogsd.Categories.ToList();
            ViewBag.TotalPages = Math.Ceiling(categories.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            categories = categories.Skip((PageNumber-1)*10).Take(10).ToList();   
            return View(categories);
        }

        // GET: CategorysController/Details/5
        public ActionResult Details(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();

            return View(ogsd.Categories.ToList());
        }

        // GET: CategorysController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorysController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Category obj)
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                ogsd.Categories.Add(obj);
                ogsd.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorysController/Edit/5
        public ActionResult Edit(int id)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Category cat = ogsd.Categories.FirstOrDefault(i => i.CategoryId == id);
            return View(cat);
        }

        // POST: CategorysController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cobj)
        {
            try
            {

                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Category cat = ogsd.Categories.FirstOrDefault(i => i.CategoryId == cobj.CategoryId);
                cat.CategoryName = cobj.CategoryName;
                cat.ParentCategoryId = cobj.ParentCategoryId;
                ogsd.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorysController/Delete/5
        public ActionResult Delete(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Category cat = ogsd.Categories.FirstOrDefault(i => i.CategoryId == id);
            return View(cat);
        }

        // POST: CategorysController/Delete/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                int id = int.Parse(Request.Form["DeleteCategoryId"].ToString());
                Category cat = ogsd.Categories.FirstOrDefault(i => i.CategoryId == id);
                ogsd.Categories.Remove(cat);
                ogsd.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

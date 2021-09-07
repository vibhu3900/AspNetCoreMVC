using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.IO;
using System.Linq;

namespace OnlineGroceryStore.Controllers
{

    public class ProductsController : Controller
    {
        // GET: ProductsController
        
        public ActionResult Index(int PageNumber = 1)
        {
            OnlineGroceryStoreDBContext ogsd =new OnlineGroceryStoreDBContext();
            var products = ogsd.Products.ToList();
            ViewBag.TotalPages = Math.Ceiling(products.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            products = products.Skip((PageNumber - 1) * 10).Take(5).ToList();
            return View(products);
        }

        //GET: ProductsController/Details
        public ActionResult Details(int id)
        {
             OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
             Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
             return View(prod);
        }

        // POST: ProductsController/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Product obj, IFormFile imgFiles)
        {
            //try
            //{
            //    OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            //    using (MemoryStream ms = new MemoryStream())
                               
                //string productname = Request.Form["ProductImage"].ToString();

                //{
                //   byte[] bt = item.ProductImage;
                //   string str = Convert.ToBase64String(bt);
                //   var imgsrc = string.Format("data:image/jpg;base64,{0}", str);
                //           < img src = "@imgsrc" width = "100" height = "100" alt = "Gr8" />

                //}
                //Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);
                //ogsd.Products.Remove(prod);
                //ogsd.SaveChanges();
                //return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
                return View();
            //}
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product obj, IFormFile imgFiles)
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.ProductImage= bt;
                    ogsd.Products.Add(obj);
                    ogsd.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ProductsController/Edit/5

        public ActionResult Edit(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
                return View(prod);
            
            
            
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product obj, IFormFile imgFiles)
        {
            try
            {

                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);


                if (imgFiles != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imgFiles.CopyTo(ms);
                        byte[] bt = ms.ToArray();
                        obj.ProductImage = bt;
                        prod.ProductName = obj.ProductName;
                        prod.BrandName = obj.BrandName;
                        prod.ProductPrice = obj.ProductPrice;
                        prod.NoOfItemsInStock = obj.NoOfItemsInStock;
                        prod.ProductImage = obj.ProductImage;
                        prod.ProductDiscription = obj.ProductDiscription;
                        prod.Discount = obj.Discount;
                        prod.CategoryId = obj.CategoryId;
                        ogsd.SaveChanges();
                    }
                }
                else
                {
                    prod.ProductName = obj.ProductName;
                    prod.BrandName = obj.BrandName;
                    prod.ProductPrice = obj.ProductPrice;
                    prod.NoOfItemsInStock = obj.NoOfItemsInStock;
                    prod.ProductImage = obj.ProductImage;
                    prod.ProductDiscription = obj.ProductDiscription;
                    prod.Discount = obj.Discount;
                    prod.CategoryId = obj.CategoryId;
                    ogsd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
            return View(prod);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product obj)
        {
            try
            {


                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                string playername = Request.Form["ProductImage"].ToString();
                Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);
                ogsd.Products.Remove(prod);
                ogsd.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

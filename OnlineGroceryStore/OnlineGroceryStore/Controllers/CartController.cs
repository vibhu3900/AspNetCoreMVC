﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class CartController : Controller
    {

        public IActionResult AddToCart(int id)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
            return View(prod);


        }


        [HttpPost]
        public ActionResult AddToCart(Product obj, IFormFile imgFiles)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product Brd = ogsd.Products.FirstOrDefault(i => i.Productid== obj.Productid);

            
            

            return RedirectToAction("Index");

            //if (TempData["cart"] == null)
            //{
            //    List<Product> li = new List<Product>();



            //    li.Add(id);
            //    TempData["cart"] = li;
            //    ViewBag.cart = li.Count();




            //    TempData["count"] = 1;




            //}
            //else
            //{
            //    List<Product> li = (List<Product>)TempData["cart"];
            //    li.Add(id);
            //    TempData["cart"] = li;
            //    ViewBag.cart = li.Count();
            //    TempData["count"] = Convert.ToInt32(TempData["count"]) + 1;



            //}
            //return RedirectToAction("Index");




        }




        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

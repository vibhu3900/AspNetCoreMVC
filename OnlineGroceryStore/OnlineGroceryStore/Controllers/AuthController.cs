using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.AdminDetailsModel;
using OnlineGroceryStore.CategoryProduct;

namespace OnlineGroceryStore.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminLogin()
        {

            //OnlineGroceryStoreDBContext ogsd =new OnlineGroceryStoreDBContext();
            //return View(ogsd.Admindetails.ToList());
            return View();
        }


        

        public IActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegister(Customer obj)
        {
            if (ModelState.IsValid)
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                ogsd.Customers.Add(obj);
                ogsd.SaveChanges();
                return View("CustomerLogin");
            }
            return Json(obj);

}

        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer obj)
        {




            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            var user = ogsd.Customers.Where(i => i.Custemail == obj.Custemail && i.CustPassword == obj.CustPassword).Count();



            if (user > 0)
            {
                return RedirectToAction("DashBoard");
            }
            else
            {
                return View();
            }
        }
        public IActionResult DashBoard()
        {
            return View();
        }







    }
}

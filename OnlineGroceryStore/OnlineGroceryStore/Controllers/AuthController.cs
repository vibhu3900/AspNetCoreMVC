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


        public IActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminRegister(Admindetail obj)
        {

            if (ModelState.IsValid)
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                ogsd.Admindetails.Add(obj);
                ogsd.SaveChanges();
            }

            return Json(obj);

        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admindetail obj)
        {


            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            var user = ogsd.Admindetails.Where(i => i.AdminEmail == obj.AdminEmail && i.AdminPassword == obj.AdminPassword).Count();

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
        







    }

    //public ActionResult UserDashBoard()
    //{
    //    if (Session["UserID"] != null)
    //    {
    //        return View();
    //    }
    //    else
    //    {
    //        return RedirectToAction("Login");
    //    }
    //}
}



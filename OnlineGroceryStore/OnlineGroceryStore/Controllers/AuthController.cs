using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.AdminDetailsModel;
using OnlineGroceryStore.CategoryProduct;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace OnlineGroceryStore.Controllers
{


    public class AuthController : Controller
    {
        private readonly IConfiguration config;

        public AuthController(IConfiguration config)
        {
            this.config = config;
        }


        //============================

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



        //===========================================


        

        [HttpPost]
        public async Task<IActionResult> ValidateUser(Admindetail obj)
        {
            if (ModelState.IsValid)
            {
                //        var data = config.GetSection("Users");
                //        for (int i = 0; i < data.GetChildren().Count(); i++)
                //        {
                //            string uname = data.GetChildren().ToList()[i].GetSection("Username").Value;
                //            string pass = data.GetChildren().ToList()[i].GetSection("Password").Value;
                //            string role = data.GetChildren().ToList()[i].GetSection("Role").Value;
                //            if (uname == obj.UserName && pass == obj.Pass)
                //            {
                //                var claims = new List<Claim>() {
                //             new Claim(ClaimTypes.Name,obj.UserName),
                //              new Claim(ClaimTypes.Role,role)
                //            };
                //                var claimIdentity = new ClaimsIdentity(claims,
                //                    CookieAuthenticationDefaults.AuthenticationScheme);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //                         new ClaimsPrincipal(claimIdentity));
                //                return RedirectToAction("Index", "Home");

                //            }
                //        }
                OnlineGroceryStoreDBContext dbx = new OnlineGroceryStoreDBContext();
                Admindetail u1 = dbx.Admindetails.
                    FirstOrDefault(i => i.AdminEmail == obj.AdminEmail &&
                    i.AdminPassword == obj.AdminPassword);
                if (u1 == null)
                {
                    ModelState.AddModelError("", "Invalid Username & Password");
                    return View("AdminLogin");
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                                     new Claim(ClaimTypes.Email,obj.AdminEmail),
                                      new Claim(ClaimTypes.Role,u1.AdminPhoneno)
                                    };
                    var claimIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                             new ClaimsPrincipal(claimIdentity));
                    return RedirectToAction("DashBoard", "Auth");
                }
            }
            else
                return View("AdminLogin");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminLogin", "Auth");
        }
        public IActionResult NotFound()
        {
            return View();
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



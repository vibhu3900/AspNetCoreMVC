using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.AdminDetailsModel;


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

    }
}

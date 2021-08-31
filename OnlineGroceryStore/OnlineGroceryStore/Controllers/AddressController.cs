using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.AdminDetailsModel;

namespace OnlineGroceryStore.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            //OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            //Customer cust = ogsd.Customers.FirstOrDefault(i => i.Custid == id);
            //return View(ogsd.Customers.ToList());
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }
    }
}

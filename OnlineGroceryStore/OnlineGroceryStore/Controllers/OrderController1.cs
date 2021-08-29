using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class OrderController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

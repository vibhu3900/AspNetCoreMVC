using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Models.SignInModel;
using OnlineGroceryStore.Models.SignUpUserModel;
using OnlineGroceryStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Route("signup")]
        public IActionResult Signup()
        {
            

            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result =await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
            }
            return View();
        }
        [Route("login")]
        public IActionResult Login()
        {


            return View();
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
              var result =  await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Customer");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }

            return View();
        }


        [Route("logut")]
        public async Task<IActionResult>  Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Customer");

        }
    }
}

using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel userLoginModel, string returnUrl)
        {
            var user = userService.ValidUser(userLoginModel.UserName, userLoginModel.Password);
            if(user!=null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return Redirect("/");
            }
           
                ModelState.AddModelError("Hata","Kullanıcı adı ya da şifre yanlış!");
            return View();           
        }

        public  AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

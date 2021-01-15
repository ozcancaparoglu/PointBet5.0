using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PointBet.Data.Models;
using PointBet.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PointBet.Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        [Route("login")]
        public IActionResult Login(string ReturnUrl = null)
        {
            //userService.CreateUser("aktemur", "123", 3);
            //userService.CreateUser("occanc", "occanc", 3);
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.Message = string.Empty;
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
        {
            var authUser = userService.Authenticate(username, password);
            if (authUser != null)
            {
                if (!string.IsNullOrWhiteSpace(authUser.Username))
                {
                    await LoginAsync(authUser);
                    // Return URL
                    if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return Redirect("~/Home/Index");
                }
            }
            ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
            return View();
        }

        [Route("edituser")]
        public IActionResult EditUser(string username, decimal? totalPoints, int? userRoleId, string password = "")
        {
            userService.EditUser(username, totalPoints, userRoleId, password);
            return Ok();
        }

        private async Task LoginAsync(UserModel authUser)
        {
            var properties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authUser.Username),
                new Claim(ClaimTypes.Role, authUser.UserRole.Name),
                new Claim(ClaimTypes.Sid, authUser.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!configuration.GetValue<bool>("Account:ShowLogoutPrompt"))
            {
                return await Logout();
            }

            return View();
        }

        [HttpPost]
        [Route("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Login", "Auth");
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
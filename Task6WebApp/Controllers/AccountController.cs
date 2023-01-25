using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Task6WebApp.Data;
using Task6WebApp.Data.Entities;
using Task6WebApp.Data.Repository.Interfaces;
using Task6WebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Task6WebApp.Hubs;

namespace Task6WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IHubContext<MessageHub> _messageHub;
        public AccountController(IRepositoryWrapper repository,
            IHubContext<MessageHub> messageHub)
        {
            _repository = repository;
            _messageHub = messageHub;
        }
        // GET: AccountController
        public ActionResult Login()
        {
            HttpContext.SignOutAsync("UserCookie").GetAwaiter().GetResult();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Login) };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("UserCookie", principal);
                if (_repository.User.IsUserExists(model.Login))
                {
                    var user = new User()
                    {
                        UserName = model.Login,
                        Name = model.Login
                    };
                    _repository.User.Create(user);
                    _repository.Save();
                    _messageHub.Clients.All.SendAsync("newUser", model.Login).GetAwaiter().GetResult();
                }
                return RedirectToAction("Index", "Home");
                
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("UserCookie");
            return RedirectToAction("Login");
        }
    }
}

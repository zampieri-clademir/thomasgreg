using Microsoft.AspNetCore.Mvc;
using ThomasGregChallenge.Web.Pages;

namespace ThomasGregChallenge.Web
{
    public class AccountController : Controller
    {
        private readonly HttpClientService _httpClientService;

        public AccountController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var token = await _httpClientService.AuthenticateUserAsync(model.Email, model.Password);

            if (token != null)
            {
                // Armazene o token em um cookie ou outro meio
                Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true, Secure = true });

                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Tentativa de login inválida.");
                return View(model);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
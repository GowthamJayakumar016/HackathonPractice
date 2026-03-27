using Microsoft.AspNetCore.Mvc;
using NangaNaluPeru.DTOs;
using NangaNaluPeru.Services.Interfaces;

namespace NangaNaluPeru.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ================= REGISTER =================

        public IActionResult Register()
        {
            return View("~/Views/Auth/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _authService.RegisterAsync(dto);

            if (!result)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(dto);
            }

            return RedirectToAction("Login");
        }

        // ================= LOGIN =================

        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(dto);
            }

            // Session store
            HttpContext.Session.SetString("Token", result.Token);
            HttpContext.Session.SetString("Role", result.Role);
            HttpContext.Session.SetInt32("UserId", result.UserId);

            // Role-based redirect
            if (result.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            return RedirectToAction("Dashboard", "User");
        }

        // ================= LOGOUT =================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
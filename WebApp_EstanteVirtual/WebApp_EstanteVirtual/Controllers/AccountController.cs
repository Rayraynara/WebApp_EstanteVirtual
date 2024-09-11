
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp_EstanteVirtual.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action para a página de registro
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    Id = Guid.NewGuid().ToString(), // Gerar um novo Id
                    Nome = model.UserName,
                    Email = model.Email,
                    CPF = model.CPF,
                    Senha = model.Password,
                    IsAdmin = false
                };

                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();

                // Definir o cookie de autenticação manualmente
                HttpContext.Session.SetString("UserId", user.Id);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    // Definir o cookie de autenticação manualmente
                    HttpContext.Session.SetString("UserId", user.Id);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home");
        }
    }
}


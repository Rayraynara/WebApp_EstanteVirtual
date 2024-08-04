using Microsoft.AspNetCore.Mvc;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;
using System.Linq;

namespace WebApp_EstanteVirtual.Controllers
{
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Relatorio()
        {
            var vendas = _context.Vendas.ToList();
            var model = new VendasRelatorioViewModel
            {
                Vendas = vendas
            };
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;

public class VendasController : Controller
{
    private readonly ApplicationDbContext _context;

    public VendasController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult LivrosDisponiveis()
    {
        var livrosDisponiveis = _context.Livros
            .Where(l => l.QuantidadeEstoque > 0)
            .ToList();

        return View("VendasLayout", livrosDisponiveis);
    }

    [Authorize]
    public IActionResult Comprar(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult Comprar(int id, [FromForm] CompraViewModel model)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound();
        }

        if (livro.QuantidadeEstoque > 0)
        {
            livro.QuantidadeEstoque--;

            var venda = new Venda
            {
                Livro = livro,
                DataHora = DateTime.Now,
                Total = livro.Preco
            };

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return RedirectToAction("LivrosDisponiveis"); // Redirecionado para a view de compras
        }
        else
        {
            ModelState.AddModelError("", "Este livro não está mais disponível no estoque.");
            return View(livro);
        }
    }
}

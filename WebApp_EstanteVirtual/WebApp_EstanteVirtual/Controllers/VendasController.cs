using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;
using System.Linq;

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

        // pag detalhes de pagamento
        return View("DetalhesPagamento", new CompraViewModel { LivroId = id, Livro = livro });
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarCompra(CompraViewModel model)
    {
        var livro = _context.Livros.Find(model.LivroId);
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

            TempData["MensagemSucesso"] = "Compra concluída com sucesso!";
            return RedirectToAction("Comprar", new { id = model.LivroId });
        }
        else
        {
            ModelState.AddModelError("", "Este livro não está mais disponível no estoque.");
            return View("DetalhesPagamento", model);
        }
    }

    // relatórios de vendas
    //public IActionResult RelatorioVendas()
    //{
    //   return View();
    //}
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;
using System;
using System.Collections.Generic;
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

    [Authorize(Roles = "Admin")]
    public IActionResult VendasRelatorio(string periodo)
    {
        var viewModel = new VendasRelatorioViewModel
        {
            PeriodoSelecionado = periodo
        };

        DateTime dataInicio = DateTime.Now;
        DateTime dataFim = DateTime.Now;

        //melhorar filtro ainda
        switch (periodo)
        {
            case "diario":
                dataInicio = DateTime.Now.Date;
                dataFim = DateTime.Now.Date.AddDays(1).AddTicks(-1);
                break;
            case "semanal":
                dataInicio = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
                dataFim = dataInicio.AddDays(7).AddTicks(-1);
                break;
            case "mensal":
                dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dataFim = dataInicio.AddMonths(1).AddTicks(-1);
                break;
            default:
                dataInicio = DateTime.Now.Date;
                dataFim = DateTime.Now.Date.AddDays(1).AddTicks(-1);
                break;
        }
        var vendas = _context.Vendas
            .Where(v => v.DataHora >= dataInicio && v.DataHora <= dataFim)
            .ToList();

        viewModel.Vendas = vendas;
        viewModel.TotalVendido = vendas.Sum(v => v.Total);

        return View(viewModel);
    }


}

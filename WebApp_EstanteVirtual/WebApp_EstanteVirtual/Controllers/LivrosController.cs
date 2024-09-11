using Microsoft.AspNetCore.Mvc;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;
using System.Linq;

namespace WebApp_EstanteVirtual.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var livro = new Livro
                {
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Editora = model.Editora,
                    QuantidadeEstoque = model.QuantidadeEstoque,
                    Capa = model.Capa
                };
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }
            var model = new CreateLivroViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Preco = livro.Preco,
                Editora = livro.Editora,
                QuantidadeEstoque = livro.QuantidadeEstoque,
                Capa = livro.Capa
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateLivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var livro = _context.Livros.Find(model.Id);
                if (livro == null)
                {
                    return NotFound();
                }
                livro.Nome = model.Nome;
                livro.Preco = model.Preco;
                livro.Editora = model.Editora;
                livro.QuantidadeEstoque = model.QuantidadeEstoque;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var livro = _context.Livros.Find(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

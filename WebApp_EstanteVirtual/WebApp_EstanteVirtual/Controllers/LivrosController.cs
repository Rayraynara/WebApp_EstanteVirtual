using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_EstanteVirtual.Data;
using WebApp_EstanteVirtual.Models;

namespace WebApp_EstanteVirtual.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros.ToListAsync();
            return View(livros);
        }

        public IActionResult CadastrarLivro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarLivro(CreateLivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var livro = new Livro
                {
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Editora = model.Editora,
                    QuantidadeEstoque = model.QuantidadeEstoque,
                    Capa = model.Capa,
                    Novo = model.Novo
                };
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> EditarLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
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
        public async Task<IActionResult> EditarLivro(CreateLivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var livro = await _context.Livros.FindAsync(model.Id);
                
                if (livro == null)
                {
                    return NotFound();
                }

                livro.Nome = model.Nome;
                livro.Preco = model.Preco;
                livro.Editora = model.Editora;
                livro.QuantidadeEstoque = model.QuantidadeEstoque;
                livro.Capa = model.Capa;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> RemoverLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarRemocao(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}

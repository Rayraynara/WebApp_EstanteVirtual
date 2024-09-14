using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("LivrosDisponiveis", "Vendas");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

using System;

namespace WebApp_EstanteVirtual.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Total { get; set; }
    }
}

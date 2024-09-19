using System;

namespace WebApp_EstanteVirtual.Models
{

    public class CompraViewModel
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public string NumeroCartao { get; set; }
        public string DataValidade { get; set; }
        public string CVV { get; set; }
    }


}

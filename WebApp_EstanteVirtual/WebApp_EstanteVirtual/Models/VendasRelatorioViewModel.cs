using System;
using System.Collections.Generic;

namespace WebApp_EstanteVirtual.Models
{
    public class VendasRelatorioViewModel
    {
        public string PeriodoSelecionado { get; set; }
        public List<Venda> Vendas { get; set; }
        public decimal TotalVendido { get; set; }
    }
}

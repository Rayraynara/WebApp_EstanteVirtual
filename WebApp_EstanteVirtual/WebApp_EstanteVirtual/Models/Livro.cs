namespace WebApp_EstanteVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Marca { get; set; } // Editora
        public int QuantidadeEmEstoque { get; set; }
        public DateTime DataVenda { get; set; }
    }
}

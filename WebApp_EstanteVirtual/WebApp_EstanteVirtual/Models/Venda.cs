namespace WebApp_EstanteVirtual.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHoraVenda { get; set; }
        public int Quantidade { get; set; }

        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
    }
}

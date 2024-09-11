using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class CreateLivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Livro é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Preço do Livro é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A Editora do Livro é obrigatória.")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage ="A Imagem da Capa do Livro é obrigatória")]
        public string Capa { get; set; }
    }
}

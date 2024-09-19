using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class EditarLivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório.")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do livro é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A editora é obrigatória.")]
        [Display(Name = "Editora")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser um número não negativo.")]
        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEstoque { get; set; }

        [Display(Name = "Capa")]
        public string Capa { get; set; }

        [Display(Name = "Novo")]
        public bool Novo { get; set; }

        [Required(ErrorMessage = "A classificação é obrigatória.")]
        [Display(Name = "Classificação")]
        public string Classificacao { get; set; }

        [Required(ErrorMessage = "O ano de publicação é obrigatório.")]
        [Range(1700, 2024, ErrorMessage = "Digite um ano válido.")]
        [Display(Name = "Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório.")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
    }
}

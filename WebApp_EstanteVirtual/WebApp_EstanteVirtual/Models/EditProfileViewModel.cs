using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "O Nome de Usuário é obrigatório.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O Nome de Usuário deve ter pelo menos 6 caracteres e no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail não é válido.")]
        public string Email { get; set; }

        /*[Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres e no máximo 100 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senhas não correspondem.")]
        public string? ConfirmacaoSenha { get; set; }*/

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string? CEP { get; set; }

        public string? NumeroCartao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres e no máximo 100 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senhas não correspondem.")]
        public string ConfirmPassword { get; set; }
    }
}
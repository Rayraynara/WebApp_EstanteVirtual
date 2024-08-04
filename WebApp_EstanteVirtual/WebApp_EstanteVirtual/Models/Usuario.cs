using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string NumeroCartao { get; set; }
    }
}

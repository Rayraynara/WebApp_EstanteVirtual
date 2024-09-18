using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp_EstanteVirtual.Models
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string? CEP { get; set; }

        public string? NumeroCartao { get; set; }

        public bool? IsAdmin { get; set; }

        public string? FotoPerfil { get; set; }
    }
}


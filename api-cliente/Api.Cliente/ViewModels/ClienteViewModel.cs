using Api.Cliente.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(60, ErrorMessage = "O {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [CpfValidation(ErrorMessage = "O {0} é inválido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int Sexo { get; set; }

        [EmailAddress(ErrorMessage = "O {0} informado não é válido.")]
        public string Email { get; set; }
    }
}

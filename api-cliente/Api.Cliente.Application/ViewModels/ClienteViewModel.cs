using Api.Cliente.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [CpfValidation(ErrorMessage = "O campo {0} é inválido.")]
        public string Cpf { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Sexo { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; private set; }

        public IEnumerable<TelefoneViewModel> Telefones { get; set; }
        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }
    }
}

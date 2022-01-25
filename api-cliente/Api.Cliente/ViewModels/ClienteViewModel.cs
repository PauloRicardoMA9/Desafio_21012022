using Api.Cliente.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(60, ErrorMessage = "O {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [CpfValidation(ErrorMessage = "O {0} é inválido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int Sexo { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O {0} informado não é válido.")]
        public string Email { get; set; }

        public IEnumerable<TelefoneViewModel> Telefones { get; set; }
        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }
    }
}

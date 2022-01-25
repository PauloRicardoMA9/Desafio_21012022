using Api.Cliente.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCliente { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [IntLenght(1, 10, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} dígitos.")]
        public int Numero { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Bairro { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Cidade { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Estado { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Principal { get; private set; }
    }
}

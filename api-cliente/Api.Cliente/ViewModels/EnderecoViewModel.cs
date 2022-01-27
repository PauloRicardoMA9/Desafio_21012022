using Api.Cliente.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public Guid? IdCliente { get; set; }

        [StringLength(200, ErrorMessage = "O {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [IntLenght(1, 10, ErrorMessage = "O {0} precisa ter entre 1 e 10 dígitos.")]
        public int Numero { get; set; }

        [StringLength(100, ErrorMessage = "O {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [StringLength(100, ErrorMessage = "A {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [StringLength(50, ErrorMessage = "O {0} precisa ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Principal { get; set; }
    }
}

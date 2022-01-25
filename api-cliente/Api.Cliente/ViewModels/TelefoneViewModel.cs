using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class TelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCliente { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter {1} caracteres.", MinimumLength = 2)]
        public string Ddd { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter {1} caracteres.", MinimumLength = 9)]
        public string Numero { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Principal { get; private set; }
    }
}

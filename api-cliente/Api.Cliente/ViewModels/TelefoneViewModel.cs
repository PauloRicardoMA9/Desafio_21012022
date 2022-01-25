using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class TelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O {0} precisa ter {1} caracteres.", MinimumLength = 2)]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(9, ErrorMessage = "O {0} precisa ter {1} caracteres.", MinimumLength = 9)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Principal { get; set; }
    }
}

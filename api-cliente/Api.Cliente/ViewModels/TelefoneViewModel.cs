using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.ViewModels
{
    public class TelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public Guid? IdCliente { get; set; }

        [StringLength(2, ErrorMessage = "O {0} precisa ter {1} caracteres.", MinimumLength = 2)]
        public string Ddd { get; set; }

        [StringLength(9, ErrorMessage = "O {0} precisa ter {1} caracteres.", MinimumLength = 9)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Principal { get; set; }
    }
}

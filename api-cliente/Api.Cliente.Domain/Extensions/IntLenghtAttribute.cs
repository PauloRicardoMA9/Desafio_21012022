using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.Domain.Extensions
{
    public class IntLenghtAttribute : ValidationAttribute
    {
        private int _valorMinimo { get; set; }
        private int _valorMaximo { get; set; }

        public IntLenghtAttribute(int valorMinimo, int valorMaximo)
        {
            _valorMinimo = valorMinimo;
            _valorMaximo = valorMaximo;

            ErrorMessage = "O tamanho de {0} deve ser entre {1} e {2}";
        }

        public override bool IsValid(object valor)
        {
            if (valor.ToString().Length < _valorMinimo || valor.ToString().Length > _valorMaximo)
            {
                return false;
            }

            return true;
        }
    }
}

using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace Api.Cliente.Domain.Extensions
{
    public class CpfValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            if (valor == null)
            {
                return false;
            }

            var cpf = (string)valor;
            return CpfValidation.Validate(cpf);
        }
    }
}

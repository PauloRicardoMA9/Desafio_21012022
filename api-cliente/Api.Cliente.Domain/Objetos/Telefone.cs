using FluentValidation;
using System;

namespace Api.Cliente.Domain.Objetos
{
    public class Telefone : Entidade
    {
        public Guid IdCliente { get; private set; }
        public string Ddd { get; private set; }
        public string Numero { get; private set; }
        public bool Principal { get; private set; }

        public Cliente Cliente { get; set; }

        public void DefinirPrincipal(bool principal)
        {
            Principal = principal;
        }
    }

    public class TelefoneValidation: AbstractValidator<Telefone>
    {
        public TelefoneValidation()
        {
            RuleFor(telefone => telefone.Ddd)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(2, 2)
                    .WithMessage("O {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(telefone => telefone.Numero)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(9, 9)
                    .WithMessage("O {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(telefone => telefone.Principal)
                .NotNull()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}

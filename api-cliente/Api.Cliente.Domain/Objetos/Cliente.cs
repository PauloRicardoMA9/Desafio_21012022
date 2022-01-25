using DocumentValidator;
using FluentValidation;
using System.Collections.Generic;

namespace Api.Cliente.Domain.Objetos
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Sexo Sexo { get; set; }
        public string Email { get; set; }

        public IEnumerable<Telefone> Telefones { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set;}
    }

    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(cliente => cliente.Nome)
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(2, 60)
                    .WithMessage("O {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(cliente => CpfValidation.Validate(cliente.Cpf))
                .Equal(true)
                    .WithMessage("O Cpf fornecido não é válido.");

            RuleFor(cliente => cliente.Sexo)
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.");

            RuleFor(cliente => cliente.Email)
                .EmailAddress()
                    .WithMessage("O {PropertyName} fornecido não é válido.")
                .Length(2, 100)
                    .WithMessage("O {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}

using Api.Cliente.Domain.Extensions;
using FluentValidation;
using System;

namespace Api.Cliente.Domain.Objetos
{
    public class Endereco : Entidade
    {
        public Guid IdCliente { get; private set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool Principal { get; set; }

        public Cliente Cliente { get; set; }
    }

    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(endereco => endereco.Logradouro)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(2, 200)
                    .WithMessage("O {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(endereco => endereco.Numero)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.");

            RuleFor(endereco => new IntLenghtAttribute(1, 50).IsValid(endereco.Numero))
                .Equal(true)
                    .WithMessage("O Numero precisa ter entre 1 e 50 caracteres.");

            RuleFor(endereco => endereco.Bairro)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(2, 100)
                    .WithMessage("O {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(endereco => endereco.Cidade)
                .NotEmpty()
                    .WithMessage("A {PropertyName} precisa ser fornecida.")
                .NotNull()
                    .WithMessage("A {PropertyName} precisa ser fornecida.")
                .Length(2, 100)
                    .WithMessage("A {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(endereco => endereco.Estado)
                .NotNull()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .Length(2, 50)
                    .WithMessage("O {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(endereco => endereco.Principal)
                .NotNull()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}

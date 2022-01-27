using Api.Cliente.Domain.Extensions;
using FluentValidation;
using System;

namespace Api.Cliente.Domain.Objetos
{
    public class Endereco : Entidade
    {
        public Guid IdCliente { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public bool Principal { get; private set; }

        public Cliente Cliente { get; set; }

        public void DefinirLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }
        public void DefinirNumero(int numero)
        {
            Numero = numero;
        }
        public void DefinirBairro(string bairro)
        {
            Bairro = bairro;
        }
        public void DefinirCidade(string cidade)
        {
            Cidade = cidade;
        }
        public void DefinirEstado(string estado)
        {
            Estado = estado;
        }
        public void DefinirPrincipal(bool principal)
        {
            Principal = principal;
        }
    }

    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(endereco => endereco.Logradouro)
                .NotEmpty()
                    .WithMessage("O {PropertyName} precisa ser fornecido.")
                .NotNull()
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

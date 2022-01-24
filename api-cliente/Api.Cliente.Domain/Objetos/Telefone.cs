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

        public Telefone() { }
        public Telefone(Guid idCliente, string ddd, string numero, bool principal)
        {
            ValidarTelefone();

            IdCliente = idCliente;
            Ddd = ddd;
            Numero = numero;
            Principal = principal;
        }

        public void DefinirIdCliente(Guid idCliente)
        {
            ValidarIdCliente();
            IdCliente = idCliente;
        }
        public void DefinirDdd (string ddd)
        {
            ValidarDdd();
            Ddd = ddd;
        }
        public void DefinirNumero (string numero)
        {
            ValidarNumero();
            Numero = numero;
        }
        public void DefinirPrincipal (bool principal)
        {
            ValidarPrincipal();
            Principal = principal;
        }

        public void ValidarIdCliente()
        {
            Validacoes.ValidarSeNaoNulo(IdCliente, "O IdCliente não pode ser nulo.");
        }
        public void ValidarDdd()
        {
            Validacoes.ValidarTamanho(Ddd, 2, 2, "O campo DDD deve conter 2 dígitos.");
        }
        public void ValidarNumero()
        {
            Validacoes.ValidarTamanho(Numero, 9, 9, "O campo Número deve conter 9 dígitos.");
        }
        public void ValidarPrincipal()
        {
            Validacoes.ValidarSeNaoNulo(Principal, "O campo Principal não pode ser nulo.");
        }
        public void ValidarTelefone()
        {
            ValidarIdCliente();
            ValidarDdd();
            ValidarNumero();
            ValidarPrincipal();
        }
    }
}

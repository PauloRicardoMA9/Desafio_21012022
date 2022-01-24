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
            IdCliente = idCliente;
            Ddd = ddd;
            Numero = numero;
            Principal = principal;
        }

        public void DefinirIdCliente(Guid idCliente)
        {
            IdCliente = idCliente;
        }
        public void DefinirDdd (string ddd)
        {
            Ddd = ddd;
        }
        public void DefinirNumero (string numero)
        {
            Numero = numero;
        }
        public void DefinirPrincipal (bool principal)
        {
            Principal = principal;
        }
    }
}

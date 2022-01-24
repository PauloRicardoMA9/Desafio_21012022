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

        public Endereco() { }
        public Endereco(Guid idCliente, string logradouro, int numero, string bairro, string cidade, string estado, bool principal)
        {
            IdCliente = idCliente;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Principal = principal;
        }

        public void DefinirIdCliente(Guid idCliente)
        {
            IdCliente = idCliente;
        }
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
    }
}

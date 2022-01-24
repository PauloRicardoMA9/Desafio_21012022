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
            ValidarEndereco();

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
            ValidarIdCliente();
            IdCliente = idCliente;
        }
        public void DefinirLogradouro(string logradouro)
        {
            ValidarLogradouro();
            Logradouro = logradouro;
        }
        public void DefinirNumero(int numero)
        {
            ValidarNumero();
            Numero = numero;
        }
        public void DefinirBairro(string bairro)
        {
            ValidarBairro();
            Bairro = bairro;
        }
        public void DefinirCidade(string cidade)
        {
            ValidarCidade();
            Cidade = cidade;
        }
        public void DefinirEstado(string estado)
        {
            ValidarEstado();
            Estado = estado;
        }
        public void DefinirPrincipal(bool principal)
        {
            ValidarPrincipal();
            Principal = principal;
        }

        public void ValidarIdCliente()
        {
            Validacoes.ValidarSeNaoNulo(IdCliente, "O IdCliente não pode ser nulo.");
        }
        public void ValidarLogradouro()
        {
            Validacoes.ValidarSeNaoVazio(Logradouro, "O campo Logradouro não pode ser nulo.");
        }
        public void ValidarNumero()
        {
            Validacoes.ValidarSeMaiorIgualQue(Numero, 0, "O campo Número deve ser maior ou igual a 0.");
        }
        public void ValidarBairro()
        {
            Validacoes.ValidarSeNaoVazio(Bairro, "O campo Bairro não pode ser nulo.");
        }
        public void ValidarCidade()
        {
            Validacoes.ValidarSeNaoVazio(Cidade, "O campo Cidade não pode ser nulo.");
        }
        public void ValidarEstado()
        {
            Validacoes.ValidarSeNaoVazio(Estado, "O campo Estado não pode ser nulo.");
        }
        public void ValidarPrincipal()
        {
            Validacoes.ValidarSeNaoNulo(Principal, "O campo Principal não pode ser nulo.");
        }
        public void ValidarEndereco()
        {
            ValidarIdCliente();
            ValidarLogradouro();
            ValidarNumero();
            ValidarBairro();
            ValidarCidade();
            ValidarEstado();
            ValidarPrincipal();
        }
    }
}

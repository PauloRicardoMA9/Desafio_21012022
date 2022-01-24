using System.Collections.Generic;

namespace Api.Cliente.Domain.Objetos
{
    public class Cliente : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Sexo Sexo { get; private set; }
        public string Email { get; private set; }

        public IEnumerable<Telefone> Telefones { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set;}

        public Cliente() { }
        public Cliente(string nome, string cpf, Sexo sexo, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Email = email;
        }

        public void DefinirNome(string nome)
        {
            Nome = nome;
        }
        public void DefinirCpf(string cpf)
        {
            Cpf = cpf;
        }
        public void DefinirSexo(Sexo sexo)
        {
            Sexo = sexo;
        }
        public void DefinirEmail(string email)
        {
            Email = email;
        }
    }
}

using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Services
{
    public class EnderecoService : MainService, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IClienteService _clienteService;

        public EnderecoService(IEnderecoRepository enderecoRepository, IClienteService clienteService, INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _clienteService = clienteService;
        }

        public async Task<bool> Adicionar(Endereco endereco)
        {
            if (!Validar(endereco))
            {
                return false;
            }

            if (PrimeiroCadastroDeEndereco(endereco.IdCliente))
            {
                endereco.DefinirPrincipal(true);
            }
            else if (endereco.Principal == true)
            {
                AlterarEnderecoPrincipal(await ObterEnderecoPrincipal(endereco.IdCliente), false);
            }

            _enderecoRepository.Adicionar(endereco);
            return await _enderecoRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<Endereco>> ObterTodos()
        {
            return await _enderecoRepository.ObterTodos();
        }

        public async Task<Endereco> ObterPorId(Guid id)
        {
            return await _enderecoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Endereco>> ObterPorClienteId(Guid idCliente)
        {
            var enderecos = await _enderecoRepository.Buscar(enderecos => enderecos.IdCliente == idCliente);
            enderecos = ColocarPrincipalNaFrente(enderecos.ToList());
            return enderecos;
        }

        public async Task<bool> Atualizar(Endereco endereco)
        {
            if (!Validar(endereco))
            {
                return false;
            }

            var enderecoPrincipal = await ObterEnderecoPrincipal(endereco.IdCliente);
            if (!Iguais(enderecoPrincipal, endereco) && endereco.Principal)
            {
                AlterarEnderecoPrincipal(await ObterEnderecoPrincipal(endereco.IdCliente), false);
            }
            else if (Iguais(enderecoPrincipal, endereco) && !endereco.Principal)
            {
                var enderecosCadastrados = await ObterEnderecosDoClienteExcluindo(endereco);

                if (enderecosCadastrados.Count() == 0)
                {
                    Notificar("Esse Endereco não pode deixar de ser o Principal pois ele é o único cadastrado.");
                    return false;
                }

                AlterarEnderecoPrincipal(enderecosCadastrados.First(), true);
            }

            _enderecoRepository.Atualizar(endereco);
            return await _enderecoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Remover(Endereco endereco)
        {
            if (endereco.Principal)
            {
                var enderecosCadastrados = await ObterEnderecosDoClienteExcluindo(endereco);

                if (enderecosCadastrados.Count() > 0)
                {
                    AlterarEnderecoPrincipal(enderecosCadastrados.First(), true);
                }
            }

            _enderecoRepository.Remover(endereco.Id);
            return await _enderecoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ClienteCadastrado(Guid idCliente)
        {
            return await _clienteService.ClienteCadastrado(idCliente);
        }

        public async Task<Endereco> ObterEnderecoCadastrado(Guid id)
        {
            return await _enderecoRepository.ObterPorIdAsNoTracking(id);
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
        }


        private bool Validar(Endereco endereco)
        {
            return ExecutarValidacao(new EnderecoValidation(), endereco);
        }
        private bool PrimeiroCadastroDeEndereco(Guid idCliente)
        {
            return !_enderecoRepository.Buscar(enderecoCadastrado => enderecoCadastrado.IdCliente == idCliente && enderecoCadastrado.Principal == true).Result.Any();
        }
        private bool Iguais(Endereco endereco1, Endereco endereco2)
        {
            return endereco1.Id == endereco2.Id;
        }
        private async Task<Endereco> ObterEnderecoPrincipal(Guid idCliente)
        {
            return (await _enderecoRepository.Buscar(enderecoCadastrado => enderecoCadastrado.IdCliente == idCliente && enderecoCadastrado.Principal == true)).First();
        }
        private async Task<IEnumerable<Endereco>> ObterEnderecosDoClienteExcluindo(Endereco endereco)
        {
            return await _enderecoRepository.Buscar(enderecosCadastrados => enderecosCadastrados.IdCliente == endereco.IdCliente && enderecosCadastrados.Id != endereco.Id);
        }
        private void AlterarEnderecoPrincipal(Endereco endereco, bool principal)
        {
            endereco.DefinirPrincipal(principal);
            _enderecoRepository.Atualizar(endereco);
        }
        private List<Endereco> ColocarPrincipalNaFrente(List<Endereco> enderecos)
        {
            foreach (var endereco in enderecos)
            {
                if (endereco.Principal == true)
                {
                    var enderecoPrincipal = endereco;
                    enderecos.Remove(enderecoPrincipal);
                    enderecos.Insert(0, enderecoPrincipal);
                    break;
                }
            }

            return enderecos;
        }
    }
}

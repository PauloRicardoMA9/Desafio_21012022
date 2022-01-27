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
    public class TelefoneService : MainService, ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IClienteService _clienteService;

        public TelefoneService(ITelefoneRepository telefoneRepository, IClienteService clienteService, INotificador notificador) : base(notificador)
        {
            _telefoneRepository = telefoneRepository;
            _clienteService = clienteService;
        }

        public async Task<bool> Adicionar(Telefone telefone)
        {
            if (!TelefoneValido(telefone))
            {
                return false;
            }

            if (PrimeiroCadastroDeTelefone(telefone.IdCliente))
            {
                telefone.DefinirPrincipal(true);
            }
            else if (telefone.Principal == true)
            {
                await AlterarTelefoneAntigoPrincipal(telefone);
            }

            _telefoneRepository.Adicionar(telefone);
            return await _telefoneRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<Telefone>> ObterTodos()
        {
            var telefones = await _telefoneRepository.ObterTodos();
            telefones = ColocarPrincipalNaFrente(telefones);

            return telefones;
        }

        public async Task<Telefone> ObterPorId(Guid id)
        {
            return await _telefoneRepository.ObterPorId(id);
        }

        //public async Task<bool> ClienteCadastrado(Guid id)
        //{
        //    var cliente = await _telefoneRepository.ObterPorIdAsNoTracking(id);

        //    if(cliente == null)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //public async Task<bool> Atualizar(Telefone telefone)
        //{
        //    if (!ValidarTelefone(telefone))
        //    {
        //        return false;
        //    }

        //    if (telefone.Principal == true)
        //    {
        //        var telefonePrincipalAntigo = await _telefoneRepository.ObterPorIdAsNoTracking(telefone.IdCliente);
        //        telefonePrincipalAntigo.DefinirPrincipal(false);
        //        _telefoneRepository.Atualizar(telefonePrincipalAntigo);
        //    }

        //    _telefoneRepository.Atualizar(telefone);
        //    return await _telefoneRepository.UnitOfWork.Commit(); ;
        //}

        //public async Task<bool> Remover(Guid id)
        //{
        //    _telefoneRepository.Remover(id);
        //    return await _telefoneRepository.UnitOfWork.Commit();
        //}

        public async Task<bool> ClienteCadastrado(Guid idCliente)
        {
            return await _clienteService.ClienteCadastrado(idCliente);
        }

        private bool TelefoneValido(Telefone telefone)
        {
            return ExecutarValidacao(new TelefoneValidation(), telefone);
        }

        private bool PrimeiroCadastroDeTelefone(Guid idCliente)
        {
            return !_telefoneRepository.Buscar(telefoneCadastrado => telefoneCadastrado.IdCliente == idCliente && telefoneCadastrado.Principal == true).Result.Any();
        }

        private async Task AlterarTelefoneAntigoPrincipal(Telefone telefone)
        {
            var telefonePrincipalAntigo = (await _telefoneRepository.Buscar(telefoneCadastrado => telefoneCadastrado.IdCliente == telefone.IdCliente && telefoneCadastrado.Principal == true)).First();
            telefonePrincipalAntigo.DefinirPrincipal(false);
            _telefoneRepository.Atualizar(telefonePrincipalAntigo);
        }

        private List<Telefone> ColocarPrincipalNaFrente(List<Telefone> telefones)
        {
            foreach (var telefone in telefones)
            {
                if (telefone.Principal == true)
                {
                    var telefonePrincipal = telefone;
                    telefones.Remove(telefonePrincipal);
                    telefones.Insert(0, telefonePrincipal);
                    break;
                }
            }

            return telefones;
        }

        public void Dispose()
        {
            _telefoneRepository?.Dispose();
        }
    }
}

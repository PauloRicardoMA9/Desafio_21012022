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
            if (!Validar(telefone))
            {
                return false;
            }

            if (PrimeiroCadastroDeTelefone(telefone.IdCliente))
            {
                telefone.DefinirPrincipal(true);
            }
            else if (telefone.Principal == true)
            {
                AlterarTelefonePrincipal(await ObterTelefonePrincipal(telefone.IdCliente), false);
            }

            _telefoneRepository.Adicionar(telefone);
            return await _telefoneRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<Telefone>> ObterTodos()
        {
            return await _telefoneRepository.ObterTodos();
        }

        public async Task<Telefone> ObterPorId(Guid id)
        {
            return await _telefoneRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Telefone>> ObterPorClienteId(Guid idCliente)
        {
            var telefones = await _telefoneRepository.Buscar(telefones => telefones.IdCliente == idCliente);
            telefones = ColocarPrincipalNaFrente(telefones.ToList());
            return telefones;
        }

        public async Task<bool> Atualizar(Telefone telefone)
        {
            if (!Validar(telefone))
            {
                return false;
            }

            var telefonePrincipal = await ObterTelefonePrincipal(telefone.IdCliente);
            if (!Iguais(telefonePrincipal, telefone) && telefone.Principal)
            {
                AlterarTelefonePrincipal(await ObterTelefonePrincipal(telefone.IdCliente), false);
            }
            else if (Iguais(telefonePrincipal, telefone) && !telefone.Principal)
            {
                var telefonesCadastrados = await ObterTelefonesDoClienteExcluindo(telefone);

                if (telefonesCadastrados.Count() == 0)
                {
                    Notificar("Esse Telefone não pode deixar de ser o Principal pois ele é o único cadastrado.");
                    return false;
                }

                AlterarTelefonePrincipal(telefonesCadastrados.First(), true);
            }

            _telefoneRepository.Atualizar(telefone);
            return await _telefoneRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Remover(Telefone telefone)
        {
            if (telefone.Principal)
            {
                var telefonesCadastrados = await ObterTelefonesDoClienteExcluindo(telefone);

                if (telefonesCadastrados.Count() > 0)
                {
                    AlterarTelefonePrincipal(telefonesCadastrados.First(), true);
                }
            }

            _telefoneRepository.Remover(telefone.Id);
            return await _telefoneRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ClienteCadastrado(Guid idCliente)
        {
            return await _clienteService.ClienteCadastrado(idCliente);
        }

        public async Task<Telefone> ObterTelefoneCadastrado(Guid id)
        {
            return await _telefoneRepository.ObterPorIdAsNoTracking(id);
        }

        public void Dispose()
        {
            _telefoneRepository?.Dispose();
        }


        private bool Validar(Telefone telefone)
        {
            return ExecutarValidacao(new TelefoneValidation(), telefone);
        }
        private bool PrimeiroCadastroDeTelefone(Guid idCliente)
        {
            return !_telefoneRepository.Buscar(telefoneCadastrado => telefoneCadastrado.IdCliente == idCliente && telefoneCadastrado.Principal == true).Result.Any();
        }
        private bool Iguais(Telefone telefone1, Telefone telefone2)
        {
            return telefone1.Id == telefone2.Id;
        }
        private async Task<Telefone> ObterTelefonePrincipal(Guid idCliente)
        {
            return (await _telefoneRepository.Buscar(telefoneCadastrado => telefoneCadastrado.IdCliente == idCliente && telefoneCadastrado.Principal == true)).First();
        }
        private async Task<IEnumerable<Telefone>> ObterTelefonesDoClienteExcluindo(Telefone telefone)
        {
            return await _telefoneRepository.Buscar(telefonesCadastrados => telefonesCadastrados.IdCliente == telefone.IdCliente && telefonesCadastrados.Id != telefone.Id);
        }
        private void AlterarTelefonePrincipal(Telefone telefone, bool principal)
        {
            telefone.DefinirPrincipal(principal);
            _telefoneRepository.Atualizar(telefone);
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
    }
}

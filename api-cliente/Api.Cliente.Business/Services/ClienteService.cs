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
    public class ClienteService : MainService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Domain.Objetos.Cliente cliente)
        {
            if (!Validar(cliente))
            {
                return false;
            }

            if (ClienteCadastradoComCpf(cliente.Cpf, cliente.Id))
            {
                Notificar("Já existe um cliente cadastrado com este CPF.");
                return false;
            }

            if (ClienteCadastradoComEmail(cliente.Email, cliente.Id))
            {
                Notificar("Já existe um cliente cadastrado com este Email.");
                return false;
            }

            _clienteRepository.Adicionar(cliente);
            return await _clienteRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<Domain.Objetos.Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }

        public async Task<Domain.Objetos.Cliente> ObterPorId(Guid id)
        {
            return await _clienteRepository.ObterPorId(id);
        }

        public async Task<bool> ClienteCadastrado(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorIdAsNoTracking(id);
            
            if(cliente == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Atualizar(Domain.Objetos.Cliente cliente)
        {
            if (!Validar(cliente))
            {
                return false;
            }

            if (ClienteCadastradoComCpf(cliente.Cpf, cliente.Id))
            {
                Notificar("Já existe um cliente cadastrado com este CPF.");
                return false;
            }

            if (ClienteCadastradoComEmail(cliente.Email, cliente.Id))
            {
                Notificar("Já existe um cliente cadastrado com este Email.");
                return false;
            }

            _clienteRepository.Atualizar(cliente);
            return await _clienteRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Remover(Guid id)
        {
            _clienteRepository.Remover(id);
            return await _clienteRepository.UnitOfWork.Commit();
        }

        private bool Validar(Domain.Objetos.Cliente cliente)
        {
            return ExecutarValidacao(new ClienteValidation(), cliente);
        }

        private bool ClienteCadastradoComCpf(string cpf, Guid id)
        {
            return _clienteRepository.Buscar(clienteCadastrado => clienteCadastrado.Cpf == cpf && clienteCadastrado.Id != id).Result.Any();
        }

        private bool ClienteCadastradoComEmail(string email, Guid id)
        {
            return _clienteRepository.Buscar(clienteCadastrado => clienteCadastrado.Email == email && clienteCadastrado.Id != id).Result.Any();
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}

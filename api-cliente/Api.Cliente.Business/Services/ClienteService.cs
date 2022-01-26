using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;
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
            if (!ValidarCliente(cliente))
            {
                return false;
            }

            if (ClienteCadastradoComCpf(cliente.Cpf))
            {
                Notificar("Já existe um cliente cadastrado com este CPF.");
                return false;
            }

            if (ClienteCadastradoComEmail(cliente.Email))
            {
                Notificar("Já existe um cliente cadastrado com este Email.");
                return false;
            }

            _clienteRepository.Adicionar(cliente);
            return await _clienteRepository.UnitOfWork.Commit();
        }

        private bool ValidarCliente(Domain.Objetos.Cliente cliente)
        {
            return ExecutarValidacao(new ClienteValidation(), cliente);
        }

        private bool ClienteCadastradoComCpf(string cpf)
        {
            return _clienteRepository.Buscar(clienteCadastrado => clienteCadastrado.Cpf == cpf).Result.Any();
        }

        private bool ClienteCadastradoComEmail(string email)
        {
            return _clienteRepository.Buscar(clienteCadastrado => clienteCadastrado.Email == email).Result.Any();
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}

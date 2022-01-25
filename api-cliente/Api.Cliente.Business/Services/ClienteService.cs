using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Cliente.Business.Services
{
    public class ClienteService : MainService, IClienteService
    {
        public ClienteService(INotificador notificador) : base(notificador)
        {
        }

        public bool Adicionar(Domain.Objetos.Cliente cliente)
        {
            if (!ValidarCliente(cliente))
            {
                return false;
            }

            if(_clienteRepository.Buscar)

            return true;
        }


        private bool ValidarCliente(Domain.Objetos.Cliente cliente)
        {
            return ExecutarValidacao(new ClienteValidation(), cliente);
        }

        public void Dispose()
        {
            return;
        }
    }
}

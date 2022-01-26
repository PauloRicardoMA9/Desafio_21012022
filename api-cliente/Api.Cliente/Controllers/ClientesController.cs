using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClientesController(IMapper mapper, IClienteService clienteService, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("cliente/adicionar")]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            var cliente = _mapper.Map<Domain.Objetos.Cliente>(clienteViewModel);
            var operacaoSucedida = await _clienteService.Adicionar(cliente);

            if (operacaoSucedida)
            {
                return CreatedAtAction("Create", null);
            }

            return ReturnBadRequest();
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<IEnumerable<ClienteViewModel>> Read()
        {
            var clientes = await _clienteService.ObterTodos();
            var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            return clientesViewModel;
        }

        [HttpGet]
        [Route("cliente/{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Read(Guid id)
        {
            var cliente = await _clienteService.ObterPorId(id);
            
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            return clienteViewModel;
        }
    }
}

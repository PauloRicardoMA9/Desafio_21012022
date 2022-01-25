using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            var cliente = _mapper.Map<Domain.Objetos.Cliente>(clienteViewModel);
            var operacaoSucedida = _clienteService.Adicionar(cliente);

            if (operacaoSucedida)
            {
                return CreatedAtAction("Adicionar", null);
            }

            return ReturnBadRequest();
        }
    }
}

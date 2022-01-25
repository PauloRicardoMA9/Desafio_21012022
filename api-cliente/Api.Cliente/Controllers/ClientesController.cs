using Api.Cliente.Business.Intefaces;
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

        public ClientesController(IMapper mapper, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("cliente/adicionar")]
        public async Task<IActionResult> Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Domain.Objetos.Cliente>(clienteViewModel);
            //var operacaoSucedida = await _clienteService.Adicionar(cliente);
            var operacaoSucedida = true;

            if (operacaoSucedida)
            {
                return CreatedAtAction("Adicionar", null);
            }

            return ReturnBadRequest();
        }
    }
}

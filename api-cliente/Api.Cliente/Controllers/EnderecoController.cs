using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.Domain.Objetos;
using Api.Cliente.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Controllers
{
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IMapper mapper, IEnderecoService enderecoService, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);
            var clienteCadastrado = await _enderecoService.ClienteCadastrado(endereco.IdCliente);

            if (!clienteCadastrado)
            {
                return NotFound();
            }

            var operacaoSucedida = await _enderecoService.Adicionar(endereco);

            if (operacaoSucedida)
            {
                return CreatedAtAction("Create", null);
            }

            return ReturnBadRequest();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> ReadById(Guid id)
        {
            var endereco = await _enderecoService.ObterPorId(id);

            if (endereco == null)
            {
                return NotFound();
            }

            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);

            return enderecoViewModel;
        }

        [HttpGet]
        [Route("~/api/enderecos/cliente/{idCliente:guid}")]
        public async Task<IEnumerable<EnderecoViewModel>> ReadByClienteId(Guid idCliente)
        {
            var enderecos = await _enderecoService.ObterPorClienteId(idCliente);

            var enderecosViewModels = _mapper.Map<IEnumerable<EnderecoViewModel>>(enderecos);

            return enderecosViewModels;
        }
        
        [HttpGet]
        [Route("~/api/enderecos")]
        public async Task<IEnumerable<EnderecoViewModel>> ReadAll()
        {
            var enderecos = await _enderecoService.ObterTodos();
            var enderecosViewModels = _mapper.Map<IEnumerable<EnderecoViewModel>>(enderecos);

            return enderecosViewModels;
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, EnderecoViewModel enderecoViewModel)
        {
            var endereco = await _enderecoService.ObterEnderecoCadastrado(id);
            if (endereco == null)
            {
                return NotFound();
            }

            ModelState.Remove("IdCliente");
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            endereco.DefinirLogradouro(enderecoViewModel.Logradouro);
            endereco.DefinirNumero(enderecoViewModel.Numero);
            endereco.DefinirBairro(enderecoViewModel.Bairro);
            endereco.DefinirCidade(enderecoViewModel.Cidade);
            endereco.DefinirEstado(enderecoViewModel.Estado);
            endereco.DefinirPrincipal(enderecoViewModel.Principal);

            var operacaoSucedida = await _enderecoService.Atualizar(endereco);

            if (operacaoSucedida)
            {
                return NoContent();
            }

            return ReturnBadRequest();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var endereco = await _enderecoService.ObterEnderecoCadastrado(id);
            if (endereco == null)
            {
                return NotFound();
            }

            var operacaoSucedida = await _enderecoService.Remover(endereco);

            if (operacaoSucedida)
            {
                return NoContent();
            }

            return ReturnBadRequest();
        }
    }
}

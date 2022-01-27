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
    [Route("api/telefone")]
    public class TelefoneController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(IMapper mapper, ITelefoneService telefoneService, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _telefoneService = telefoneService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TelefoneViewModel telefoneViewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            var telefone = _mapper.Map<Telefone>(telefoneViewModel);
            var clienteCadastrado = await _telefoneService.ClienteCadastrado(telefone.IdCliente);

            if (!clienteCadastrado)
            {
                return NotFound();
            }

            var operacaoSucedida = await _telefoneService.Adicionar(telefone);

            if (operacaoSucedida)
            {
                return CreatedAtAction("Create", null);
            }

            return ReturnBadRequest();
        }

        [HttpGet]
        [Route("~/api/telefones")]
        public async Task<IEnumerable<TelefoneViewModel>> Read()
        {
            var telefones = await _telefoneService.ObterTodos();
            var telefoneViewModels = _mapper.Map<IEnumerable<TelefoneViewModel>>(telefones);

            return telefoneViewModels;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<TelefoneViewModel>> Read(Guid id)
        {
            var telefone = await _telefoneService.ObterPorId(id);

            if (telefone == null)
            {
                return NotFound();
            }

            var telefoneViewModel = _mapper.Map<TelefoneViewModel>(telefone);

            return telefoneViewModel;
        }

        [HttpGet]
        [Route("~/api/telefones/cliente/{idCliente:guid}")]
        public async Task<IEnumerable<TelefoneViewModel>> ReadByCliente(Guid idCliente)
        {
            var telefones = await _telefoneService.ObterPorCliente(idCliente);

            var telefonesViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(telefones);

            return telefonesViewModel;
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, TelefoneViewModel telefoneViewModel)
        {
            var telefone = await _telefoneService.ObterTelefoneCadastrado(id);
            if (telefone == null)
            {
                return NotFound();
            }

            ModelState.Remove("IdCliente");
            if (!ModelState.IsValid)
            {
                return NotificarErroModelInvalida(ModelState);
            }

            telefone.DefinirDdd(telefoneViewModel.Ddd);
            telefone.DefinirNumero(telefoneViewModel.Numero);
            telefone.DefinirPrincipal(telefoneViewModel.Principal);

            var operacaoSucedida = await _telefoneService.Atualizar(telefone);

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
            var telefone = await _telefoneService.ObterTelefoneCadastrado(id);
            if (telefone == null)
            {
                return NotFound();
            }

            var operacaoSucedida = await _telefoneService.Remover(telefone);

            if (operacaoSucedida)
            {
                return NoContent();
            }

            return ReturnBadRequest();
        }
    }
}

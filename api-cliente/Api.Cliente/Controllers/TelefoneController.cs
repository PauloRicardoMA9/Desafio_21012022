﻿using Api.Cliente.Business.Intefaces;
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

        //[HttpGet]
        //[Route("~/api/clientes")]
        //public async Task<IEnumerable<ClienteViewModel>> Read()
        //{
        //    var clientes = await _telefoneService.ObterTodos();
        //    var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

        //    return clientesViewModel;
        //}

        //[HttpGet]
        //[Route("{id:guid}")]
        //public async Task<ActionResult<ClienteViewModel>> Read(Guid id)
        //{
        //    var cliente = await _telefoneService.ObterPorId(id);
            
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

        //    return clienteViewModel;
        //}

        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> Put(Guid id, ClienteViewModel clienteViewModel)
        //{
        //    var clienteCadastrado = await _telefoneService.ClienteCadastrado(id);
        //    if (!clienteCadastrado)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return NotificarErroModelInvalida(ModelState);
        //    }

        //    clienteViewModel.Id = id;
        //    var cliente = _mapper.Map<Domain.Objetos.Cliente>(clienteViewModel);

        //    var operacaoSucedida = await _telefoneService.Atualizar(cliente);

        //    if (operacaoSucedida)
        //    {
        //        return NoContent();
        //    }

        //    return ReturnBadRequest();
        //}

        //[HttpDelete]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var clienteCadastrado = await _telefoneService.ClienteCadastrado(id);
        //    if (!clienteCadastrado)
        //    {
        //        return NotFound();
        //    }
            
        //    var operacaoSucedida = await _telefoneService.Remover(id);

        //    if (operacaoSucedida)
        //    {
        //        return NoContent();
        //    }

        //    return ReturnBadRequest();
        //}
    }
}
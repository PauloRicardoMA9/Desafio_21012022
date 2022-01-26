using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Api.Cliente.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            var NaoTemNotificacao = !_notificador.TemNotificacao();
            return NaoTemNotificacao;
        }

        protected ActionResult NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(model => model.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                Notificar(errorMessage);
            }

            return ReturnBadRequest();
        }

        protected ActionResult ReturnBadRequest()
        {
            return BadRequest(new
            {
                errors = _notificador.ObterNotificacoes().Select(notificacao => notificacao.Mensagem)
            });
        }

        protected ActionResult ReturnNotFound()
        {
            return NotFound(new
            {
                errors = _notificador.ObterNotificacoes().Select(notificacao => notificacao.Mensagem)
            });
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }
    }
}

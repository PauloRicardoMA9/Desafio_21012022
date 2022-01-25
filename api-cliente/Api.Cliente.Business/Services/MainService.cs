using FluentValidation;
using FluentValidation.Results;
using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Notificacoes;
using Api.Cliente.Domain.Objetos;

namespace Api.Cliente.Business.Services
{
    public abstract class MainService
    {
        private readonly INotificador _notificador;

        protected MainService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) where TValidacao : AbstractValidator<TEntidade> where TEntidade : Entidade
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
            { 
                return true; 
            }

            Notificar(validator);

            return false;
        }
    }
}
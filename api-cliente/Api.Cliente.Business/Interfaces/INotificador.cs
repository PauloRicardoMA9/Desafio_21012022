using Api.Cliente.Business.Notificacoes;
using System.Collections.Generic;

namespace Api.Cliente.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Adicionar(Notificacao notificacao);
    }
}
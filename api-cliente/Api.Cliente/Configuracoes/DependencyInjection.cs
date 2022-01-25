using Api.Cliente.Business.Intefaces;
using Api.Cliente.Business.Interfaces;
using Api.Cliente.Business.Notificacoes;
using Api.Cliente.Business.Services;
using Api.Cliente.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Cliente.Configuracoes
{
    public static class DependencyInjection
    {
        public static void ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ClienteDbContext>();
        }
    }
}

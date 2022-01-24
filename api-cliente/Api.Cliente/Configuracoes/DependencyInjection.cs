using Api.Cliente.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Cliente.Configuracoes
{
    public static class DependencyInjection
    {
        public static void ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ClienteDbContext>();
        }
    }
}

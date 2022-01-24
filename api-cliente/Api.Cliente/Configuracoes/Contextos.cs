using Api.Cliente.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Cliente.Configuracoes
{
    public static class Contextos
    {
        public static void AddContextos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClienteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

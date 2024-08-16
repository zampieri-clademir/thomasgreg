using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ThomasGregChallenge.Base.Configuracoes;
using ThomasGregChallenge.Domain.Repositorio;
using ThomasGregChallenge.Infra.Data.Contexts;
using ThomasGregChallenge.Infra.Data.Feature;

namespace ThomasGregChallenge.Infra.Data
{
    public static class Inicializacao
    {
        public static void AdicionarDependenciasRepositorio(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            services.AddScoped((Func<IServiceProvider, ClienteDbContext>)((ctx) =>
            {
                var options = new DbContextOptionsBuilder<ClienteDbContext>()
                                 .UseSqlServer(appSettings.ConnectionString,
                                  opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)).Options;

                return new Contexts.ClienteDbContext(options);
            }));

            services.AddTransient<IRepositorioCliente, ClienteRepository>();
        }
    }
}

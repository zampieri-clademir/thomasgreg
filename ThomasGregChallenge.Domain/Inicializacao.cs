using Microsoft.Extensions.DependencyInjection;

using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.Execucao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.PersistirDados;

namespace ThomasGregChallenge.Domain
{
    public static class Inicializacao
    {
        public static IServiceCollection InicializarDomain(this IServiceCollection services)
        {
            AdicionarDependenciasClientes(services);

            return services;
        }

        private static void AdicionarDependenciasClientes(IServiceCollection services)
        {
            services.AddTransient<IPersistirDadosAdicionarCliente, PersistirDadosAdicionarClienteImpl>();
            services.AddTransient<IExecucaoAdicionarCliente, ExecucaoAdicionarClienteImpl>();
        }
    }
}

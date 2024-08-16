using Microsoft.AspNetCore.Mvc.Controllers;

using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

using System.Diagnostics.CodeAnalysis;

namespace ThomasGregChallenge.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorExtensions
    {
        public static void AddSimpleInjector(this IServiceCollection services, Container container)
        {
            // Define que a inst�ncia vai existir dentro de um determinado escopo (impl�cito ou expl�cito).
            // Assume o fluxo de controle dos m�todos ass�ncronos automaticamente
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            // Ao invocar o m�todo de extens�o UseSimpleInjectorAspNetRequestScoping, o tempo que uma 
            // requisi��o est� ativa � o per�odo que um escopo vai estar ativo. 
            services.UseSimpleInjectorAspNetRequestScoping(container);

            services.EnableSimpleInjectorCrossWiring(container);
        }

        public static void AdicionarDependenciasBanco(this IServiceCollection services, IConfiguration configuration)
        {
            Infra.Data.Inicializacao.AdicionarDependenciasRepositorio(services, configuration);
        }
    }
}

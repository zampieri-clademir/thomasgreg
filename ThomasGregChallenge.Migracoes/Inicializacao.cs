

using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using ThomasGregChallenge.Base.Configuracoes;
using ThomasGregChallenge.Base.Constantes;

namespace ThomasGregChallenge.Migracoes
{
    public static class Inicializacao
    {
        public static void InicializarMigracoes(this IServiceCollection services, IConfiguration configuration)
        {
            // Carregar configura��es do appsettings.json
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            var serviceProvider = services.AddFluentMigratorCore()
                     .ConfigureRunner(rb => rb
                     .AddSqlServer()
                     .WithGlobalCommandTimeout(TimeSpan.FromMinutes(60))
                     .WithGlobalConnectionString(appSettings.ConnectionString)
                     .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
                     .ScanIn(Assembly.GetExecutingAssembly()).For.EmbeddedResources()
                 )
                 .AddSingleton<IConventionSet>(new DefaultConventionSet(Constantes.NomeSchema, null))
                 .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                runner.MigrateUp();
            }
        }
    }
}

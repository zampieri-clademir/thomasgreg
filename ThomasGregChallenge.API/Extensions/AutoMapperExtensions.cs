using System.Diagnostics.CodeAnalysis;

using ThomasGregChallenge.API.Features.Cliente;
using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;

namespace ThomasGregChallenge.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            try
            {
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(AdicionarClienteApplicationMapper).Assembly);
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(ClienteControllerMapper).Assembly);
            }
            catch (Exception)
            {
            }
        }
    }
}

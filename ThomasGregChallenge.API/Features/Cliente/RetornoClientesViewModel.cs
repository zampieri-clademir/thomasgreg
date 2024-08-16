using System.Diagnostics.CodeAnalysis;

using ThomasGregChallenge.Application.Dto.Cliente;

namespace ThomasGregChallenge.API.Features.Cliente
{
    [ExcludeFromCodeCoverage]
    public class RetornoClientesViewModel
    {
        public List<ClienteDto> ListaClientes { get; set; }
    }
}


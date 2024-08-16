using System.Diagnostics.CodeAnalysis;

namespace ThomasGregChallenge.Application.Dto.Cliente
{
    [ExcludeFromCodeCoverage]
    public class ClienteDto
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string LogotipoBase64 { get; set; }
    }
}

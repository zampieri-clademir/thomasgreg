using System.Diagnostics.CodeAnalysis;
using ThomasGregChallenge.Domain.Entidades.Logotipo;
using ThomasGregChallenge.Domain.Entidades.Logradouro;

namespace ThomasGregChallenge.Domain.Entidades.Cliente
{
    [ExcludeFromCodeCoverage]
    public class ClienteVO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public LogotipoVO Logotipo { get; set; }
        public List<LogradouroVO> Logradouros { get; set; }
    }
}

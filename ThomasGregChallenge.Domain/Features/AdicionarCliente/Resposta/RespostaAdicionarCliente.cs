using ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta
{
    public class RespostaAdicionarCliente
    {
        public Guid IdCliente { get; set; }

        public ContextoAdicionarCliente Contexto { get; set; }
    }
}

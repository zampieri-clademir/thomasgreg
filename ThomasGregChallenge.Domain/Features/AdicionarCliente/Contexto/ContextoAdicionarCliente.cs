using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto
{
    public class ContextoAdicionarCliente : IContextoAdicionarCliente<RequisicaoAdicionarCliente>
    {
        public RequisicaoAdicionarCliente Requisicao { get; set; }
    }
}

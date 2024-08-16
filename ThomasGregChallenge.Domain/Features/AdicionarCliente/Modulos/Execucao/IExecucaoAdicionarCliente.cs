using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.Execucao
{
    public interface IExecucaoAdicionarCliente
    {
        RespostaAdicionarCliente Processar(RequisicaoAdicionarCliente requisicao);
    }
}

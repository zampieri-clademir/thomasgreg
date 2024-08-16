using ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.PersistirDados;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.Execucao
{
    /// <summary>
    /// Classe principal onde faz o gerenciamento de todos os passos da execução da feature
    /// </summary>
    public class ExecucaoAdicionarClienteImpl : IExecucaoAdicionarCliente 
    {
        private readonly IPersistirDadosAdicionarCliente _persistirDados;

        public ExecucaoAdicionarClienteImpl(IPersistirDadosAdicionarCliente persistirDados)
        {
            _persistirDados = persistirDados;

        }

        public RespostaAdicionarCliente Processar(RequisicaoAdicionarCliente requisicao)
        {
            ContextoAdicionarCliente contexto = new()
            {
                Requisicao = requisicao
            };

            var result = _persistirDados.Processar(contexto);

            return new RespostaAdicionarCliente() { Contexto = contexto, IdCliente = result };
        }
    }
}

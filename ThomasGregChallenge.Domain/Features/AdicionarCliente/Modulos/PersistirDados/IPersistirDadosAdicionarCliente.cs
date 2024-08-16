using ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.PersistirDados
{
    public interface IPersistirDadosAdicionarCliente
    {
        Guid Processar(ContextoAdicionarCliente contexto);
    }
}

using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Repositorio;

namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.PersistirDados
{
    /// <summary>
    /// Classe responsável por acessar o repositório e efetuar as transasões no banco.
    /// </summary>
    public class PersistirDadosAdicionarClienteImpl : IPersistirDadosAdicionarCliente
    {
        IRepositorioCliente _repositorio;

        public PersistirDadosAdicionarClienteImpl(IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }

        public Guid Processar(ContextoAdicionarCliente contexto)
        {
            throw new NotImplementedException();
        }
    }
}

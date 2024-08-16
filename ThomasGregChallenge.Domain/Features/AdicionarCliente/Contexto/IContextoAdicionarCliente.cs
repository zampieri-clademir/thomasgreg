namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto
{
    public interface IContextoAdicionarCliente<TRequisicao>
    {
        TRequisicao Requisicao { get; set; }
    }
}

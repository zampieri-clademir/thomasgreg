using ThomasGregChallenge.Domain.Entidades.Cliente;

namespace ThomasGregChallenge.Domain.Repositorio
{
    public interface IRepositorioCliente
    {
        Task<long> SalvarAsync(ClienteVO Cliente);

        Task<ClienteVO> BuscarPorId(long id);

        Task<IEnumerable<ClienteVO>> BuscarTodos();

        Task<bool> RemoverAsync(long id);
    }
}

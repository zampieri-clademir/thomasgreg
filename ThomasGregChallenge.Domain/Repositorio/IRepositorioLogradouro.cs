using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Entidades.Logradouro;

namespace ThomasGregChallenge.Domain.Repositorio
{
    public interface IRepositorioLogradouro
    {
        Task<Guid> SalvarAsync(ClienteVO Cliente);

        Task<IEnumerable<LogradouroVO>> BuscarTodos(long clinteId);

        Task<bool> RemoverAsync(long logradouroId);
    }
}

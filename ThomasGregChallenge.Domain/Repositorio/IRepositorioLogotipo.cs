using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Entidades.Logotipo;

namespace ThomasGregChallenge.Domain.Repositorio
{
    public interface IRepositorioLogotipo
    {
        Task<Guid> SalvarAsync(LogotipoVO logotipo);

        Task<LogotipoVO> BuscarPorId(Guid logotipoId);

        Task<IEnumerable<LogotipoVO>> BuscarTodos();

        Task<bool> RemoverAsync(Guid logotipoId);
    }
}

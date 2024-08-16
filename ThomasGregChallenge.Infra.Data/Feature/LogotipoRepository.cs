using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Entidades.Logotipo;
using ThomasGregChallenge.Domain.Repositorio;
using ThomasGregChallenge.Infra.Data.Contexts;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class LogotipoRepository : IRepositorioLogotipo
    {
        ClienteDbContext _context;

        public Task<LogotipoVO> BuscarPorId(Guid logotipoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LogotipoVO>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverAsync(Guid logotipoId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SalvarAsync(LogotipoVO logotipo)
        {
            throw new NotImplementedException();
        }
    }
}

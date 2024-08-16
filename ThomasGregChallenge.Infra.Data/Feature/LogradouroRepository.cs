using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Entidades.Logradouro;
using ThomasGregChallenge.Domain.Repositorio;
using ThomasGregChallenge.Infra.Data.Contexts;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class LogradouroRepository : IRepositorioLogradouro
    {
        ClienteDbContext _context;

        public Task<IEnumerable<LogradouroVO>> BuscarTodos(long clinteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverAsync(long logradouroId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SalvarAsync(ClienteVO Cliente)
        {
            throw new NotImplementedException();
        }
    }
}

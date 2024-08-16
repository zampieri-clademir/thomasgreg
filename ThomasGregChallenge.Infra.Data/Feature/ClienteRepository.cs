using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Repositorio;
using ThomasGregChallenge.Infra.Data.Contexts;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class ClienteRepository : IRepositorioCliente
    {
        ClienteDbContext _context;

        public Task<ClienteVO> BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteVO>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> SalvarAsync(ClienteVO Cliente)
        {
            throw new NotImplementedException();
        }
    }
}

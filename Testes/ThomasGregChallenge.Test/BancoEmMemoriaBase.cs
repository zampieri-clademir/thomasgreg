
using Microsoft.EntityFrameworkCore;
using ThomasGregChallenge.Infra.Data.Contexts;

using System.Diagnostics.CodeAnalysis;
using ThomasGregChallenge.Domain.Entidades.Cliente;

namespace ThomasGregChallenge.Test
{
    [ExcludeFromCodeCoverage]
    public abstract class BancoEmMemoriaBase
    {
        protected ClienteDbContext ClienteContext { get; private set; }

        protected BancoEmMemoriaBase()
        {
            Init();
        }

        private void Init()
        {
            var optionsCore = new DbContextOptionsBuilder<ClienteDbContext>()
                .UseInMemoryDatabase("ClienteDbContext")
                .Options;

            ClienteContext = new ClienteDbContext(optionsCore);

            Populate();

            ClienteContext.SaveChanges();
        }

        private void Populate()
        {
            PopulateApplicationUserData();
        }

        private void PopulateApplicationUserData()
        {
            ClienteContext.Set<ClienteVO>().Add(new ClienteVO() { Id = 1, Nome = "Clademir Zampieri", Email="mr.zampieri@live.com"});
        }
    }
}

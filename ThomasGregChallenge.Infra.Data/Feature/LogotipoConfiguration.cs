using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ThomasGregChallenge.Base.Constantes;
using ThomasGregChallenge.Domain.Entidades.Cliente;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class LogotipoConfiguration : IEntityTypeConfiguration<ClienteVO>
    {
        public void Configure(EntityTypeBuilder<ClienteVO> builder)
        {
            builder.ToTable("Logotipo", Constantes.NomeSchema);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Nome);
        }
    }
}

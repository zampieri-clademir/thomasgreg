using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ThomasGregChallenge.Base.Constantes;
using ThomasGregChallenge.Domain.Entidades.Cliente;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteVO>
    {
        public void Configure(EntityTypeBuilder<ClienteVO> builder)
        {
            builder.ToTable("Cliente", Constantes.NomeSchema);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Nome);
            builder.Property(c => c.Email);
            builder.Property(c => c.Logotipo.Id).HasColumnName("LogotipoId");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ThomasGregChallenge.Base.Constantes;
using ThomasGregChallenge.Domain.Entidades.Logradouro;

namespace ThomasGregChallenge.Infra.Data.Feature
{
    public class LogradouroConfiguration : IEntityTypeConfiguration<LogradouroVO>
    {
        public void Configure(EntityTypeBuilder<LogradouroVO> builder)
        {
            builder.ToTable("Logradouro", Constantes.NomeSchema);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Descricao);
            builder.Property(c => c.Cep);
            builder.Property(c => c.Bairro);
            builder.Property(c => c.Cidade);
            builder.Property(c => c.Uf);
            builder.Property(c => c.Pais);
            builder.Property(c => c.Complemento);
            builder.Property(c => c.DataCriacao);
            builder.Property(c => c.DataAtualizacao);
        }
    }
}

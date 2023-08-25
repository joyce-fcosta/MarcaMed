using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configuration
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeExame).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.ObservacaoameExame).HasColumnType("VARCHAR(100)");
            builder.HasOne(x => x.TipoExame).WithMany().HasForeignKey(p => p.IdTipoExame).OnDelete(DeleteBehavior.NoAction);

        }
    }
}

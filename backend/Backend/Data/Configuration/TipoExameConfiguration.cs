using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Backend.Data.Configuration
{
    public class TipoExameConfiguration : IEntityTypeConfiguration<TipoExame>
    {
        public void Configure(EntityTypeBuilder<TipoExame> builder)
        {
            builder.ToTable("TipoExame");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeTipoExame).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.DescricaoTipoExame).HasColumnType("VARCHAR(256)");

        }

    }
}

using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Backend.Data.Configuration
{
    public class MarcaConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("MarcaConsulta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataHora).HasColumnType("DATE");
            builder.HasOne(x => x.Exame).WithMany().HasForeignKey(p => p.IdExame);
            builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(p => p.IdPaciente);

        }
    }
}

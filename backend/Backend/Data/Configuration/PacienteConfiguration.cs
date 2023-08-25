using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Configuration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("VARCHAR(8)").IsRequired();
            builder.Property(x => x.Sexo).HasColumnType("VARCHAR(1)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(60)").IsRequired();
        }
    }
}

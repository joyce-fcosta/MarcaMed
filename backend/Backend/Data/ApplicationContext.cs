using Backend.Data.Configuration;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Exame> exames { get; set; }
        public DbSet<TipoExame> tipoExames { get; set; }
        public DbSet<Consulta> consultas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=JOYCE\\SQLECOMMERCE; Initial Catalog = CONSULTA; Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new ExameConfiguration());
            modelBuilder.ApplyConfiguration(new TipoExameConfiguration());
            modelBuilder.ApplyConfiguration(new MarcaConsultaConfiguration());

            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}

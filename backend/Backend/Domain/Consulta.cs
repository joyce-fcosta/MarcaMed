
namespace Backend.Domain
{
    public class Consulta
    {
        public int Id { get; set; }
        public Int64 Protocolo { get; set; }
        public DateTime DataHora { get; set; }
        public int IdPaciente { get; set; }
        public int IdExame{ get; set; }
        public Paciente Paciente { get; set; } = new Paciente();
        public Exame Exame { get; set; } = new Exame();
    }
}

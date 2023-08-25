

namespace Backend.Domain
{
    public class Exame
    {
        public int Id { get; set; }
        public string NomeExame { get; set; }
        public string ObservacaoameExame { get; set; }
        public int IdTipoExame { get; set; }
        public virtual TipoExame TipoExame { get; set; }
    }
}

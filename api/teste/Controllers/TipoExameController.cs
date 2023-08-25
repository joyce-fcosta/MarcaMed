using Backend.Domain;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TipoExameController : Controller
    {
        repository repository { get; set; } = new repository();
        service service { get; set; } = new service();

        [HttpPost("api/inserirTipoExame")]
        public IActionResult CadastrarTipoExame([FromBody] TipoExame tipoExame)
        {

            service.SalvarTipoExame(tipoExame);
            return Ok("Inserido com sucesso!");
        }

        [HttpGet("api/listaTipoExame")]
        public List<TipoExame> ListaTipoExame()
        {
            return service.ListaTipoExames();
        }


        [HttpGet("api/selecionadotipoexame/{index}")]
        public TipoExame TipoExameEspecifico(int index)
        {
            return service.SelecionadoTipoExame(index);
        }



        [HttpGet("pesquisaTipoExame/{cpfOuNome}")] //Como é para passar cpf ou nome vai ser pego pelo post, informação sensivel
        public Paciente PesquisarTipoExame(string cpfOuNome)
        {
            var paciente = repository.ConsultaPaciente(cpfOuNome);
            return paciente;
        }


        /* [HttpPut("atualizaTipoExame/{id}")]
         public int AtualizarTipoExame(int id, [FromBody] TipoExame tipoExame)
         {
             return repository.AtualizarTipoExame(id, tipoExame);
         }*/

        [HttpDelete("deletaTipoExame/{id}")]
        public int DeletarTipoExame(int id)
        {
            return repository.DeletarTipoExame(id);
        }
    }
}

using Backend.Domain;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ExameController : Controller
    {
        repository repository { get; set; } = new repository();
        service service { get; set; }=new service();

        [HttpPost("api/cadastrarExame")]
        public IActionResult CadastrarExame([FromBody] Exame exame)
        {

            service.SalvarExame(exame);
            return Ok("Inserido com sucesso!");
        }

        [HttpGet("api/listaexames")] //Como é para passar cpf ou nome vai ser pego pelo post, informação sensivel
        public List<Exame> PesquisarPaciente()
        {
            return service.ListarExames();
        }


       /* [HttpPut("atualizaPaciente/{id}")]
        public int AtualizarPaciente(int id, [FromBody] Exame exame)
        {
            repository cadastrar = new repository();
            return cadastrar.AtualizarExame(id, exame);
        }*/

        [HttpDelete("deletaPaciente/{id}")]
        public int DeletarPaciente(int id)
        {
            repository cadastrar = new repository();
            return cadastrar.DeletarExame(id);
        }
    }
}

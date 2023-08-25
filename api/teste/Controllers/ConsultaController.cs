using Microsoft.AspNetCore.Mvc;
using Backend.Domain;
using Backend.Services;

namespace api.Controllers
{
    public class ConsultaController : Controller
    {
        private service service = new service();

        [HttpGet("listaconsulta")]
        public List<Consulta> ListarConsultas()
        {
            return service.ConsultasDiarias();

        }

    }
}

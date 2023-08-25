using Backend.Data;
using Backend.Domain;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace teste.Controllers
{
    /*    private ApplicationContext _appContext { get; set; }
        public Repository(ApplicationContext applicationContext)
        {
            this._appContext = applicationContext;
         }*/
    public class PacienteController : Controller
    {
        public repository repository { get; set; } = new repository();
        public service service { get; set; } = new service();


        [HttpPost("api/inserirPaciente")]
        public IActionResult CadastrarPaciente([FromBody] Paciente paciente)
        {
            //Repository cadastrar = new Repository();
            repository.InserirPaciente(paciente);
            return Ok("SUCCESS");
        }

        [HttpGet("pesquisaPaciente/{cpfOuNome}")] //Como é para passar cpf ou nome vai ser pego pelo post, informação sensivel
        public Paciente PesquisarPaciente(string cpfOuNome)
        {
            //List<Paciente> listaPacientes = new List<Paciente>();
            var listaPacientes = repository.ConsultaPaciente(cpfOuNome);
            return listaPacientes;
        }

/*
        [HttpPut("atualizaPaciente/{id}")]
        public int AtualizarPaciente(int id, [FromBody] Paciente paciente)
        {
            return repository.AtualizarPaciente(id, paciente);
        }*/

        [HttpDelete("api/deletaPaciente/{id}")]
        public int DeletarPaciente(int id)
        {
            return repository.DeletarPaciente(id);
        }

        [HttpGet("api/listarTodosPacientes")]
        public List<Paciente> TodosPacientes()
        {
            return service.ListarPacientes();
        }


    }
}
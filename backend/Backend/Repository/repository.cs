using Backend.Domain;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class repository
    {
        private ApplicationContext _appContext { get; set; } = new ApplicationContext();


        #region Paciente

        public int InserirPaciente(Paciente paciente)
        {
            _appContext.Set<Paciente>().Add(paciente);
            return _appContext.SaveChanges();

        }

        public int DeletarPaciente(int id)
        {
            var consulta = _appContext.pacientes.Where(x => x.Id == id).ExecuteDelete();

            return consulta;

        }

        public List<Paciente> ListarTodosPacientes()
        {
            var consulta = _appContext.Set<Paciente>().ToList();
            return consulta;
        }

        /*        public int AtualizarPaciente(int id, Paciente paciente)
                {
                    var consulta = _appContext.pacientes.Find(id);
                    if (consulta != null)
                    {
                        consulta.Cpf = paciente.Cpf;
                        consulta.Telefone = paciente.Telefone;
                        consulta.Sexo = paciente.Sexo;
                        consulta.DataNascimento = paciente.DataNascimento;
                        consulta.Email = paciente.Email;
                        consulta.Nome = paciente.Nome;

                        _appContext.Update(consulta);
                    }
                    var retorno = _appContext.SaveChanges();
                    return retorno;

                }*/



        #endregion Paciente


        #region Exame
        public int InserirExame(Exame exame)
        {
            _appContext.Set<Exame>().Add(exame);
            return _appContext.SaveChanges();

        }

        public int DeletarExame(int id)
        {
            var consulta = _appContext.exames.Where(x => x.Id == id).ExecuteDelete();

            return consulta;

        }


        /* public int AtualizarExame(int id, Exame exame)
         {
             var consulta = _appContext.exames.Find(id);
             if (consulta != null)
             {
                 consulta.NomeExame = exame.NomeExame;
                 consulta.ObservacaoameExame = exame.ObservacaoameExame;

                 _appContext.Update(consulta);
             }
             var retorno = _appContext.SaveChanges();
             return retorno;

         }*/


        public List<Exame> ListarExames()
        {
            var consulta = _appContext.exames.ToList();
            return consulta;
        }
        #endregion Exame


        #region TipoExame
        public int InserirTipoExame(TipoExame tipoExame)
        {
            _appContext.Set<TipoExame>().Add(tipoExame);
            return _appContext.SaveChanges();
        }

        public int DeletarTipoExame(int id)
        {
            var consulta = _appContext.tipoExames.Where(x => x.Id == id).ExecuteDelete();
            return consulta;

        }

        /*  public int AtualizarTipoExame(int id, TipoExame tipoExame)
          {
              var consulta = _appContext.tipoExames.Find(id);
              if (consulta != null)
              {
                  consulta.NomeTipoExame = tipoExame.NomeTipoExame;
                  consulta.DescricaoTipoExame = tipoExame.DescricaoTipoExame;

                  _appContext.Update(consulta);
              }
              var retorno = _appContext.SaveChanges();
              return retorno;

          }*/


        public TipoExame PegarTipoExame(int index) {

            return _appContext.Set<TipoExame>().Where(p => p.Id == index).Single();
        }

        #endregion TipoExame


        #region Consulta

        public Paciente ConsultaPaciente(string CpfOuNome)
        {
            var consulta = _appContext.Set<Paciente>().Where(p => p.Nome.Contains(CpfOuNome) || p.Cpf.Equals(CpfOuNome)).Single();

            return consulta;
        }
        public List<Consulta> TodasAsConsultas()
        {
            return _appContext.Set<Consulta>().ToList();
        }
        /*  public Int64 GeraProtocolo()
          {
              var consulta = _appContext.consultas.OrderByDescending(m => m.Protocolo).FirstOrDefault(); //Vai ordenar de forma decrescente e retornar o top 1
              if (consulta == null)
              {
                  consulta.Protocolo = 1000000000;
              }
              consulta.Protocolo = consulta.Protocolo += 1;
              return consulta.Protocolo;
          }*/

        public int InserirConsulta(Consulta consulta)
        {
            _appContext.Set<Consulta>().Add(consulta);
            var resultado = _appContext.SaveChanges();
            return resultado;
        }

        public List<TipoExame> ListaTipoExames()
        {
            return _appContext.Set<TipoExame>().ToList();
        }

        public List<Exame> ListarTipoExames(string IdTipoExameInfo)
        {
            var consulta = _appContext.exames.Where(x => x.IdTipoExame.Equals(IdTipoExameInfo)).ToList(); //Listar aqui pelo id da FK exame
            return consulta;
        }


    }
    #endregion Consulta
}



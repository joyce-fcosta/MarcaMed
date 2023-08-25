using Backend.Repository;
using Backend.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services
{
    public class service
    {
        private repository _Repositorio { get; set; } = new repository();
        public bool ConsulaCpf(string cpf)
        {
            try
            {
                if (Convert.ToInt64(cpf) != 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Consulta> ConsultasDiarias()
        {

            //return DateTime.Now.Date.ToString("dd-MM-yyyy");

            try
            {
                return _Repositorio.TodasAsConsultas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Exame> ListarExames()
        {
            try
            {
                return _Repositorio.ListarExames().ToList();
            }catch (Exception) { throw; }
        }
        public List<Paciente> ListarPacientes()
        {
            try
            {
                return _Repositorio.ListarTodosPacientes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CadastrarPaciente(Paciente paciente)
        {
            int retorno;
            try
            {
                if (ConsulaCpf(paciente.Cpf))
                {
                    var pacienteConsultado = _Repositorio.ConsultaPaciente(paciente.Cpf);

                    if (pacienteConsultado == null)
                    {
                        retorno = _Repositorio.InserirPaciente(paciente);
                        if (retorno == 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SalvarTipoExame(TipoExame tipoExame)
        {
            try
            {
                if (tipoExame != null)
                {
                    _Repositorio.InserirTipoExame(tipoExame);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SalvarExame(Exame exame)
        {
            try
            {
                if (exame != null)
                {
                    _Repositorio.InserirExame(exame);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TipoExame> ListaTipoExames()
        {
            try
            {
                return _Repositorio.ListaTipoExames();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoExame SelecionadoTipoExame(int index)
        {
            try
            {
                return _Repositorio.PegarTipoExame(index);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // ao selecionar a data incluir apenas horarios mostrar horarios diponiveis (Verificar disponibilidade de implementeação)
        //Cri
        public int MarcarConsulta(Consulta consulta)
        {

            /*
                Pesquisar Paciente
                    Se não existir, deverá cadastrar
                Se tiver cadastrado proseguir
                Escolher o Tipo do Exame
                Escolher o Exame
                Escolher a Data
                Escolher O horário
                    Verificar se já não existe um consulta marcada para essa data e horário
                        Se existir, pedir para escolher novo horário
                Se não existir permitir inserir a consulta e retornar o número de protocolo
             */


            //fazer o tratamento da data no  front, pode ser no back -> receber a data e usando datetime converter e caso for sab ou dom impedir cadastro da consulta
            int resultado = 0;
            if (_Repositorio.ConsultaPaciente(consulta.Paciente.Cpf) != null)
            {
                resultado = _Repositorio.InserirConsulta(consulta);
            }

            return resultado;
        }



        /*public int AtualizarPaciente(int id, Paciente paciente)
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
    }
}

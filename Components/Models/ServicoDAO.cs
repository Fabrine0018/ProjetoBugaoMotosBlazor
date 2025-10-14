using AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;


namespace AppBugaoMotoFVLE.Components.Models
{
    public class ServicoDAO
    {
        private readonly Conexao _conexao;

        public ServicoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void InserirServico(Servico servico)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO Serviço VALUES (null, @_nome_ser, @_codigo_ser, @_prestador_ser, @_valor_ser)");
                comando.Parameters.AddWithValue("@_nome_ser", servico.Nome);
                comando.Parameters.AddWithValue("@_codigo_ser", servico.Codigo);
                comando.Parameters.AddWithValue("@_prestador_ser", servico.Prestador);
                comando.Parameters.AddWithValue("@_valor_ser", servico.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Servico> ListarServico()
        {
            var lista = new List<Servico>();

            var comando = _conexao.CreateCommand("SELECT * FROM Serviço");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var servico = new Servico
                {
                    IdSer = leitor.GetInt32("id_ser"),
                    Nome = DAOHelper.GetString(leitor, "nome_ser"),
                    Codigo = DAOHelper.GetString(leitor, "codigo_ser"),
                    Prestador = DAOHelper.GetString(leitor, "prestador_ser"),
                    Valor = leitor.GetDouble("valor_ser"),

                };
                //IdSer = leitor.GetInt32("id_ser");
                //servico.Nome = DAOHelper.GetString(leitor, "nome_ser");
                //servico.Codigo = DAOHelper.GetString(leitor, "codigo_ser");
                //servico.Prestador = DAOHelper.GetString(leitor, "prestador_ser");
                //servico.Valor = leitor.GetDouble("valor_ser");

                lista.Add(servico);
            }
            return lista;
        }
    }
}


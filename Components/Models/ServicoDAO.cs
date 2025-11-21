using AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;
using Mysqlx.Prepare;
using MySqlX.XDevAPI;
using static Mysqlx.Expect.Open.Types.Condition.Types;


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
                var comando = _conexao.CreateCommand("INSERT INTO Servico VALUES (null, @_nome_ser, @_codigo_ser, @_prestador_ser, @_valor_ser)");
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

            var comando = _conexao.CreateCommand("SELECT * FROM Servico");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var servico = new Servico
                {
                    Id = leitor.GetInt32("id_ser"),
                    Nome = DAOHelper.GetString(leitor, "nome_ser"),
                    Codigo = DAOHelper.GetString(leitor, "codigo_ser"),
                    Prestador = DAOHelper.GetString(leitor, "prestador_ser"),
                    Valor = leitor.GetDouble("valor_ser"),

                };

                lista.Add(servico);
            }
            return lista;
        }

        public Servico? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT *FROM servico WHERE id_ser = @_id");
            comando.Parameters.AddWithValue("@_id", id);
            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var servico = new Servico();
                servico.Id = leitor.GetInt32("id_ser");
                servico.Codigo = DAOHelper.GetString(leitor, "codigo_ser");
                servico.Nome = DAOHelper.GetString(leitor, "nome_ser");
                servico.Prestador = DAOHelper.GetString(leitor, "prestador_ser");
                servico.Valor = DAOHelper.GetDouble(leitor, "valor_ser");
                return servico;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Servico servico)
        {
            try
            {
                var comando = _conexao.CreateCommand("UPDATE servico SET nome_ser = @_nome, codigo_ser = @_codigo, prestador_ser = @_prestador, valor_ser = @_valor WHERE id_ser = @_id");
                comando.Parameters.AddWithValue("@_nome", servico.Nome);
                comando.Parameters.AddWithValue("@_codigo", servico.Codigo);
                comando.Parameters.AddWithValue("@_prestador", servico.Prestador);
                comando.Parameters.AddWithValue("@_valor", servico.Valor);
                comando.Parameters.AddWithValue("@_id", servico.Id);
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM servico WHERE id_ser = @_id");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

        }
    }
}


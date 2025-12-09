using AppBugaoMotoFVLE.Configs;

namespace AppBugaoMotoFVLE.Components.Models
{
    public class CaixaDAO
    {
        private readonly Conexao _conexao;

        public CaixaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void AbrirCaixa(Caixa caixa)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO caixa VALUES (null, @_data, @_horaAbe, @_func, null, @_saldoAbe, null)");
                comando.Parameters.AddWithValue("@_data", caixa.Data);
                comando.Parameters.AddWithValue("@_horaAbe", caixa.HoraAberto);
                comando.Parameters.AddWithValue("@_func", caixa.Funcionario);
                comando.Parameters.AddWithValue("@_saldoAbe", caixa.SaldoAberto);

                comando.ExecuteNonQuery();
            }catch (Exception)
            {
                throw;
            }
        }

        public void FecharCaixa(Caixa caixa)
        {
            try
            {
                var comando = _conexao.CreateCommand("UPDATE caixa SET hora_fechado_cai = @_horaFec, saldo_fechado_cai = @_saldoFec WHERE id_cai = @_id");
                comando.Parameters.AddWithValue("@_horaFec", caixa.HoraFechado);
                comando.Parameters.AddWithValue("@_saldoFec", caixa.SaldoFechado);
                comando.Parameters.AddWithValue("@_id", caixa.Id);
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public List<Caixa> ListarCaixa()
        {
            var listaCai = new List<Caixa>();
            var comando = _conexao.CreateCommand("SELECT *FROM caixa");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var caixa = new Caixa();
                caixa.Id = leitor.GetInt32("id_cai");
                caixa.Data = DAOHelper.GetString(leitor, "data_cai");
                caixa.HoraAberto = DAOHelper.GetString(leitor, "hora_aberto_cai");
                caixa.Funcionario = DAOHelper.GetString(leitor, "funcionario_cai");
                caixa.HoraFechado = DAOHelper.GetString(leitor, "hora_fechado_cai");
                caixa.SaldoAberto = DAOHelper.GetString(leitor, "saldo_aberto_cai");
                caixa.SaldoFechado = DAOHelper.GetString(leitor, "saldo_fechado_cai");

                listaCai.Add(caixa);
            }
            return listaCai;
        }
    }
}

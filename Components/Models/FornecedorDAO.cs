using AppBugaoMotoFVLE.Configs;
using static Mysqlx.Expect.Open.Types.Condition.Types;
namespace AppBugaoMotoFVLE.Components.Models
{
    public class FornecedorDAO
    {
        private readonly Conexao _conexao;
        public FornecedorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public void InserirFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO fornecedor VALUES (null, @_nome_empre_for, @_nome_funcio_for, @_telefone_for, @_complemento_for, @_cnpj_for, @_rua_for, @_estado_for, @_cidade_for, @_bairro_for)");
                comando.Parameters.AddWithValue("@_nome_empre_for", fornecedor.Nome);
                comando.Parameters.AddWithValue("@_nome_funcio_for", fornecedor.Responsavel);
                comando.Parameters.AddWithValue("@_telefone_for", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@_complemento_for", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@_cnpj_for", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@_rua_for", fornecedor.Rua);
                comando.Parameters.AddWithValue("@_estado_for", fornecedor.Estado);
                comando.Parameters.AddWithValue("@_cidade_for", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@_bairro_for", fornecedor.Bairro);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Fornecedor> ListarFornecedores()
        {
            var lista = new List<Fornecedor>();
            var comando = _conexao.CreateCommand("SELECT * FROM fornecedor");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var fornecedor = new Fornecedor
                {
                    Id = leitor.GetInt32("id_for"),
                    Nome = DAOHelper.GetString(leitor, "nome_empre_for"),
                    Responsavel = DAOHelper.GetString(leitor, "nome_funcio_for"),
                    CNPJ = DAOHelper.GetString(leitor, "cnpj_for"),
                    Rua = DAOHelper.GetString(leitor, "rua_for"),
                    Bairro = DAOHelper.GetString(leitor, "bairro_for"),
                    Cidade = DAOHelper.GetString(leitor, "cidade_for"),
                    Estado = DAOHelper.GetString(leitor, "estado_for"),
                    Complemento = DAOHelper.GetString(leitor, "complemento_for"),
                    Telefone = DAOHelper.GetString(leitor, "telefone_for")
                };
                lista.Add(fornecedor);
            }
            return lista;
        }
    }
}

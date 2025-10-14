using AppBugaoMotoFVLE.Configs;
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
                var comando = _conexao.CreateCommand("INSERT INTO fornecedor VALUES (null, @_nome_forne, @_nome_responsa_forne, @_telefoner_respon_forne, @_telefoner_forne, @_numero_forne, @_complemento_forne, @_cep_forne, @_cnpj_forne, @_rua_forne, @_estado_forne, @_cidade_forne, @_bairro_forne, @_razao_social_forne)");
                comando.Parameters.AddWithValue("@_nome_forne", fornecedor.Nome);
                comando.Parameters.AddWithValue("@_nome_responsa_forne", fornecedor.Responsavel);
                comando.Parameters.AddWithValue("@_telefoner_respon_forne", fornecedor.TelefoneRes);
                comando.Parameters.AddWithValue("@_telefoner_forne", fornecedor.TelefoneEmp);
                comando.Parameters.AddWithValue("@_numero_forne", fornecedor.NumeroCasaApt);
                comando.Parameters.AddWithValue("@_complemento_forne", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@_cep_forne", fornecedor.CEP);
                comando.Parameters.AddWithValue("@_cnpj_forne", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@_rua_forne", fornecedor.Rua);
                comando.Parameters.AddWithValue("@_estado_forne", fornecedor.Estado);
                comando.Parameters.AddWithValue("@_cidade_forne", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@_bairro_forne", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@_razao_social_forne", fornecedor.RazaoSocial);
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
            var comando = _conexao.CreateCommand("SELECT *FROM fornecedor");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var fornecedor = new Fornecedor
                {
                    Id = leitor.GetInt32("id_forne"),
                    Nome = DAOHelper.GetString(leitor, "nome_forne"),
                    Responsavel = DAOHelper.GetString(leitor, "nome_responsa_forne"),
                    CEP = DAOHelper.GetString(leitor, "cep_forne"),
                    CNPJ = DAOHelper.GetString(leitor, "cnpj_forne"),
                    TelefoneRes = DAOHelper.GetString(leitor, "telefoner_respon_forne"),
                    Rua = DAOHelper.GetString(leitor, "rua_forne"),
                    Bairro = DAOHelper.GetString(leitor, "bairro_forne"),
                    Cidade = DAOHelper.GetString(leitor, "cidade_forne"),
                    Estado = DAOHelper.GetString(leitor, "estado_forne"),
                    NumeroCasaApt = DAOHelper.GetString(leitor, "numero_forne"),
                    Complemento = DAOHelper.GetString(leitor, "complemento_forne"),
                    RazaoSocial = DAOHelper.GetString(leitor, "razao_social_forne"),
                    TelefoneEmp = DAOHelper.GetString(leitor, "telefoner_forne")
                };
                lista.Add(fornecedor);
            }
            return lista;
        }
    }
}

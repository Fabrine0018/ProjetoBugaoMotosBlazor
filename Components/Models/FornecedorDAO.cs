using AppBugaoMotoFVLE.Components.Pages;
using AppBugaoMotoFVLE.Configs;
using MySqlX.XDevAPI;
using System.Security.Cryptography;
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
        public Fornecedor? BuacarIdFone(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM fornecedor WHERE id_for = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();
            if (leitor.Read())
            {
                var fornecedor = new Fornecedor();
                fornecedor.Id = leitor.GetInt32("id_for");
                fornecedor.Nome = DAOHelper.GetString(leitor, "nome_empre_for");
                fornecedor.Responsavel = DAOHelper.GetString(leitor, "nome_funcio_for");
                fornecedor.CNPJ = DAOHelper.GetString(leitor, "cnpj_for");
                fornecedor.Rua = DAOHelper.GetString(leitor, "rua_for");
                fornecedor.Bairro = DAOHelper.GetString(leitor, "bairro_for");
                fornecedor.Cidade = DAOHelper.GetString(leitor, "cidade_for");
                fornecedor.Estado = DAOHelper.GetString(leitor, "estado_for");
                fornecedor.Complemento = DAOHelper.GetString(leitor, "complemento_for");
                fornecedor.Telefone = DAOHelper.GetString(leitor, "telefone_for");
                return fornecedor;
            }
            else
            {
                return null;
            }

        }

        public void AtualizarForne(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conexao.CreateCommand("UPDATE fornecedor SET nome_empre_for = @_nome, nome_funcio_for = @_nome_funcio, " +
                    " cnpj_for = @_cnpj, rua_for = @_rua,  bairro_for = @_bairro,  cidade_for = @_cidade, estado_for = @_estado, complemento_for = @_complemento, telefone_for = @_telefone WHERE id_for = @_id");
                comando.Parameters.AddWithValue("@_nome", fornecedor.Nome);
                comando.Parameters.AddWithValue("@_nome_funcio", fornecedor.Responsavel);
                comando.Parameters.AddWithValue("@_cnpj", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@_rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@_bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@_cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@_estado", fornecedor.Estado);
                comando.Parameters.AddWithValue("@_complemento", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@_telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@_id", fornecedor.Id);
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void DeletarFor(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM fornecedor WHERE id_for = @id");
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
        }
    }


}


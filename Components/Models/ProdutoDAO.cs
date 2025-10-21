namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;
using static Mysqlx.Expect.Open.Types.Condition.Types;

public class ProdutoDAO
{
    private readonly Conexao _conexao;

    public ProdutoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public void InserirProduto(Produto produto)
    {
        try
        {
            var comando = _conexao.CreateCommand("INSERT INTO Produto VALUES (null, @_nome_pro, @_codigo_pro, @_quantidade_pro, @_valor_pro )");
            comando.Parameters.AddWithValue("@_nome_pro", produto.Nome);
            comando.Parameters.AddWithValue("@_codigo_pro", produto.Codigo);
            comando.Parameters.AddWithValue("@_quantidade_pro", produto.Quantidade);
            comando.Parameters.AddWithValue("@_valor_pro", produto.Valor);


            comando.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public List<Produto> ListarTodos()
    {
        var lista = new List<Produto>();

        var comando = _conexao.CreateCommand("SELECT * FROM produto;");
        var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            var produto = new Produto();
            produto.Id = leitor.GetInt32("id_pro");
            produto.Nome = DAOHelper.GetString(leitor, "nome_pro");
            produto.Codigo = DAOHelper.GetString(leitor, "codigo_pro");
            produto.Quantidade = leitor.GetInt32("quantidade_pro");
            produto.Valor = leitor.GetDouble("valor_pro");

            lista.Add(produto);
        }
        return lista;
    }

}


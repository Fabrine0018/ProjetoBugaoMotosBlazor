namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;

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
            var comando = _conexao.CreateCommand("INSERT INTO Produto VALUES (null, @_nome_prod, @_codigo_prod, @_quantidade_prod, @_valor_prod,null)");
            comando.Parameters.AddWithValue("@_nome_prod", produto.Nome);
            comando.Parameters.AddWithValue("@_codigo_prod", produto.Codigo);
            comando.Parameters.AddWithValue("@_quantidade_prod", produto.Quantidade);
            comando.Parameters.AddWithValue("@_valor_prod", produto.Valor);


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
            produto.IdProduto = leitor.GetInt32("id_prod");
            produto.Nome = DAOHelper.GetString(leitor, "nome_prod");
            produto.Codigo = DAOHelper.GetString(leitor, "codigo_prod");
            produto.Quantidade = leitor.GetInt32("quantidade_prod");
            produto.Valor = leitor.GetDouble("valor_prod");

            lista.Add(produto);
        }
        return lista;
    }

}


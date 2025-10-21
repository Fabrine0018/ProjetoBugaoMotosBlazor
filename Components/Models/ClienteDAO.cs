namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using static Mysqlx.Expect.Open.Types.Condition.Types;


public class ClienteDAO
{
    private readonly Conexao _conexao;

    public ClienteDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public void InserirCliente(Cliente cliente)
    {
        try
        {
            var comando = _conexao.CreateCommand("INSERT INTO Cliente VALUES (null, @_nome_cli, @_telefone_cli, @_estado_cli, @_cpf_cli, @_cidade_cli, @_complemento_cli, @_bairro_cli, @_rua_cli)");
            comando.Parameters.AddWithValue("@_nome_cli", cliente.Nome);
            comando.Parameters.AddWithValue("@_telefone_cli",cliente.Telefone);
            comando.Parameters.AddWithValue("@_estado_cli", cliente.Estado);
            comando.Parameters.AddWithValue("@_cpf_cli", cliente.Cpf);
            comando.Parameters.AddWithValue("@_cidade_cli", cliente.Cidade);
            comando.Parameters.AddWithValue("@_complemento_cli", cliente.Complemento);
            comando.Parameters.AddWithValue("@_bairro_cli", cliente.Bairro);
            comando.Parameters.AddWithValue("@_rua_cli", cliente.Rua);

       
            comando.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }
  
    public List<Cliente> ListarCliente()
    {
        var listaClie = new List<Cliente>();
        var comando = _conexao.CreateCommand("SELECT * FROM Cliente");
        var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            var cliente = new Cliente();
            cliente.Id = leitor.GetInt32("id_cli");
            cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
            cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
            cliente.Estado = DAOHelper.GetString(leitor, "estado_cli");
            cliente.Cpf = DAOHelper.GetString(leitor, "cpf_cli");
            cliente.Cidade = DAOHelper.GetString(leitor, "cidade_cli");
            cliente.Complemento = DAOHelper.GetString(leitor, "complemento_cli");
            cliente.Bairro = DAOHelper.GetString(leitor, "bairro_cli");
            cliente.Rua = DAOHelper.GetString(leitor, "rua_cli");

            listaClie.Add(cliente);
        }

        return listaClie;
    }
}


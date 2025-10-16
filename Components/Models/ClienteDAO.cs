namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;


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
            var comando = _conexao.CreateCommand("INSERT INTO Cliente VALUES (null, @_nome_clie, @_telefone_clie, @_estado_clie, @_cpf_clie, @_cidade_clie, @_complemento_clie, @_bairro_clie, @_rua_clie, @_cep_clie)");
            comando.Parameters.AddWithValue("@_nome_clie", cliente.Nome);
            comando.Parameters.AddWithValue("@_telefone_clie",cliente.Telefone);
            comando.Parameters.AddWithValue("@_estado_clie", cliente.Estado);
            comando.Parameters.AddWithValue("@_cpf_clie", cliente.Cpf);
            comando.Parameters.AddWithValue("@_cidade_clie", cliente.Cidade);
            comando.Parameters.AddWithValue("@_complemento_clie", cliente.Complemento);
            comando.Parameters.AddWithValue("@_bairro_clie", cliente.Bairro);
            comando.Parameters.AddWithValue("@_rua_clie", cliente.Rua);
            comando.Parameters.AddWithValue("@_cep_clie", cliente.Cep);
       
            comando.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Eduardo arrumou
    public List<Cliente> ListarCliente()
    {
        var listaClie = new List<Cliente>();
        var comando = _conexao.CreateCommand("SELECT * FROM Cliente");
        var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            //ERRO AQUI
            var cliente = new Cliente();
            cliente.IdCli = leitor.GetInt32("id_clie");
            cliente.Nome = DAOHelper.GetString(leitor, "nome_clie");
            cliente.Telefone = DAOHelper.GetString(leitor, "telefone_clie");
            cliente.Estado = DAOHelper.GetString(leitor, "estado_clie");
            cliente.Cpf = DAOHelper.GetString(leitor, "cpf_clie");
            cliente.Cidade = DAOHelper.GetString(leitor, "cidade_clie");
            cliente.Complemento = DAOHelper.GetString(leitor, "complemento_clie");
            cliente.Bairro = DAOHelper.GetString(leitor, "bairro_clie");
            cliente.Rua = DAOHelper.GetString(leitor, "rua_clie");
            cliente.Cep = DAOHelper.GetString(leitor, "cep_clie");

            listaClie.Add(cliente);
        }

        return listaClie;
    }
}


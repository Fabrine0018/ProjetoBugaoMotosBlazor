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

    public Cliente? BuscarPorId(int id)
    {
        var comando = _conexao.CreateCommand("SELECT * FROM cliente WHERE id_cli = @id;");
        comando.Parameters.AddWithValue("@id", id);

        var leitor = comando.ExecuteReader();
        if (leitor.Read())
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
            return cliente;
        }
        else
        {
            return null;
        }

    }

    public void Atualizar (Cliente cliente)
    {
        try
        {
            var comando = _conexao.CreateCommand("UPDATE cliente SET nome_cli = @_nome, telefone_cli = @_telefone, estado_cli = @_estado, cpf_cli = @_cpf, cidade_cli = @_cidade, complemento_cli = @_complemento, bairro_cli = @_bairro, rua_cli = @_rua WHERE id_cli = @_id");
            comando.Parameters.AddWithValue("@_nome", cliente.Nome);
            comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
            comando.Parameters.AddWithValue("@_estado", cliente.Estado);
            comando.Parameters.AddWithValue("@_cpf", cliente.Cpf);
            comando.Parameters.AddWithValue("@_cidade", cliente.Cidade);
            comando.Parameters.AddWithValue("@_complemento", cliente.Complemento);
            comando.Parameters.AddWithValue("@_bairro", cliente.Bairro);
            comando.Parameters.AddWithValue("@_rua", cliente.Rua);
            comando.Parameters.AddWithValue("@_id", cliente.Id);
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
            var comando = _conexao.CreateCommand("DELETE FROM cliente WHERE id_cli = @id");
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

        }
        catch
        {
            throw;
        }
    }
}


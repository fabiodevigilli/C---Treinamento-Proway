using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSharpBasicoWinFormBancoDadosAula8
{
    class ClienteADO
    {
        public string Cadastrar(Cliente cliente)
        {
            // o que estiver declarado no parâmetro deste "USING", serão métodos que chamarão uma função dispose automaticamente ao final das chaves
            using (SqlConnection connection = new SqlConnection()) // o connection string, pode ser passado como parametro no último SqlConnection
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fabio.devigilli\Documents\TesteADO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText = @"INSERT INTO CLIENTES (NOME,CPF,EMAIL,TELEFONE) VALUES (@NOME,@CPF,@EMAIL,@TELEFONE)";
                command.Parameters.AddWithValue("@NOME", cliente.Nome);
                command.Parameters.AddWithValue("@CPF", cliente.CPF);
                command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                command.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteScalar(); // retorna algo que pode passar na query, exemplo: após o values do insert,
                    // poderíamos fazer um "; select scope_identity()" que retornaria o ID criado.
                    // int idGerado = Convert.ToInt32(command.ExecuteScalar());
                    // command.ExecuteNonQuery(); este metodo retorna o numero de linhas afetadas
                    return "Cadastrado com Sucesso";
                }
                catch (Exception ex) // passa aqui caso haja erro
                {
                    return "Favor contate o administrador";
                }
                //finally // Sempre será executado, independente se passe no catch
                //{
                //    // connection.Close();
                //    connection.Dispose(); // só fecha a conexão, caso ela tenha sido aberta
                //}            
            }
        }

        public string Editar(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fabio.devigilli\Documents\TesteADO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText = @"UPDATE CLIENTES SET NOME = @NOME, EMAIL = @EMAIL, TELEFONE = @TELEFONE WHERE ID = @ID";
                command.Parameters.AddWithValue("@NOME", cliente.Nome);
                command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                command.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
                command.Parameters.AddWithValue("@ID", cliente.ID);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Editado com Sucesso";
                }
                catch (Exception ex)
                {
                    return "Favor contate o administrador";
                }
            }
        }

        public string Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fabio.devigilli\Documents\TesteADO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText = @"DELETE FROM CLIENTES WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    int registrosEcluidos = command.ExecuteNonQuery();
                    if (registrosEcluidos == 1)
                    {
                        return "Excluído com Sucesso";
                    }
                    else
                    {
                        return "Nenhum registro foi excluído";
                    }
                }
                catch (Exception ex)
                {
                    return "Favor contate o administrador";
                }
            }
        }

        public List<Cliente> LerClientes()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fabio.devigilli\Documents\TesteADO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText = @"SELECT * FROM CLIENTES";
                command.Connection = connection;
                try
                {
                    List<Cliente> clientes = new List<Cliente>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // enquanto houver registros leia
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.ID = (int)reader["ID"];
                        cliente.Nome = (string)reader["Nome"];
                        cliente.CPF = (string)reader["CPF"];
                        cliente.Email = (string)reader["Email"];
                        cliente.Telefone = (string)reader["Telefone"];
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

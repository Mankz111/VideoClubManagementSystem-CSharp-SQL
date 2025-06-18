using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Sistema_de_Gestão_de_Videoclube
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int NIF { get; set; }
        public int Telefone { get; set; }

        private string GetConnectionStringFromConfig()
        {
            return ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
        }

        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Nome) || Nome.Length > 100)
            {
                errorMessage = "O nome é obrigatório e não pode exceder 100 caracteres.";
                return false;
            }
            if (!Regex.IsMatch(Nome, @"^[a-zA-Z\p{L}\s\-']+$"))
            {
                errorMessage = "O nome não deve conter números ou caracteres especiais inválidos.";
                return false;
            }

            string nifString = NIF.ToString();
            if (nifString.Length != 9 || !nifString.All(char.IsDigit))
            {
                errorMessage = "O NIF deve ter 9 dígitos numéricos.";
                return false;
            }

            string telefoneString = Telefone.ToString();
            if (telefoneString.Length != 9 || !telefoneString.All(char.IsDigit))
            {
                errorMessage = "O telefone deve ter 9 dígitos numéricos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Email) || Email.Length > 255)
            {
                errorMessage = "O email é obrigatório e não pode exceder 255 caracteres.";
                return false;
            }
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMessage = "Formato de email inválido.";
                return false;
            }

            return true;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                string selectSQL = "SELECT ClienteID, Nome, Email, NIF, Telefone FROM Cliente";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(selectSQL, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Cliente cliente = new Cliente();
                                cliente.ClienteID = Convert.ToInt32(dr["ClienteID"]);
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.NIF = Convert.ToInt32(dr["NIF"]);
                                cliente.Telefone = Convert.ToInt32(dr["Telefone"]);
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            return clientes;
        }


        public void CreateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                using (SqlCommand cmd = new SqlCommand("CreateClient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
                    cmd.Parameters.Add(new SqlParameter("@Email", cliente.Email));
                    cmd.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));
                    cmd.Parameters.Add(new SqlParameter("@NIF", cliente.NIF));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Cliente GetClienteData(int clienteID)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                string selectSQL = "SELECT ClienteID, Nome, Email, NIF, Telefone FROM Cliente WHERE ClienteID = @ClienteID";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(selectSQL, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@ClienteID", clienteID));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cliente = new Cliente();
                            cliente.ClienteID = Convert.ToInt32(dr["ClienteID"]);
                            cliente.Nome = dr["Nome"].ToString();
                            cliente.Email = dr["Email"].ToString();
                            cliente.NIF = Convert.ToInt32(dr["NIF"]);
                            cliente.Telefone = Convert.ToInt32(dr["Telefone"]);
                        }
                    }
                }
            }
            return cliente;
        }

        public void EditCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ClienteID", cliente.ClienteID));
                    cmd.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
                    cmd.Parameters.Add(new SqlParameter("@Email", cliente.Email));
                    cmd.Parameters.Add(new SqlParameter("@NIF", cliente.NIF));
                    cmd.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string DeleteCliente(int clienteID) // Retorna string: vazio para sucesso, mensagem de erro para falha
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ClienteID", clienteID));
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return string.Empty;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            return "Não é possível eliminar o cliente, pois existem alugueres associados a este cliente no sistema.\nPor favor, certifique-se de que não há alugueres ativos ou no histórico antes de eliminar.";
                        }
                        else
                        {
                            return "Ocorreu um erro de base de dados: " + ex.Message;
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Ocorreu um erro inesperado: " + ex.Message;
                    }
                }
            }
        }

        public bool ExisteNif(string nif)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Cliente WHERE NIF = @NIF", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@NIF", nif));
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool ExisteEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Cliente WHERE Email = @Email", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public List<string> GetNomesClientesSemAluguerPendente(string partialNome)
        {
            List<string> nomesClientes = new List<string>();
            string selectSQL = @"SELECT Nome
                         FROM Cliente
                         WHERE Nome LIKE @PartialNome ESCAPE '\'
                           AND ClienteID NOT IN (SELECT DISTINCT ClienteID FROM Aluguer WHERE DataDevolucaoEfetiva IS NULL)
                         ORDER BY Nome;";

            using (SqlConnection con = new SqlConnection(GetConnectionStringFromConfig()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(selectSQL, con))
                {
                    cmd.Parameters.AddWithValue("@PartialNome", partialNome + "%");
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nomesClientes.Add(dr["Nome"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao buscar nomes de clientes: " + ex.Message);
                    }
                }
            }
            return nomesClientes;
        }
    }
}
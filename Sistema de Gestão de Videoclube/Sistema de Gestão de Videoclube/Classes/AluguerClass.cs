using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms; 
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Sistema_de_Gestão_de_Videoclube.Classes
{
    internal class AluguerClass
    {
        public int AluguerID { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public DateTime DataAluguer { get; set; }
        public DateTime DataPrevistaDev { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int ClienteID { get; set; }
        public int FilmeID { get; set; }

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;

        public List<AluguerClass> GetAlugueres()
        {
            List<AluguerClass> aluguerList = new List<AluguerClass>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectSQL = "GetTodosAlugueres";

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(selectSQL, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        AluguerClass aluguer = new AluguerClass();
                        aluguer.AluguerID = Convert.ToInt32(dr["AluguerID"]);
                        aluguer.DataAluguer = Convert.ToDateTime(dr["DataAluguer"]);
                        aluguer.DataPrevistaDev = Convert.ToDateTime(dr["DataPrevistaDev"]);
                        aluguer.Nome = dr["Nome"].ToString();
                        aluguer.Titulo = dr["Titulo"].ToString();
                        if (dr["DataDevolucao"] != DBNull.Value)
                        {
                            aluguer.DataDevolucao = Convert.ToDateTime(dr["DataDevolucao"]);
                        }
                        else
                        {
                            aluguer.DataDevolucao = null;
                        }

                        aluguerList.Add(aluguer);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter alugueres: " + ex.Message);
                }
            }
            return aluguerList;
        }
        public void CreateAluguer(AluguerClass aluguer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("CreateAluguer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", aluguer.Nome);
                    cmd.Parameters.AddWithValue("@Titulo", aluguer.Titulo);
                    cmd.Parameters.AddWithValue("@DataAluguer", aluguer.DataAluguer);
                    cmd.Parameters.AddWithValue("@DataPrevistaDev", aluguer.DataPrevistaDev);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao criar aluguer: " + ex.Message);

                }
            }
        }
        public AluguerClass GetAluguerData(int aluguerID)
        {
            AluguerClass aluguer = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string storedProcedureName = "GetAluguerData";
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(storedProcedureName, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AluguerID", aluguerID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        aluguer = new AluguerClass();
                        aluguer.AluguerID = Convert.ToInt32(dr["AluguerID"]);
                        aluguer.ClienteID = Convert.ToInt32(dr["Cliente_ClienteID"]);
                        aluguer.FilmeID = Convert.ToInt32(dr["Filme_FilmeID"]);
                        aluguer.DataAluguer = Convert.ToDateTime(dr["DataAluguer"]);
                        aluguer.DataPrevistaDev = Convert.ToDateTime(dr["DataPrevistaDev"]);
                        aluguer.Nome = dr["Nome"].ToString();
                        aluguer.Titulo = dr["Titulo"].ToString();
                        if (dr["DataDevolucao"] != DBNull.Value)
                        {
                            aluguer.DataDevolucao = Convert.ToDateTime(dr["DataDevolucao"]);
                        }
                        else
                        {
                            aluguer.DataDevolucao = null;
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter dados do aluguer: " + ex.Message);
                }
            }
            return aluguer;
        }
        public void UpdateAluguer(AluguerClass aluguer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UpdateAluguer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AluguerID", aluguer.AluguerID);
                    cmd.Parameters.AddWithValue("@DataAluguer", aluguer.DataAluguer);
                    cmd.Parameters.AddWithValue("@DataPrevistaDev", aluguer.DataPrevistaDev);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar aluguer: " + ex.Message);
                }
            }
        }
        public List<AluguerClass> GetAlugueresRecentes(int quantidade = 10)
        {
            List<AluguerClass> aluguerList = new List<AluguerClass>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string storedProcedureName = "GetAlugueresRecentes";

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(storedProcedureName, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        AluguerClass aluguer = new AluguerClass();
                        aluguer.AluguerID = Convert.ToInt32(dr["AluguerID"]);
                        aluguer.ClienteID = Convert.ToInt32(dr["Cliente_ClienteID"]);
                        aluguer.FilmeID = Convert.ToInt32(dr["Filme_FilmeID"]);
                        aluguer.DataAluguer = Convert.ToDateTime(dr["DataAluguer"]);
                        aluguer.DataPrevistaDev = Convert.ToDateTime(dr["DataPrevistaDev"]);
                        aluguer.Nome = dr["Nome"].ToString();
                        aluguer.Titulo = dr["Titulo"].ToString();
                        if (dr["DataDevolucao"] != DBNull.Value)
                        {
                            aluguer.DataDevolucao = Convert.ToDateTime(dr["DataDevolucao"]);
                        }
                        else
                        {
                            aluguer.DataDevolucao = null;
                        }

                        aluguerList.Add(aluguer);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter alugueres recentes: " + ex.Message);
                }
            }
            return aluguerList;
        }
        public List<AluguerClass> GetOngoingAlugueres()
        {
            List<AluguerClass> alugueres = new List<AluguerClass>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string storedProcedureName = "GetOngoingAlugueres";

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(storedProcedureName, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        AluguerClass aluguer = new AluguerClass
                        {
                            AluguerID = Convert.ToInt32(dr["AluguerID"]),
                            ClienteID = Convert.ToInt32(dr["Cliente_ClienteID"]),
                            FilmeID = Convert.ToInt32(dr["Filme_FilmeID"]),
                            Nome = dr["Nome"].ToString(),
                            Titulo = dr["Titulo"].ToString(),
                            DataAluguer = Convert.ToDateTime(dr["DataAluguer"]),
                            DataPrevistaDev = Convert.ToDateTime(dr["DataPrevistaDev"])
                        };

                        if (dr["DataDevolucao"] != DBNull.Value)
                        {
                            aluguer.DataDevolucao = Convert.ToDateTime(dr["DataDevolucao"]);
                        }
                        else
                        {
                            aluguer.DataDevolucao = null;
                        }

                        alugueres.Add(aluguer);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter alugueres em andamento: " + ex.Message);
                }
                return alugueres;
            }
        }

        public List<AluguerClass> GetHistoricoByClienteID(int clienteID)
        {
            List<AluguerClass> historico = new List<AluguerClass>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string storedProcedureName = "GetHistoricoByClienteID";
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClienteID", clienteID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AluguerClass aluguer = new AluguerClass
                                {
                                    AluguerID = reader.GetInt32(reader.GetOrdinal("AluguerID")),
                                    ClienteID = reader.GetInt32(reader.GetOrdinal("Cliente_ClienteID")),
                                    FilmeID = reader.GetInt32(reader.GetOrdinal("Filme_FilmeID")),
                                    Nome = reader["Nome"].ToString(),
                                    Titulo = reader["Titulo"].ToString(),
                                    DataAluguer = reader.GetDateTime(reader.GetOrdinal("DataAluguer")),
                                    DataPrevistaDev = reader.GetDateTime(reader.GetOrdinal("DataPrevistaDev")),
                                    DataDevolucao = reader.IsDBNull(reader.GetOrdinal("DataDevolucao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataDevolucao"))
                                };

                                historico.Add(aluguer);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao obter histórico de alugueres: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

            return historico;
        }
        public bool MarkAluguerAsReturned(int aluguerId)
        {
            string storedProcedureName = "MarkAluguerAsReturned";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DataDevolucao", DateTime.Today);
                    cmd.Parameters.AddWithValue("@AluguerID", aluguerId);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int rowsAffected))
                        {
                            return rowsAffected > 0;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao marcar aluguer como devolvido: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool IsFilmeAlugado(int filmeID)
        {
            string storedProcedureName = "IsFilmeAlugado";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FilmeID", filmeID);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count > 0;
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao verificar disponibilidade do filme: " + ex.Message);
                        return true;
                    }
                }
            }
        }
        public DataTable GetTopFilmesAlugados(int quantidade = 5)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FilmeID", typeof(int));
            dt.Columns.Add("Titulo", typeof(string));
            dt.Columns.Add("TotalAlugueres", typeof(int));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                SELECT TOP (@QtdFilmes)
                    f.FilmeID,
                    f.Titulo,
                    COUNT(a.AluguerID) AS TotalAlugueres
                FROM Filme f
                JOIN Aluguer a ON f.FilmeID = a.Filme_FilmeID
                GROUP BY f.FilmeID, f.Titulo
                ORDER BY COUNT(a.AluguerID) DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@QtdFilmes", quantidade);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["FilmeID"] = reader.GetInt32(0);
                        row["Titulo"] = reader.GetString(1);
                        row["TotalAlugueres"] = reader.GetInt32(2);
                        dt.Rows.Add(row);
                    }

                    reader.Close();


                    if (dt.Rows.Count == 0)
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["FilmeID"] = i;
                            row["Titulo"] = $"Filme Teste {i}";
                            row["TotalAlugueres"] = i * 10;
                            dt.Rows.Add(row);
                        }
                        MessageBox.Show("Nenhum dado encontrado - usando dados de teste");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao encontrar top filmes: " + ex.Message);

                    for (int i = 1; i <= 5; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["FilmeID"] = i;
                        row["Titulo"] = $"Filme Erro {i}";
                        row["TotalAlugueres"] = i * 5;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }
        public DataTable GetFilmesNuncaAlugados()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
                try
                {
                    string query = @"
               SELECT
                    F.FilmeID, F.Titulo, F.Genero
                FROM Filme F LEFT JOIN Aluguer A ON F.FilmeID = A.Filme_FilmeID 
                WHERE A.Filme_FilmeID IS NULL ORDER BY F.Titulo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao encontrar filmes nunca alugados: " + ex.Message);
                    dt = null;
                }
            return dt;
        }

        public int GetTotalFilmes()
        {
            int totalFilmes = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "SELECT COUNT(FilmeID) FROM Filme";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            totalFilmes = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Erro ao obter o total de filmes: " + ex.Message, "Erro de Base de Dados", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return totalFilmes;
        }

        public DataTable GetAlugueresPorData(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dt = new DataTable();
            string storedProcedureName = "GetAlugueresPorDataSP";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
                        cmd.Parameters.AddWithValue("@DataFinal", dataFinal);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        con.Open();
                        da.Fill(dt);
                    }

                }
                catch
                {
                    MessageBox.Show("Erro ao obter alugueres por data.");
                    dt = null;
                }
            }
            return dt;
        }

        public DataTable GetAlugueresEmAtraso()
        {
            DataTable dt = new DataTable();
            string viewName = "vw_AlugueresEmAtraso";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = $"SELECT * FROM {viewName}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter alugueres em atraso: " + ex.Message);
                    dt = null;
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public DataTable GetAlugueresEmAtrasoFiltrado(string filtroPesquisa = "")
        {
            DataTable dt = new DataTable();
            string viewName = "vw_AlugueresEmAtraso";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = $"SELECT * FROM {viewName}";

                    
                    if (!string.IsNullOrWhiteSpace(filtroPesquisa))
                    {  
                        query += " WHERE NomeCliente LIKE @filtro OR NIFCliente LIKE @filtro";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (!string.IsNullOrWhiteSpace(filtroPesquisa))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtroPesquisa + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter alugueres em atraso filtrados: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dt = null; 
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return dt;
        }

        public DataTable GetTotalAlugueresPorCliente()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = @"
                        SELECT
                            C.Nome AS NomeCliente,
                            C.NIF AS NIFCliente,
                            COUNT(A.AluguerID) AS TotalAlugueres
                        FROM
                            Cliente C
                        INNER JOIN
                            Aluguer A ON C.ClienteID = A.Cliente_ClienteID
                        GROUP BY
                            C.Nome, C.NIF
                        ORDER BY
                            TotalAlugueres DESC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Erro ao obter alugueres por cliente: " + ex.Message, "Erro de Base de Dados", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }
            }
            return dt;
        }
    }
}
        




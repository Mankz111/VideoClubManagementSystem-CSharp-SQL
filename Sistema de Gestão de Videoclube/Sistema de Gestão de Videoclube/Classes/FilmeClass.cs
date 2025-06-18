using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Net;


namespace Sistema_de_Gestão_de_Videoclube.Classes
{
    internal class FilmeClass
    {
        public int FilmeID { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Realizador { get; set; }
        public int Duracao { get; set; }
        public int AnoLancamento { get; set; }

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;

        public List<FilmeClass> GetFilmes()
        {
            List<FilmeClass> filmeList = new List<FilmeClass>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectSQL = "select FilmeID, Titulo, Genero, Realizador, Duracao, AnoLancamento from GetFilmeData";
                con.Open();
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        FilmeClass filme = new FilmeClass();

                        filme.FilmeID = Convert.ToInt32(dr["FilmeID"]);
                        filme.Titulo = dr["Titulo"].ToString();
                        filme.Genero = dr["Genero"].ToString();
                        filme.Realizador = dr["Realizador"].ToString();
                        filme.Duracao = dr["Duracao"] != DBNull.Value ? Convert.ToInt32(dr["Duracao"]) : 0;
                        filme.AnoLancamento = dr["AnoLancamento"] != DBNull.Value ? Convert.ToInt32(dr["AnoLancamento"]) : 0;
                        filmeList.Add(filme);
                    }
                }
            }
            return filmeList;
        }

        public void CreateFilme(FilmeClass filme)
        {
            if (!filme.IsValid(out string validationError))
            {
                throw new ArgumentException(validationError);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateFilme", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Titulo", filme.Titulo));
                cmd.Parameters.Add(new SqlParameter("@Genero", filme.Genero));
                cmd.Parameters.Add(new SqlParameter("@Realizador", filme.Realizador));
                cmd.Parameters.Add(new SqlParameter("@Duracao", filme.Duracao));
                cmd.Parameters.Add(new SqlParameter("@AnoLancamento", filme.AnoLancamento));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public FilmeClass GetFilmeData(int filmeID)
        {
            FilmeClass filme = new FilmeClass();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectSQL = "select FilmeID, Titulo, Genero, Realizador, Duracao, AnoLancamento from GetFilmeData where FilmeID=" + filmeID;
                con.Open();
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        filme.FilmeID = Convert.ToInt32(dr["FilmeID"]);
                        filme.Titulo = dr["Titulo"].ToString();
                        filme.Genero = dr["Genero"].ToString();
                        filme.Realizador = dr["Realizador"].ToString();
                        filme.Duracao = dr["Duracao"] != DBNull.Value ? Convert.ToInt32(dr["Duracao"]) : 0;
                        filme.AnoLancamento = dr["AnoLancamento"] != DBNull.Value ? Convert.ToInt32(dr["AnoLancamento"]) : 0;
                    }
                }
            }
            return filme;
        }

        public void EditFilme(FilmeClass filme)
        {
            if (!filme.IsValid(out string validationError))
            {
                throw new ArgumentException(validationError);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateFilme", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FilmeID", filme.FilmeID));
                cmd.Parameters.Add(new SqlParameter("@Titulo", filme.Titulo));
                cmd.Parameters.Add(new SqlParameter("@Genero", filme.Genero));
                cmd.Parameters.Add(new SqlParameter("@Realizador", filme.Realizador));
                cmd.Parameters.Add(new SqlParameter("@Duracao", filme.Duracao));
                cmd.Parameters.Add(new SqlParameter("@AnoLancamento", filme.AnoLancamento));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string DeleteFilme(int filmeID) 
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFilme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FilmeID", filmeID));
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
                            return "Não é possível eliminar o filme, pois existem alugueres associados a este filme no sistema.\nPor favor, certifique-se de que não há alugueres antes de eliminar.";
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

        public static bool ExisteTitulo(string titulo)
        {
            string staticConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
            string sql = "SELECT COUNT(*) FROM Filme WHERE Titulo = @Titulo";
            using (SqlConnection con = new SqlConnection(staticConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao verificar a existência do título na base de dados: {ex.Message}", ex);
                    }
                }
            }
        }

        public static bool ExisteTituloOutroFilme(string titulo, int currentFilmeID)
        {
            string staticConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
            string sql = "SELECT COUNT(*) FROM Filme WHERE Titulo = @Titulo AND FilmeID != @CurrentFilmeID";
            using (SqlConnection con = new SqlConnection(staticConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@CurrentFilmeID", currentFilmeID);
                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao verificar a existência do título de outro filme na base de dados: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Titulo))
            {
                errorMessage = "O título é obrigatório.";
                return false;
            }
            if (Titulo.Length > 255) 
            {
                errorMessage = "O título não pode exceder 255 caracteres.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Genero))
            {
                errorMessage = "O género é obrigatório.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Realizador))
            {
                errorMessage = "O realizador é obrigatório.";
                return false;
            }

            
            if (Duracao <= 0 || Duracao > 500) 
            {
                errorMessage = "A duração deve ser um valor positivo e não pode exceder 500 minutos.";
                return false;
            }

            
            int anoAtual = DateTime.Now.Year;
            if (AnoLancamento < 1888 || AnoLancamento > anoAtual) 
            {
                errorMessage = $"O ano de lançamento deve ser entre 1888 e {anoAtual}.";
                return false;
            }

            return true;
        }

    }
}

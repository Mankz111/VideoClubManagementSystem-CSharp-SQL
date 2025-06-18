using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Sistema_de_Gestão_de_Videoclube.Classes;
using System.Configuration;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class NewAluguerForm : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;

        public NewAluguerForm()
        {
            InitializeComponent();
            
        }

        private void NewAluguerForm_Load(object sender, EventArgs e)
        {
            txtDataAluguer.Text = DateTime.Today.ToShortDateString();
            txtDataPrevistaDev.Text = DateTime.Today.AddDays(14).ToShortDateString();
        }
        private void button1OK_Click(object sender, EventArgs e)
        {
            SaveAluguerData();
        }
        private void button2Cancel_Click(object sender, EventArgs e)
        {
            GotoMainForm();
        }
        void SaveAluguerData()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, preencha o nome do cliente e o título do filme.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dataAluguer;
            DateTime dataPrevistaDev;

            if (!DateTime.TryParse(txtDataAluguer.Text, out dataAluguer))
            {
                MessageBox.Show("Formato de data de aluguer inválido.", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(txtDataPrevistaDev.Text, out dataPrevistaDev))
            {
                MessageBox.Show("Formato de data prevista de devolução inválido.", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    int filmeID = -1;
                    SqlCommand getFilmeIdCmd = new SqlCommand("SELECT FilmeID FROM Filme WHERE Titulo = @Titulo", con);
                    getFilmeIdCmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                    object result = getFilmeIdCmd.ExecuteScalar();
                    if (result != null)
                    {
                        filmeID = Convert.ToInt32(result);
                    }
                    
                    SqlCommand checkClienteCmd = new SqlCommand("SELECT COUNT(*) FROM Cliente WHERE Nome = @Nome", con);
                    checkClienteCmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    int clienteExists = (int)checkClienteCmd.ExecuteScalar();

                    if (clienteExists == 0 || filmeID == -1) 
                    {
                        MessageBox.Show("Cliente ou Filme não encontrado na base de dados.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                  


                    AluguerClass aluguerManager = new AluguerClass();

                    if (aluguerManager.IsFilmeAlugado(filmeID))
                    {
                        MessageBox.Show($"O filme '{txtTitulo.Text}' já se encontra alugado e não pode ser alugado novamente neste momento.", "Filme Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }




                    AluguerClass novoAluguer = new AluguerClass();
                    novoAluguer.Nome = txtNome.Text;
                    novoAluguer.Titulo = txtTitulo.Text;
                    novoAluguer.DataAluguer = dataAluguer;
                    novoAluguer.DataPrevistaDev = dataPrevistaDev;

                    novoAluguer.CreateAluguer(novoAluguer);

                    MessageBox.Show("Aluguer criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GotoMainForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao tentar guardar o aluguer: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        void GotoMainForm()
        {
            this.Close();
        }
    }
}

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

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            CarregarAlugueresADecorrer();
        }

        private void SetupDataGridViewColumns()
        {

            if (!dataGridViewAlugueresRecentes.Columns.Contains("ReturnButton"))
            {
                DataGridViewButtonColumn returnButton = new DataGridViewButtonColumn();
                returnButton.HeaderText = "Ação";
                returnButton.Text = "Devolver";
                returnButton.Name = "ReturnButton";
                returnButton.UseColumnTextForButtonValue = true;
                returnButton.DisplayIndex = 5;
                returnButton.FlatStyle = FlatStyle.Standard;
                dataGridViewAlugueresRecentes.Columns.Add(returnButton);
            }

        }



        void CarregarAlugueresADecorrer()
        {
            List<AluguerClass> alugueres = new List<AluguerClass>();
            AluguerClass aluguerDb = new AluguerClass();

            try
            {

                alugueres = aluguerDb.GetOngoingAlugueres();
                dataGridViewAlugueresRecentes.DataSource = null;
                dataGridViewAlugueresRecentes.DataSource = alugueres;

                if (dataGridViewAlugueresRecentes.Columns.Contains("AluguerID"))
                {
                    
                    dataGridViewAlugueresRecentes.Columns["AluguerID"].Visible = false;
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("FilmeID"))
                {
                    dataGridViewAlugueresRecentes.Columns["FilmeID"].Visible = false;
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("Nome"))
                {
                    dataGridViewAlugueresRecentes.Columns["Nome"].HeaderText = "Cliente";
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("Titulo"))
                {
                    dataGridViewAlugueresRecentes.Columns["Titulo"].HeaderText = "Título";
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("DataAluguer"))
                {
                    dataGridViewAlugueresRecentes.Columns["DataAluguer"].HeaderText = "Data de Aluguer";
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("DataPrevistaDev"))
                {
                    dataGridViewAlugueresRecentes.Columns["DataPrevistaDev"].HeaderText = "Data Prevista Devolução";
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("DataDevolucao"))
                {
                    dataGridViewAlugueresRecentes.Columns["DataDevolucao"].Visible = false;
                }
                if (dataGridViewAlugueresRecentes.Columns.Contains("ClienteID"))
                {
                    dataGridViewAlugueresRecentes.Columns["ClienteID"].Visible = false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar alugueres a decorrer: " + ex.Message);
            }
            dataGridViewAlugueresRecentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void dataGridViewAlugueresRecentes_CellContentClick(object sender, DataGridViewCellEventArgs e) // Certifique-se que o nome do evento corresponde ao seu grid
        {

            if (e.ColumnIndex >= 0 && dataGridViewAlugueresRecentes.Columns[e.ColumnIndex].Name == "ReturnButton" && e.RowIndex >= 0)
            {

                if (dataGridViewAlugueresRecentes.Rows[e.RowIndex].Cells["AluguerID"].Value != null)
                {

                    if (int.TryParse(dataGridViewAlugueresRecentes.Rows[e.RowIndex].Cells["AluguerID"].Value.ToString(), out int aluguerId))
                    {

                        DialogResult result = MessageBox.Show(
                            $"Tem a certeza que quer marcar este aluguer (ID: {aluguerId}) como devolvido?",
                            "Confirmar Devolução",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            AluguerClass aluguerDb = new AluguerClass();
                            bool success = aluguerDb.MarkAluguerAsReturned(aluguerId);

                            if (success)
                            {
                                MessageBox.Show("Aluguer marcado como devolvido com sucesso!");
                                CarregarAlugueresADecorrer();
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível marcar o aluguer como devolvido. Verifique os detalhes.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao obter o ID do aluguer para esta linha.");
                    }
                }
                else
                {
                    MessageBox.Show("O ID do aluguer para esta linha é nulo.");
                }
            }

        }



        private void clientesBTN_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            formCliente.Show();
        }

        private void filmesBTN_Click(object sender, EventArgs e)
        {
            FormFilmes formFilmes = new FormFilmes();
            formFilmes.Show();
        }

        private void alugueresBTN_Click(object sender, EventArgs e)
        {
            NewAluguerForm newAluguerForm = new NewAluguerForm();
            newAluguerForm.Show();
            CarregarAlugueresADecorrer();
        }

        private void historicoAlugueresBTN_Click(object sender, EventArgs e)
        {
            FormHistoricoAlugueres formHistorico = new FormHistoricoAlugueres();
            formHistorico.Show();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            RelatoriosForm relatoriosForm = new RelatoriosForm();
            relatoriosForm.Show();
        }
    }
}
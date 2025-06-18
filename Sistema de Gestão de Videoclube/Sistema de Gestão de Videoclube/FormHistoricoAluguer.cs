using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestão_de_Videoclube.Classes;

namespace Sistema_de_Gestão_de_Videoclube
{

    public partial class FormHistoricoAluguer : Form
    {
        private List<AluguerClass> _todosAlugueres; // Para armazenar o histórico completo
        public int ClienteID { get; set; } = -1;
        public string ClienteNome { get; set; } = "Histórico Completo";

        public FormHistoricoAluguer()
        {
            InitializeComponent();
        }

        private void FormHistoricoAluguer_Load(object sender, EventArgs e)
        {
            this.Text = $"Histórico de Alugueres - {this.ClienteNome}";
            SetupDataGridViewColumns();
            CarregarHistorico();
        }

        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "colAluguerID";
            idColumn.HeaderText = "ID Aluguer";
            idColumn.DataPropertyName = "AluguerID";
            idColumn.Visible = false;
            dataGridView1.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nomeColumn = new DataGridViewTextBoxColumn();
            nomeColumn.Name = "colNomeCliente";
            nomeColumn.HeaderText = "Cliente";
            nomeColumn.DataPropertyName = "Nome";
            dataGridView1.Columns.Add(nomeColumn);

            DataGridViewTextBoxColumn tituloColumn = new DataGridViewTextBoxColumn();
            tituloColumn.Name = "colTituloFilme";
            tituloColumn.HeaderText = "Título do Filme";
            tituloColumn.DataPropertyName = "Titulo";
            dataGridView1.Columns.Add(tituloColumn);

            DataGridViewTextBoxColumn dataAluguerColumn = new DataGridViewTextBoxColumn();
            dataAluguerColumn.Name = "colDataAluguer";
            dataAluguerColumn.HeaderText = "Data de Aluguer";
            dataAluguerColumn.DataPropertyName = "DataAluguer";
            dataAluguerColumn.DefaultCellStyle.Format = "d";
            dataGridView1.Columns.Add(dataAluguerColumn);

            DataGridViewTextBoxColumn dataPrevistaColumn = new DataGridViewTextBoxColumn();
            dataPrevistaColumn.Name = "colDataPrevistaDev";
            dataPrevistaColumn.HeaderText = "Data Prevista Devolução";
            dataPrevistaColumn.DataPropertyName = "DataPrevistaDev";
            dataPrevistaColumn.DefaultCellStyle.Format = "d";
            dataGridView1.Columns.Add(dataPrevistaColumn);

            DataGridViewTextBoxColumn dataDevolucaoColumn = new DataGridViewTextBoxColumn();
            dataDevolucaoColumn.Name = "colDataDevolucao";
            dataDevolucaoColumn.HeaderText = "Data Devolução Real";
            dataDevolucaoColumn.DataPropertyName = "DataDevolucao";
            dataDevolucaoColumn.DefaultCellStyle.Format = "d";
            dataDevolucaoColumn.Visible = true;
            dataGridView1.Columns.Add(dataDevolucaoColumn);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarHistorico()
        {
            AluguerClass aluguerDb = new AluguerClass();
            try
            {
                if (this.ClienteID > -1)
                {
                    _todosAlugueres = aluguerDb.GetHistoricoByClienteID(this.ClienteID);
                }
                else
                {
                    _todosAlugueres = aluguerDb.GetAlugueres();
                }

                FiltrarAlugueres(textBoxPesquisa.Text); // Filtra logo após carregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;
            }
        }

        private void FiltrarAlugueres(string termoPesquisa)
        {
            if (_todosAlugueres == null) return;

            List<AluguerClass> resultadosFiltrados;

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                resultadosFiltrados = _todosAlugueres;
            }
            else
            {
                string termoLower = termoPesquisa.ToLower();
                resultadosFiltrados = _todosAlugueres.Where(a =>
                    a.Nome.ToLower().Contains(termoLower) ||
                    a.Titulo.ToLower().Contains(termoLower)
                ).ToList();
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultadosFiltrados;

            if (dataGridView1.Columns.Contains("colNomeCliente"))
            {
                dataGridView1.Columns["colNomeCliente"].Visible = (this.ClienteID == -1);
            }
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarAlugueres(textBoxPesquisa.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
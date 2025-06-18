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
    public partial class FormHistoricoAlugueres : Form
    {
        private List<AluguerClass> _todosAlugueres; // Mantenha esta declaração

        public FormHistoricoAlugueres()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
        }

        private void FormHistoricoAlugueres_Load(object sender, EventArgs e)
        {
            // O CarregarTodosAlugueres agora vai carregar _todosAlugueres e chamar FiltrarAlugueres
            CarregarTodosAlugueres();
        }

        private void SetupDataGridViewColumns()
        {
            dataGridViewHistorico.Columns.Clear();
            dataGridViewHistorico.AutoGenerateColumns = false; // Adicionar esta linha para evitar que o DataGridView crie colunas automaticamente

            // Coluna AluguerID
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "AluguerID"; // Usar o mesmo nome da propriedade na classe AluguerClass
            idColumn.HeaderText = "ID Aluguer";
            idColumn.DataPropertyName = "AluguerID";
            idColumn.Visible = false;
            dataGridViewHistorico.Columns.Add(idColumn);

            // Coluna Nome do Cliente
            DataGridViewTextBoxColumn nomeColumn = new DataGridViewTextBoxColumn();
            nomeColumn.Name = "Nome"; // Usar o mesmo nome da propriedade na classe AluguerClass
            nomeColumn.HeaderText = "Cliente";
            nomeColumn.DataPropertyName = "Nome";
            dataGridViewHistorico.Columns.Add(nomeColumn);

            // Coluna Título do Filme
            DataGridViewTextBoxColumn tituloColumn = new DataGridViewTextBoxColumn();
            tituloColumn.Name = "Titulo"; // Usar o mesmo nome da propriedade na classe AluguerClass
            tituloColumn.HeaderText = "Título";
            tituloColumn.DataPropertyName = "Titulo";
            dataGridViewHistorico.Columns.Add(tituloColumn);

            // Coluna Data de Aluguer
            DataGridViewTextBoxColumn dataAluguerColumn = new DataGridViewTextBoxColumn();
            dataAluguerColumn.Name = "DataAluguer"; // Usar o mesmo nome da propriedade na classe AluguerClass
            dataAluguerColumn.HeaderText = "Data de Aluguer";
            dataAluguerColumn.DataPropertyName = "DataAluguer";
            dataAluguerColumn.DefaultCellStyle.Format = "d"; // Formato de data curta
            dataGridViewHistorico.Columns.Add(dataAluguerColumn);

            DataGridViewTextBoxColumn dataPrevistaColumn = new DataGridViewTextBoxColumn();
            dataPrevistaColumn.Name = "DataPrevistaDev"; // Usar o mesmo nome da propriedade na classe AluguerClass
            dataPrevistaColumn.HeaderText = "Data Prevista Devolução";
            dataPrevistaColumn.DataPropertyName = "DataPrevistaDev";
            dataPrevistaColumn.DefaultCellStyle.Format = "d"; // Formato de data curta
            dataGridViewHistorico.Columns.Add(dataPrevistaColumn);

            DataGridViewTextBoxColumn dataDevolucaoColumn = new DataGridViewTextBoxColumn();
            dataDevolucaoColumn.Name = "DataDevolucao"; // Usar o mesmo nome da propriedade na classe AluguerClass
            dataDevolucaoColumn.HeaderText = "Data Devolução Real";
            dataDevolucaoColumn.DataPropertyName = "DataDevolucao";
            dataDevolucaoColumn.DefaultCellStyle.Format = "d"; // Formato de data curta
            dataDevolucaoColumn.Visible = true;
            dataGridViewHistorico.Columns.Add(dataDevolucaoColumn);

            dataGridViewHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarTodosAlugueres()
        {
            AluguerClass aluguerDb = new AluguerClass();
            try
            {
                _todosAlugueres = aluguerDb.GetAlugueres(); // Carrega para a variável de classe _todosAlugueres
                FiltrarAlugueres(_todosAlugueres, textBox1.Text); // Chama o filtro com a lista carregada e o texto atual
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar histórico de alugueres: " + ex.Message);
                dataGridViewHistorico.DataSource = null;
            }
        }

        // Método FiltrarAlugueres, que recebe a lista completa e o termo de pesquisa
        private void FiltrarAlugueres(List<AluguerClass> alugueresParaFiltrar, string termoPesquisa)
        {
            if (alugueresParaFiltrar == null) return;

            List<AluguerClass> resultadosFiltrados;

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                resultadosFiltrados = alugueresParaFiltrar;
            }
            else
            {
                string termoLower = termoPesquisa.ToLower();
                resultadosFiltrados = alugueresParaFiltrar.Where(a =>
                    (a.Nome != null && a.Nome.ToLower().Contains(termoLower)) || // Adicionado null check
                    (a.Titulo != null && a.Titulo.ToLower().Contains(termoLower)) // Adicionado null check
                ).ToList();
            }

            dataGridViewHistorico.DataSource = null;
            dataGridViewHistorico.DataSource = resultadosFiltrados;

            // Para garantir que as colunas ClienteID e FilmeID são ocultadas
            // As imagens mostram que essas colunas estão visíveis após o filtro,
            // então esta parte do código precisa ser executada após cada atualização do DataSource.
            if (dataGridViewHistorico.Columns.Contains("ClienteID"))
            {
                dataGridViewHistorico.Columns["ClienteID"].Visible = false;
            }
            if (dataGridViewHistorico.Columns.Contains("FilmeID"))
            {
                dataGridViewHistorico.Columns["FilmeID"].Visible = false;
            }
        }

        // O evento TextChanged para textBox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Quando o texto da caixa de pesquisa muda, chama o método de filtro
            // usando a lista completa (_todosAlugueres) e o texto atual da caixa de pesquisa.
            FiltrarAlugueres(_todosAlugueres, textBox1.Text);
        }

        private void dataGridViewHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seu código para o clique na célula (se houver)
        }
    }
}
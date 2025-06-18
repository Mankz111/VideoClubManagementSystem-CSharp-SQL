using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using Sistema_de_Gestão_de_Videoclube.Classes;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class RelatoriosForm : Form
    {
        private Button _currentActiveButton = null;
        private Color _defaultButtonBackColor;



        public RelatoriosForm()
        {
            InitializeComponent();
            CarregarGraficoTopFilmes();
            CarregarTopFilmesDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void CarregarGraficoTopFilmes()
        {
            try
            {
                AluguerClass aluguerClass = new AluguerClass();
                DataTable topFilmes = aluguerClass.GetTopFilmesAlugados(5);
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("Top 5 Filmes Mais Alugados");
                Series serie = new Series("Alugueres");
                serie.ChartType = SeriesChartType.Column;
                chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

                int pointIndex = 0;

                foreach (DataRow row in topFilmes.Rows)
                {
                    string titulo = row["Titulo"].ToString();
                    int total = Convert.ToInt32(row["TotalAlugueres"]);

                    serie.Points.AddXY(pointIndex, total);
                    CustomLabel label = new CustomLabel();
                    label.FromPosition = pointIndex - 0.5;
                    label.ToPosition = pointIndex + 0.5;
                    label.Text = titulo;
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
                    pointIndex++;
                }

                chart1.Series.Add(serie);


                chart1.ChartAreas[0].AxisX.Title = "Filme";
                chart1.ChartAreas[0].AxisY.Title = "Número de Alugueres";
                chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;



                serie.IsValueShownAsLabel = true;

                Color[] cores = new Color[]
                {
                    Color.FromArgb(65, 140, 240),
                    Color.FromArgb(252, 180, 65),
                    Color.FromArgb(224, 64, 10),
                    Color.FromArgb(5, 100, 146),
                    Color.FromArgb(191, 191, 191)
                };

                for (int i = 0; i < serie.Points.Count; i++)
                {
                    serie.Points[i].Color = cores[i % cores.Length];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar gráfico: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarTopFilmesDataGridView()
        {
            try
            {
                AluguerClass aluguerClass = new AluguerClass();
                DataTable topFilmes = aluguerClass.GetTopFilmesAlugados(5);
                dataGridView1.DataSource = topFilmes;
                dataGridView1.Font = new Font("Arial", 10);
                dataGridView1.AllowUserToAddRows = false;

                if (dataGridView1.Columns.Contains("FilmeID"))
                {
                    dataGridView1.Columns["FilmeID"].Visible = false;
                }

                if (dataGridView1.Columns.Contains("Titulo"))
                {
                    dataGridView1.Columns["Titulo"].HeaderCell.Style.BackColor = Color.Orange;
                    dataGridView1.Columns["Titulo"].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
                    dataGridView1.Columns["Titulo"].HeaderText = "Título do Filme";
                    dataGridView1.Columns["Titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }

                if (dataGridView1.Columns.Contains("TotalAlugueres"))
                {
                    dataGridView1.Columns["TotalAlugueres"].HeaderCell.Style.BackColor = Color.Orange;
                    dataGridView1.Columns["TotalAlugueres"].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
                    dataGridView1.Columns["TotalAlugueres"].HeaderText = "Total de Alugueres";
                    dataGridView1.Columns["TotalAlugueres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetButtonColors()
        {
            if (btnTopFilmes != null)
            {
                btnTopFilmes.BackColor = _defaultButtonBackColor;
            }
            if (btnFilmesNuncaAlugados != null)
            {
                btnFilmesNuncaAlugados.BackColor = _defaultButtonBackColor;
            }
            if (btnFilmesPorData != null)
            {
                btnFilmesPorData.BackColor = _defaultButtonBackColor;
            }
            if (btnAtraso != null)
            {
                btnAtraso.BackColor = _defaultButtonBackColor;
            }
            if (btnAlugueresPorCliente != null)
            {
                btnAlugueresPorCliente.BackColor = _defaultButtonBackColor;
            }
        }

        private void btnFilmesNuncaAlugados_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnFilmesNuncaAlugados.BackColor = Color.Orange;
            HideAllReportPanels();
            panelFilmesNuncaAlugados.Visible = true;
            _currentActiveButton = btnFilmesNuncaAlugados;
            CarregarFilmesNuncaAlugados();

        }

        private void btnTopFilmes_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnTopFilmes.BackColor = Color.Orange;
            HideAllReportPanels();
            panelTopFilmes.Visible = true;
            _currentActiveButton = btnTopFilmes;
            CarregarGraficoTopFilmes();
            CarregarTopFilmesDataGridView();
        }



        private void CarregarFilmesNuncaAlugados()
        {
            AluguerClass aluguerObj = new AluguerClass();
            DataTable filmesNuncaAlugadosDt = aluguerObj.GetFilmesNuncaAlugados();

            if (lblTotal != null)
            {
                lblTotal.Text = "Total Nunca Alugados: N/A";
            }
            if (lblpercentagem != null)
            {
                lblpercentagem.Text = "Percentagem: N/A";
            }

            if (dataGridView2 != null)
            {
                if (filmesNuncaAlugadosDt != null)
                {
                    if (filmesNuncaAlugadosDt.Rows.Count == 0)
                    {
                        dataGridView2.DataSource = null;

                        if (lblTotal != null)
                        {
                            lblTotal.Text = "Total Nunca Alugados: 0";
                        }


                        int totalGeralFilmes = aluguerObj.GetTotalFilmes();
                        double percentagem = 0;

                        if (lblpercentagem != null)
                        {
                            lblpercentagem.Text = $"{percentagem:F2}%";
                        }
                    }
                    else
                    {
                        dataGridView2.DataSource = filmesNuncaAlugadosDt;
                        dataGridView2.Font = new Font("Arial", 10);
                        dataGridView2.AllowUserToAddRows = false;

                        
                        if (dataGridView2.Columns.Contains("Titulo"))
                        {
                            dataGridView2.Columns["Titulo"].HeaderCell.Style.BackColor = Color.Orange;
                            dataGridView2.Columns["Titulo"].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
                            dataGridView2.Columns["Titulo"].HeaderText = "Título do Filme";
                            dataGridView2.Columns["Titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dataGridView2.Columns.Contains("Genero"))
                        {
                            dataGridView2.Columns["Genero"].HeaderCell.Style.BackColor = Color.Orange;
                            dataGridView2.Columns["Genero"].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
                            dataGridView2.Columns["Genero"].HeaderText = "Género";
                            dataGridView2.Columns["Genero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        if(dataGridView2.Columns.Contains("FilmeID"))
                        {
                            dataGridView2.Columns["FilmeID"].Visible = false;

                        }


                        int totalNuncaAlugados = filmesNuncaAlugadosDt.Rows.Count;
                        if (lblTotal != null)
                        {
                            lblTotal.Text = $"{totalNuncaAlugados}";
                        }

                        int totalGeralFilmes = aluguerObj.GetTotalFilmes();
              
                        double percentagem = 0;
                        if (totalGeralFilmes > 0) 
                        {
                            percentagem = (double)totalNuncaAlugados / totalGeralFilmes * 100;
                        }                        
                        if (lblpercentagem != null)
                        {
                            lblpercentagem.Text = $"{percentagem:F2}%";
                        }
                        
                    }
                }
                
            }
            else
            {
                dataGridView2.DataSource = null;
               
            }
        }

        private void HideAllReportPanels()
        {
            if (panelTopFilmes != null)
            {
                panelTopFilmes.Visible = false;
            }
            if (panelFilmesNuncaAlugados != null)
            {
                panelFilmesNuncaAlugados.Visible = false;
            }
            if (panelFilmesPorData != null)
            {
                panelFilmesPorData.Visible = false;
            }
            if (panelClientesAtraso != null)
            {
                panelClientesAtraso.Visible = false;
            }
            if (panelAlugueresPorCliente != null)
            {
                panelAlugueresPorCliente.Visible = false;
            }

        }

        private void btnFilmesPorData_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            if (btnFilmesPorData != null)
            {
                btnFilmesPorData.BackColor = Color.Orange;
            }
            HideAllReportPanels();
            if (panelFilmesPorData != null)
            {
                panelFilmesPorData.Visible = true;
            }
            _currentActiveButton = btnFilmesPorData;

        }

        private void CarregarFilmesAlugadosPorData()
        {
            DataGridView targetDataGridView = dataGridView3;

            if (targetDataGridView == null)
            {
                MessageBox.Show("Erro interno: DataGridView para relatórios por data não encontrado.", "Erro de Controle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDataInicial == null || dtpDataFinal == null)
            {
                MessageBox.Show("Erro interno: Controles de data não encontrados.", "Erro de Controle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dataInicial = dtpDataInicial.Value.Date;
            DateTime dataFinal = dtpDataFinal.Value.Date.AddDays(1).AddSeconds(-1);

            if (dataInicial > dataFinal)
            {
                MessageBox.Show("A Data Inicial não pode ser posterior à Data Final.", "Datas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                targetDataGridView.DataSource = null;
                return;
            }
            try
            {
                AluguerClass aluguerObj = new AluguerClass();
                DataTable alugueres = aluguerObj.GetAlugueresPorData(dataInicial, dataFinal);

                if (alugueres != null)
                {
                    if (alugueres.Rows.Count == 0)
                    {
                        targetDataGridView.DataSource = null;
                        MessageBox.Show("Nenhum aluguer encontrado no período selecionado.", "Sem Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        targetDataGridView.DataSource = alugueres;
                        targetDataGridView.Font = new Font("Arial", 10);
                        targetDataGridView.AllowUserToAddRows = false;
                        if (targetDataGridView.Columns.Contains("Cliente"))
                        {
                            targetDataGridView.Columns["Cliente"].HeaderText = "Cliente";
                            targetDataGridView.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        if (targetDataGridView.Columns.Contains("Filme"))
                        {
                            targetDataGridView.Columns["Filme"].HeaderText = "Filme";
                            targetDataGridView.Columns["Filme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        if (targetDataGridView.Columns.Contains("DataAluguer"))
                        {
                            targetDataGridView.Columns["DataAluguer"].HeaderText = "Data de Aluguer";
                            targetDataGridView.Columns["DataAluguer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            targetDataGridView.Columns["DataAluguer"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        if (targetDataGridView.Columns.Contains("DataPrevistaDev"))
                        {
                            targetDataGridView.Columns["DataPrevistaDev"].HeaderText = "Previsto Devolução";
                            targetDataGridView.Columns["DataPrevistaDev"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            targetDataGridView.Columns["DataPrevistaDev"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        if (targetDataGridView.Columns.Contains("DataDevolucao"))
                        {
                            targetDataGridView.Columns["DataDevolucao"].HeaderText = "Data Devolução";
                            targetDataGridView.Columns["DataDevolucao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            targetDataGridView.Columns["DataDevolucao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                    }
                }
                else
                {
                    targetDataGridView.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar relatório por data: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                targetDataGridView.DataSource = null;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarFilmesAlugadosPorData();
        }

        private void CarregarClienteAtraso(string filtro = "")
        {
            DataGridView targetDataGridView = dataGridView4;
            if (targetDataGridView == null)
            {
                MessageBox.Show("Erro interno: Controlo DataGridView para relatórios de atraso ('dataGridView4') não encontrado no formulário.", "Erro de Configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable alugueresEmAtraso = null;

            try
            {
                AluguerClass aluguerObj = new AluguerClass();
                alugueresEmAtraso = aluguerObj.GetAlugueresEmAtrasoFiltrado(filtro);

                targetDataGridView.AutoGenerateColumns = true;

                if (alugueresEmAtraso == null)
                {
                    targetDataGridView.DataSource = null;
                    MessageBox.Show("Não foi possível obter dados de alugueres em atraso devido a um erro na base de dados.", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (alugueresEmAtraso.Rows.Count == 0)
                {
                    targetDataGridView.DataSource = null;
                    string mensagem = "Não há alugueres em atraso reais no momento na base de dados que correspondam à sua pesquisa.";
                    mensagem += Environment.NewLine;
                    mensagem += "Gostaria de visualizar dados de teste para demonstração?";

                    DialogResult result = MessageBox.Show(
                        mensagem,
                        "Dados de Teste para Demonstração",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        DataTable testDataTable = new DataTable();
                        testDataTable.Columns.Add("NomeCliente", typeof(string));
                        testDataTable.Columns.Add("NIFCliente", typeof(string));
                        testDataTable.Columns.Add("TituloFilme", typeof(string));
                        testDataTable.Columns.Add("DataAluguer", typeof(DateTime));
                        testDataTable.Columns.Add("DataPrevistaDev", typeof(DateTime));
                        testDataTable.Columns.Add("DiasEmAtraso", typeof(int));
                        testDataTable.Columns.Add("EmailCliente", typeof(string));
                        testDataTable.Columns.Add("TelefoneCliente", typeof(string));

                        DateTime hoje = DateTime.Today;
                        bool filtroVazio = string.IsNullOrWhiteSpace(filtro);

                        if (filtroVazio || "João Silva Teste".Contains(filtro, StringComparison.OrdinalIgnoreCase) || "123456780".Contains(filtro))
                        {
                            testDataTable.Rows.Add(
                                "João Silva Teste",
                                "123456780",
                                "Filme A (Teste)",
                                hoje.AddDays(-30),
                                hoje.AddDays(-15),
                                (hoje - hoje.AddDays(-15)).Days,
                                "joao.silva.teste@email.com",
                                "911111111"
                            );
                        }
                        if (filtroVazio || "Maria Santos Teste".Contains(filtro, StringComparison.OrdinalIgnoreCase) || "987654320".Contains(filtro))
                        {
                            testDataTable.Rows.Add(
                                "Maria Santos Teste",
                                "987654320",
                                "Filme B (Teste)",
                                hoje.AddDays(-45),
                                hoje.AddDays(-20),
                                (hoje - hoje.AddDays(-20)).Days,
                                "maria.santos.teste@email.com",
                                "922222222"
                            );
                        }
                        if (filtroVazio || "Pedro Costa Teste".Contains(filtro, StringComparison.OrdinalIgnoreCase) || "112233440".Contains(filtro))
                        {
                            testDataTable.Rows.Add(
                                "Pedro Costa Teste",
                                "112233440",
                                "Filme C (Teste)",
                                hoje.AddDays(-60),
                                hoje.AddDays(-25),
                                (hoje - hoje.AddDays(-25)).Days,
                                "pedro.costa.teste@email.com",
                                "933333333"
                            );
                        }

                        targetDataGridView.DataSource = testDataTable;
                        MessageBox.Show("Dados de teste carregados (filtrados se aplicável).", "Teste Carregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum aluguer em atraso para mostrar que corresponda à pesquisa.", "Relatório Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    targetDataGridView.DataSource = alugueresEmAtraso;
                }

                targetDataGridView.Font = new Font("Arial", 10);
                targetDataGridView.AllowUserToAddRows = false;
                targetDataGridView.ReadOnly = true;

                if (targetDataGridView.Columns.Contains("NomeCliente"))
                {
                    targetDataGridView.Columns["NomeCliente"].HeaderText = "Nome do Cliente";
                    targetDataGridView.Columns["NomeCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (targetDataGridView.Columns.Contains("NIFCliente"))
                {
                    targetDataGridView.Columns["NIFCliente"].Visible = true;
                }

                if (targetDataGridView.Columns.Contains("TituloFilme"))
                {
                    targetDataGridView.Columns["TituloFilme"].HeaderText = "Filme Alugado";
                    targetDataGridView.Columns["TituloFilme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (targetDataGridView.Columns.Contains("DataAluguer"))
                {
                    targetDataGridView.Columns["DataAluguer"].HeaderText = "Data de Aluguer";
                    targetDataGridView.Columns["DataAluguer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    targetDataGridView.Columns["DataAluguer"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (targetDataGridView.Columns.Contains("DataPrevistaDev"))
                {
                    targetDataGridView.Columns["DataPrevistaDev"].HeaderText = "Data Prevista Devolução";
                    targetDataGridView.Columns["DataPrevistaDev"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    targetDataGridView.Columns["DataPrevistaDev"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    targetDataGridView.Columns["DataPrevistaDev"].DefaultCellStyle.ForeColor = Color.Red;
                }

                if (targetDataGridView.Columns.Contains("DiasEmAtraso"))
                {
                    targetDataGridView.Columns["DiasEmAtraso"].HeaderText = "Dias em Atraso";
                    targetDataGridView.Columns["DiasEmAtraso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    targetDataGridView.Columns["DiasEmAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (targetDataGridView.Columns.Contains("EmailCliente"))
                {
                    targetDataGridView.Columns["EmailCliente"].Visible = false;
                }

                if (targetDataGridView.Columns.Contains("TelefoneCliente"))
                {
                    targetDataGridView.Columns["TelefoneCliente"].Visible = false;
                }

                if (!targetDataGridView.Columns.Contains("btnContactarColumn"))
                {
                    DataGridViewButtonColumn btnContactarColumn = new DataGridViewButtonColumn();
                    btnContactarColumn.Name = "btnContactarColumn";
                    btnContactarColumn.HeaderText = "Contactar";
                    btnContactarColumn.Text = "Contactar";
                    btnContactarColumn.UseColumnTextForButtonValue = true;
                    btnContactarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    targetDataGridView.Columns.Add(btnContactarColumn);
                }

                targetDataGridView.Visible = true;
            }
            catch (Exception ex)
            {
                targetDataGridView.DataSource = null;
                MessageBox.Show("Erro inesperado ao carregar relatório de alugueres em atraso: " + ex.Message, "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtraso_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            if (btnAtraso != null)
            {
                btnAtraso.BackColor = Color.Orange;
            }
            HideAllReportPanels();
            if (panelClientesAtraso != null)
            {
                panelClientesAtraso.Visible = true;
            }
            _currentActiveButton = btnAtraso;
            CarregarClienteAtraso();
            if (textBox1 != null)
            {
                textBox1.Text = "";
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView4.Columns.Contains("btnContactarColumn") && e.ColumnIndex == dataGridView4.Columns["btnContactarColumn"].Index)
            {
                if (e.RowIndex < dataGridView4.Rows.Count && !dataGridView4.Rows[e.RowIndex].IsNewRow)
                {
                    DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                    string nomeCliente = null;
                    if (dataGridView4.Columns.Contains("NomeCliente"))
                    {
                        object value = row.Cells["NomeCliente"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            nomeCliente = value.ToString();
                        }
                    }

                    string nifCliente = null;
                    if (dataGridView4.Columns.Contains("NIFCliente"))
                    {
                        object value = row.Cells["NIFCliente"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            nifCliente = value.ToString();
                        }
                    }

                    string tituloFilme = null;
                    if (dataGridView4.Columns.Contains("TituloFilme"))
                    {
                        object value = row.Cells["TituloFilme"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            tituloFilme = value.ToString();
                        }
                    }

                    string emailCliente = null;
                    if (dataGridView4.Columns.Contains("EmailCliente"))
                    {
                        object value = row.Cells["EmailCliente"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            emailCliente = value.ToString();
                        }
                    }

                    string telefoneCliente = null;
                    if (dataGridView4.Columns.Contains("TelefoneCliente"))
                    {
                        object value = row.Cells["TelefoneCliente"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            telefoneCliente = value.ToString();
                        }
                    }

                    int diasEmAtraso = 0;
                    if (dataGridView4.Columns.Contains("DiasEmAtraso"))
                    {
                        object value = row.Cells["DiasEmAtraso"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            int.TryParse(value.ToString(), out diasEmAtraso);
                        }
                    }
                    DateTime dataAluguer = DateTime.MinValue;
                    if (dataGridView4.Columns.Contains("DataAluguer"))
                    {
                        object value = row.Cells["DataAluguer"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            DateTime.TryParse(value.ToString(), out dataAluguer);
                        }
                    }

                    DateTime dataPrevistaDev = DateTime.MinValue;
                    if (dataGridView4.Columns.Contains("DataPrevistaDev"))
                    {
                        object value = row.Cells["DataPrevistaDev"].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            DateTime.TryParse(value.ToString(), out dataPrevistaDev);
                        }
                    }

                    FormEnviarContacto formContacto = new FormEnviarContacto();
                    formContacto.NomeCliente = nomeCliente;
                    formContacto.NIFCliente = nifCliente;
                    formContacto.TituloFilme = tituloFilme;
                    formContacto.DiasEmAtraso = diasEmAtraso;
                    formContacto.EmailCliente = emailCliente;
                    formContacto.TelefoneCliente = telefoneCliente;
                    formContacto.DataAluguer = dataAluguer;
                    formContacto.DataPrevistaDev = dataPrevistaDev;
                    formContacto.ShowDialog();
                }
            }
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView4.Rows.Count)
            {
                if (dataGridView4.Columns.Contains("DiasEmAtraso"))
                {
                    object diasAtrasoValue = dataGridView4.Rows[e.RowIndex].Cells["DiasEmAtraso"].Value;

                    if (diasAtrasoValue != null && int.TryParse(diasAtrasoValue.ToString(), out int diasEmAtraso))
                    {
                        if (diasEmAtraso >= 1 && diasEmAtraso <= 5)
                        {
                            dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 224);
                        }
                        else if (diasEmAtraso >= 6 && diasEmAtraso <= 15)
                        {
                            dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                        }
                        else if (diasEmAtraso >= 16 && diasEmAtraso <= 30)
                        {
                            dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                        }
                        else if (diasEmAtraso > 30)
                        {
                            dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView4.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView4.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string termoPesquisa = textBox1.Text.Trim();
            CarregarClienteAtraso(termoPesquisa);
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void CarregarAlugueresPorCliente()
        {
            DataGridView targetDataGridView = dataGridView5;

            if (targetDataGridView == null)
            {
                MessageBox.Show("Erro interno: DataGridView para relatórios por cliente não encontrado.", "Erro de Controle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                AluguerClass aluguerObj = new AluguerClass();
                DataTable alugueres = aluguerObj.GetTotalAlugueresPorCliente();
                if (alugueres != null)
                {
                    if (alugueres.Rows.Count == 0)
                    {
                        targetDataGridView.DataSource = null;
                        MessageBox.Show("Nenhum aluguer encontrado para o cliente selecionado.", "Sem Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        targetDataGridView.DataSource = alugueres;
                        targetDataGridView.Font = new Font("Arial", 10);
                        targetDataGridView.AllowUserToAddRows = false;
                        targetDataGridView.ReadOnly = true;

                        if (targetDataGridView.Columns.Contains("NomeCliente")) 
                        {
                            targetDataGridView.Columns["NomeCliente"].HeaderText = "Nome do Cliente";
                            targetDataGridView.Columns["NomeCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        if (targetDataGridView.Columns.Contains("NIFCliente"))
                        {
                            targetDataGridView.Columns["NIFCliente"].HeaderText = "NIF do Cliente";
                            targetDataGridView.Columns["NIFCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        if (targetDataGridView.Columns.Contains("TotalAlugueres"))
                        {
                            targetDataGridView.Columns["TotalAlugueres"].HeaderText = "Total de Alugueres";
                            targetDataGridView.Columns["TotalAlugueres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            targetDataGridView.Columns["TotalAlugueres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        foreach (DataGridViewColumn column in targetDataGridView.Columns)
                        {
                            column.HeaderCell.Style.BackColor = Color.Orange;
                            column.HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
                        }
                    }
                }
                else
                {
                    targetDataGridView.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar alugueres por cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                targetDataGridView.DataSource = null;

                throw;
            }
        }

        private void btnAlugueresPorCliente_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            if (btnAlugueresPorCliente != null)
            {
                btnAlugueresPorCliente.BackColor = Color.Orange;
            }
            HideAllReportPanels();
            if (panelAlugueresPorCliente != null)
            {
                panelAlugueresPorCliente.Visible = true;
            }
            _currentActiveButton = btnAlugueresPorCliente;
            CarregarAlugueresPorCliente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AplicarFiltroClientesAlugueres();

        }

        private void AplicarFiltroClientesAlugueres()
        {
            string termoPesquisa = textBox2.Text.Trim();
            if (dataGridView5.DataSource is DataTable dt)
            {
                
                if (string.IsNullOrEmpty(termoPesquisa))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    
                    string filter = $"NomeCliente LIKE '%{termoPesquisa}%' OR CONVERT(NIFCliente, 'System.String') LIKE '%{termoPesquisa}%'";

                    
                    dt.DefaultView.RowFilter = filter;
                }
            }
        }
    }
}

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
    public partial class FormFilmes : Form
    {
        public FormFilmes()
        {
            InitializeComponent();
            FillGridView();

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void FillGridView()
        {
            List<FilmeClass> filmeList = new List<FilmeClass>();
            FilmeClass filme = new FilmeClass();
            filmeList = filme.GetFilmes();

            dataGridViewFilmes.DataSource = filmeList;

            if (dataGridViewFilmes.Columns.Count > 0)
            {
                try
                {
                    if (dataGridViewFilmes.Columns.Contains("FilmeID"))
                        dataGridViewFilmes.Columns["FilmeID"].HeaderText = "ID Filme";

                    if (dataGridViewFilmes.Columns.Contains("Titulo"))
                        dataGridViewFilmes.Columns["Titulo"].HeaderText = "Título";

                    if (dataGridViewFilmes.Columns.Contains("Genero"))
                        dataGridViewFilmes.Columns["Genero"].HeaderText = "Género";

                    if (dataGridViewFilmes.Columns.Contains("Realizador"))
                        dataGridViewFilmes.Columns["Realizador"].HeaderText = "Realizador";

                    if (dataGridViewFilmes.Columns.Contains("Duracao"))
                        dataGridViewFilmes.Columns["Duracao"].HeaderText = "Duração";

                    if (dataGridViewFilmes.Columns.Contains("AnoLancamento"))
                        dataGridViewFilmes.Columns["AnoLancamento"].HeaderText = "Ano de Lançamento";
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine($"Erro ao definir cabeçalhos das colunas: {ex.Message}");

                }
            }
            dataGridViewFilmes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addfilmeBTN_Click(object sender, EventArgs e)
        {
            NewFilmeForm formNewFilme = new NewFilmeForm();
            formNewFilme.ShowDialog();
            FillGridView();
        }

        private void FormFilme_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        void EditFilmes()
        {
            int filmeID;
            filmeID = (int)dataGridViewFilmes.CurrentRow.Cells[0].Value;
            EditFilmeForm formEditFilme = new EditFilmeForm(filmeID);
            formEditFilme.ShowDialog();
        }

        private void editfilmeBTN_Click_1(object sender, EventArgs e)
        {
            EditFilmes();
            FillGridView();
        }

        private void apagarfilmeBTN_Click(object sender, EventArgs e)
        {
            DeleteBook();
            FillGridView();

        }

        void DeleteBook()
        {
            if (dataGridViewFilmes.CurrentRow != null)
            {
                int filmeID;
                if (int.TryParse(dataGridViewFilmes.CurrentRow.Cells[0].Value.ToString(), out filmeID))
                {
                    string filmeTitulo = dataGridViewFilmes.CurrentRow.Cells[1].Value.ToString();

                    DialogResult result = MessageBox.Show($"Tem a certeza que deseja apagar o filme '{filmeTitulo}'?", "Apagar Filme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        FilmeClass filmeClass = new FilmeClass(); 
                        string errorMessage = filmeClass.DeleteFilme(filmeID); 

                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            MessageBox.Show("Filme apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillGridView();
                        }
                        else
                        {
                            MessageBox.Show(errorMessage, "Erro ao Apagar Filme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ID do filme selecionado.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um filme para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewFilmes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class EditFilmeForm : Form
    {
        int selectFilmeID;
        string originalTitulo;

        public EditFilmeForm(int filmeID)
        {
            InitializeComponent();
            selectFilmeID = filmeID;
            GetFilmeData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditFilmeForm_Load(object sender, EventArgs e)
        {

        }

        private void EditarBTN_Click(object sender, EventArgs e)
        {
            EditFilmeData();
        }

        void GetFilmeData()
        {
            try
            {
                FilmeClass filmeClass = new FilmeClass();
                filmeClass = filmeClass.GetFilmeData(selectFilmeID);
                txtTitulo.Text = filmeClass.Titulo;
                txtGenero.Text = filmeClass.Genero;
                txtReal.Text = filmeClass.Realizador;
                txtDura.Text = filmeClass.Duracao.ToString();
                txtAno.Text = filmeClass.AnoLancamento.ToString();
                originalTitulo = filmeClass.Titulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar os dados do filme: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void GotoMainForm()
        {
            this.Close();
        }

        void EditFilmeData()
        {
            string titulo = txtTitulo.Text.Trim();

            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("O título do filme não pode estar vazio.", "Erro de Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }

            if (titulo.ToLower() != originalTitulo.ToLower())
            {
                try
                {
                    if (FilmeClass.ExisteTituloOutroFilme(titulo, selectFilmeID))
                    {
                        MessageBox.Show("O filme já existe com este título.", "Título Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTitulo.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao verificar o título do filme: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string duracaoText = txtDura.Text.Trim();
            int duracao;
            if (int.TryParse(duracaoText, out duracao))
            {

            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido para a Duração.", "Erro de Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDura.Focus();
                return;
            }

            string anoText = txtAno.Text.Trim();
            int anoLancamento;
            if (int.TryParse(anoText, out anoLancamento))
            {

            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido para o Ano de Lançamento.", "Erro de Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAno.Focus();
                return;
            }

            FilmeClass filmeParaEditar = new FilmeClass();
            filmeParaEditar.FilmeID = selectFilmeID;
            filmeParaEditar.Titulo = titulo;
            filmeParaEditar.Genero = txtGenero.Text.Trim();
            filmeParaEditar.Realizador = txtReal.Text.Trim();
            filmeParaEditar.Duracao = duracao;
            filmeParaEditar.AnoLancamento = anoLancamento;

            try
            {
                filmeParaEditar.EditFilme(filmeParaEditar);
                MessageBox.Show("Filme editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GotoMainForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao editar o filme: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelEditar_Click(object sender, EventArgs e)
        {
            GotoMainForm();
        }
    }
}


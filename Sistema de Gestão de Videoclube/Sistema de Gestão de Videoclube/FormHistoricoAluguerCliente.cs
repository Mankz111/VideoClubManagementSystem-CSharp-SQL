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
    public partial class FormHistoricoAluguerCliente : Form
    {
        private int clienteID; 
        private string clienteNome;


        public FormHistoricoAluguerCliente(int idCliente, string nomeCliente)
        {
            InitializeComponent();
            clienteID = idCliente;
            clienteNome = nomeCliente;
            this.Text = $"Histórico de Alugueres de: {clienteNome}";
        }


        public FormHistoricoAluguerCliente()
        {
            InitializeComponent();
        }


        private void FormHistoricoAluguerCliente_Load(object sender, EventArgs e)
        {

            if (clienteID > 0)
            {
                LoadHistoricoAluguer();
            }
            else
            {
                MessageBox.Show("Erro: ID do cliente não fornecido para carregar o histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadHistoricoAluguer()
        {
            AluguerClass aluguerManager = new AluguerClass();
            List<AluguerClass> historico = aluguerManager.GetHistoricoByClienteID(clienteID);


            dgvHistoricoAluguer.DataSource = historico;


            if (dgvHistoricoAluguer.Columns.Contains("AluguerID")) dgvHistoricoAluguer.Columns["AluguerID"].Visible = false;
            if (dgvHistoricoAluguer.Columns.Contains("ClienteID")) dgvHistoricoAluguer.Columns["ClienteID"].Visible = false;
            if (dgvHistoricoAluguer.Columns.Contains("FilmeID")) dgvHistoricoAluguer.Columns["FilmeID"].Visible = false;


            if (dgvHistoricoAluguer.Columns.Contains("DataAluguer")) dgvHistoricoAluguer.Columns["DataAluguer"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvHistoricoAluguer.Columns.Contains("DataPrevistaDev")) dgvHistoricoAluguer.Columns["DataPrevistaDev"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvHistoricoAluguer.Columns.Contains("DataDevolucao"))
            {
                dgvHistoricoAluguer.Columns["DataDevolucao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHistoricoAluguer.Columns["DataDevolucao"].DefaultCellStyle.NullValue = "Não Devolvido";
            }



            if (dgvHistoricoAluguer.Columns.Contains("Nome")) dgvHistoricoAluguer.Columns["Nome"].HeaderText = "Cliente";
            if (dgvHistoricoAluguer.Columns.Contains("Titulo")) dgvHistoricoAluguer.Columns["Titulo"].HeaderText = "Filme";
            if (dgvHistoricoAluguer.Columns.Contains("DataAluguer")) dgvHistoricoAluguer.Columns["DataAluguer"].HeaderText = "Data Aluguer";
            if (dgvHistoricoAluguer.Columns.Contains("DataPrevistaDev")) dgvHistoricoAluguer.Columns["DataPrevistaDev"].HeaderText = "Data Prevista Devolução";
            if (dgvHistoricoAluguer.Columns.Contains("DataDevolucao")) dgvHistoricoAluguer.Columns["DataDevolucao"].HeaderText = "Data Devolução";
            dgvHistoricoAluguer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }


        private void dgvHistoricoAluguer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

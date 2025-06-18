using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestão_de_Videoclube.Classes;


namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
            FillGridView();
        }

        private void FormCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void FillGridView()
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            clientes = cliente.GetClientes();
            dataGridViewClientes.DataSource = clientes;
            dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewClientes.Columns.Contains("ClienteID"))
            {
                dataGridViewClientes.Columns["ClienteID"].Visible = false;
            }
            if (dataGridViewClientes.Columns.Contains("Nome"))
            {
                dataGridViewClientes.Columns["Nome"].HeaderText = "Nome do Cliente";
            }
            if (dataGridViewClientes.Columns.Contains("Telefone"))
            {
                dataGridViewClientes.Columns["Telefone"].HeaderText = "Telefone";
            }
            if (dataGridViewClientes.Columns.Contains("NIF"))
            {
                dataGridViewClientes.Columns["NIF"].HeaderText = "NIF";
            }
            if (dataGridViewClientes.Columns.Contains("Email"))
            {
                dataGridViewClientes.Columns["Email"].HeaderText = "Email";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarCliente adicionarCliente = new AdicionarCliente();
            adicionarCliente.ShowDialog();
            FillGridView();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        void EditCliente()
        {
            if (dataGridViewClientes.CurrentRow != null)
            {
                int clienteID;
                if (int.TryParse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString(), out clienteID))
                {
                    EditarCliente editarCliente = new EditarCliente(clienteID);
                    editarCliente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ID do cliente para edição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditCliente();
            FillGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCliente();
        }

        void DeleteCliente()
        {
            if (dataGridViewClientes.CurrentRow != null)
            {
                int clienteID;
                if (int.TryParse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString(), out clienteID))
                {
                    string clienteName = dataGridViewClientes.CurrentRow.Cells[1].Value.ToString();
                    string message = "Tens a certeza que queres apagar o cliente '" + clienteName + "'?";
                    DialogResult dr = MessageBox.Show(message, "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        Cliente clienteService = new Cliente();
                        string errorMessage = clienteService.DeleteCliente(clienteID);

                        if (string.IsNullOrEmpty(errorMessage)) 
                        {
                            MessageBox.Show("Cliente eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillGridView(); 
                        }
                        else
                        {
                            MessageBox.Show(errorMessage, "Erro de Eliminação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ID do cliente para apagar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridViewClientes.CurrentRow == null)
            {
                return;
            }

            int clienteID = -1;
            string clienteName = "Cliente Desconhecido";

            if (dataGridViewClientes.Columns.Contains("ClienteID") && dataGridViewClientes.CurrentRow.Cells["ClienteID"].Value != null)
            {
                if (!int.TryParse(dataGridViewClientes.CurrentRow.Cells["ClienteID"].Value.ToString(), out clienteID))
                {
                    MessageBox.Show("Não foi possível obter o ID do cliente selecionado (valor inválido).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (dataGridViewClientes.CurrentRow.Cells.Count > 0 && dataGridViewClientes.CurrentRow.Cells[0].Value != null)
            {
                if (!int.TryParse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString(), out clienteID))
                {
                    MessageBox.Show("Não foi possível obter o ID do cliente selecionado (valor inválido na Célula[0]).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Não foi possível obter o ID do cliente da linha selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewClientes.Columns.Contains("Nome") && dataGridViewClientes.CurrentRow.Cells["Nome"].Value != null)
            {
                clienteName = dataGridViewClientes.CurrentRow.Cells["Nome"].Value.ToString();
            }
            else if (dataGridViewClientes.CurrentRow.Cells.Count > 1 && dataGridViewClientes.CurrentRow.Cells[1].Value != null)
            {
                clienteName = dataGridViewClientes.CurrentRow.Cells[1].Value.ToString();
            }

            int nomeColumnIndex = -1;
            foreach (DataGridViewColumn col in dataGridViewClientes.Columns)
            {
                if (col.DataPropertyName == "Nome")
                {
                    nomeColumnIndex = col.Index;
                    break;
                }
                if (nomeColumnIndex == -1 && col.Name == "Nome")
                {
                    nomeColumnIndex = col.Index;
                }
                if (nomeColumnIndex == -1 && col.HeaderText == "Nome do Cliente")
                {
                    nomeColumnIndex = col.Index;
                }
            }


            if (e.ColumnIndex == nomeColumnIndex && nomeColumnIndex != -1)
            {
                try
                {
                    FormHistoricoAluguer formHistorico = new FormHistoricoAluguer();
                    formHistorico.ClienteID = clienteID;
                    formHistorico.ClienteNome = clienteName;
                    formHistorico.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar abrir o histórico do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                EditCliente();
                FillGridView();
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
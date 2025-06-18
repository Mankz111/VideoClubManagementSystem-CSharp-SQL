using System;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class AdicionarCliente : Form
    {
        private ErrorProvider errorProvider1;

        public AdicionarCliente()
        {
            InitializeComponent();
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = SystemIcons.Error;
        }

        private void AdicionarCliente_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void addClienteOKbtn_Click(object sender, EventArgs e)
        {
            SaveClientData();
        }

        void SaveClientData()
        {
            errorProvider1.Clear();
            bool uiValidationPassed = true;

            Cliente novoCliente = new Cliente();

            novoCliente.Nome = textBoxNOME.Text.Trim();
            if (string.IsNullOrWhiteSpace(novoCliente.Nome))
            {
                errorProvider1.SetError(textBoxNOME, "O nome é obrigatório.");
                uiValidationPassed = false;
            }

            novoCliente.Email = textBoxMAIL.Text.Trim();
            if (string.IsNullOrWhiteSpace(novoCliente.Email))
            {
                errorProvider1.SetError(textBoxMAIL, "O email é obrigatório.");
                uiValidationPassed = false;
            }

            int nifValue;
            if (!int.TryParse(textBoxNIF.Text.Trim(), out nifValue))
            {
                errorProvider1.SetError(textBoxNIF, "O NIF deve ser um número válido.");
                uiValidationPassed = false;
            }
            else
            {
                novoCliente.NIF = nifValue;
            }

            int telefoneValue;
            if (!int.TryParse(textBoxTEL.Text.Trim(), out telefoneValue))
            {
                errorProvider1.SetError(textBoxTEL, "O telefone deve ser um número válido.");
                uiValidationPassed = false;
            }
            else
            {
                novoCliente.Telefone = telefoneValue;
            }

            if (!uiValidationPassed)
            {
                MessageBox.Show("Por favor, corrija os erros assinalados no formulário.", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationError;
            if (!novoCliente.IsValid(out validationError))
            {
                MessageBox.Show(validationError, "Erro de Validação de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (novoCliente.ExisteNif(textBoxNIF.Text.Trim()))
                {
                    errorProvider1.SetError(textBoxNIF, "Já existe um cliente com este NIF.");
                    MessageBox.Show("Já existe um cliente com este NIF. Por favor, verifique.", "NIF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNIF.Focus();
                    textBoxNIF.SelectAll();
                    return;
                }

                if (novoCliente.ExisteEmail(textBoxMAIL.Text.Trim()))
                {
                    errorProvider1.SetError(textBoxMAIL, "Já existe um cliente com este email.");
                    MessageBox.Show("Já existe um cliente com este email. Por favor, verifique.", "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMAIL.Focus();
                    textBoxMAIL.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao verificar dados duplicados: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                novoCliente.CreateCliente(novoCliente);
                MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Erro ao adicionar cliente: Já existe um cliente com este NIF ou Email.", "Dados Duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na base de dados ao adicionar o cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao adicionar o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addClienteCancelBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


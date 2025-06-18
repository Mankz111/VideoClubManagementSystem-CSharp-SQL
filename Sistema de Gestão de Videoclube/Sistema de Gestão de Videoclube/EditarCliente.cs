using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestão_de_Videoclube;
using Microsoft.Data.SqlClient;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class EditarCliente : Form
    {
        int selectedClienteID;
        private ErrorProvider errorProvider1;

        public EditarCliente(int clienteID)
        {
            InitializeComponent();
            selectedClienteID = clienteID;
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = SystemIcons.Error;
            GetClienteData();
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void editClienteOK_Click(object sender, EventArgs e)
        {
            EditClienteData();
        }

        void GetClienteData()
        {
            Cliente cliente = new Cliente();
            Cliente clienteData = cliente.GetClienteData(selectedClienteID);

            if (clienteData != null)
            {
                editTEXT.Text = clienteData.Nome;
                editMAIL.Text = clienteData.Email;
                editNIF.Text = clienteData.NIF.ToString();
                editTEL.Text = clienteData.Telefone.ToString();
            }
            else
            {
                MessageBox.Show("Não foi possível carregar os dados do cliente para edição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void GotoMainForm()
        {
            this.Close();
        }

        void EditClienteData()
        {
            errorProvider1.Clear();
            bool uiValidationPassed = true;

            if (string.IsNullOrWhiteSpace(editTEXT.Text))
            {
                errorProvider1.SetError(editTEXT, "O campo Nome é obrigatório.");
                uiValidationPassed = false;
            }

            int nif;
            if (!int.TryParse(editNIF.Text.Trim(), out nif))
            {
                errorProvider1.SetError(editNIF, "Por favor, insira um NIF válido (apenas números).");
                uiValidationPassed = false;
            }

            int telefone;
            if (!int.TryParse(editTEL.Text.Trim(), out telefone))
            {
                errorProvider1.SetError(editTEL, "Por favor, insira um Telefone válido (apenas números).");
                uiValidationPassed = false;
            }

            if (string.IsNullOrWhiteSpace(editMAIL.Text))
            {
                errorProvider1.SetError(editMAIL, "O email é obrigatório.");
                uiValidationPassed = false;
            }

            if (!uiValidationPassed)
            {
                MessageBox.Show("Por favor, corrija os erros assinalados no formulário.", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = new Cliente();
            cliente.ClienteID = selectedClienteID;
            cliente.Nome = editTEXT.Text.Trim();
            cliente.Telefone = telefone;
            cliente.NIF = nif;
            cliente.Email = editMAIL.Text.Trim();

            string validationError;
            if (!cliente.IsValid(out validationError))
            {
                MessageBox.Show(validationError, "Erro de Validação de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Verifica se o NIF já existe para OUTRO cliente
                Cliente clienteComNif = new Cliente().GetClientes().FirstOrDefault(c => c.NIF == nif && c.ClienteID != selectedClienteID);
                if (clienteComNif != null)
                {
                    errorProvider1.SetError(editNIF, $"Já existe um cliente com este NIF (ID: {clienteComNif.ClienteID}).");
                    MessageBox.Show("Já existe um cliente com este NIF. Por favor, verifique.", "NIF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    editNIF.Focus();
                    editNIF.SelectAll();
                    return;
                }

                // Verifica se o Email já existe para OUTRO cliente
                Cliente clienteComEmail = new Cliente().GetClientes().FirstOrDefault(c => c.Email.Equals(editMAIL.Text.Trim(), StringComparison.OrdinalIgnoreCase) && c.ClienteID != selectedClienteID);
                if (clienteComEmail != null)
                {
                    errorProvider1.SetError(editMAIL, $"Já existe um cliente com este Email (ID: {clienteComEmail.ClienteID}).");
                    MessageBox.Show("Já existe um cliente com este Email. Por favor, verifique.", "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    editMAIL.Focus();
                    editMAIL.SelectAll();
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
                cliente.EditCliente(cliente);
                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indica que a edição foi bem-sucedida
                GotoMainForm();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Erro ao atualizar cliente: Já existe um cliente com este NIF ou Email.", "Dados Duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ex.Message.Contains("NIF"))
                    {
                        errorProvider1.SetError(editNIF, "NIF já existe.");
                        editNIF.Focus();
                    }
                    else if (ex.Message.Contains("Email"))
                    {
                        errorProvider1.SetError(editMAIL, "Email já existe.");
                        editMAIL.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na base de dados ao atualizar o cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao atualizar o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editClienteCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indica que a edição foi cancelada
            GotoMainForm();
        }
    }
}

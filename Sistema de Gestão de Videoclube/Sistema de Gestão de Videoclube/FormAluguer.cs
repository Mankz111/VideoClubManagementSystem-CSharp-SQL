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
    public partial class FormAluguer : Form
    {
        public FormAluguer()
        {
            InitializeComponent();
            FillGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAluguer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewAluguerForm newAluguerForm = new NewAluguerForm();
            newAluguerForm.ShowDialog();
            FillGridView();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditAluguer();
            FillGridView();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        void FillGridView()
        {
            List<AluguerClass> alugueres = new List<AluguerClass>();
            AluguerClass aluguer = new AluguerClass();
            alugueres = aluguer.GetAlugueres();
            dataGridView1.DataSource = alugueres;
        }
        private void FormAluguer_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        void EditAluguer()
        {
            if (dataGridView1.CurrentRow != null)
            {

                int aluguerIdParaEditar = 0;
                try
                {
                    aluguerIdParaEditar = (int)dataGridView1.CurrentRow.Cells[0].Value;
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Erro ao obter o ID do aluguer selecionado. Verifique se a primeira coluna contém o AluguerID.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                EditAluguerForm formEditAluguer = new EditAluguerForm(aluguerIdParaEditar);
                DialogResult result = formEditAluguer.ShowDialog();

                if (result == DialogResult.OK)
                {
                    FillGridView();
                }
            }
            else
            {
                MessageBox.Show("Selecione um aluguer para editar.", "Nenhuma Seleção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

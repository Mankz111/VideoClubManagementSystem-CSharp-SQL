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
    public partial class EditAluguerForm : Form
    {
        int selectedAluguerID;

        public EditAluguerForm(int aluguerID)
        {
            InitializeComponent();
            selectedAluguerID = aluguerID;
            GetAluguerData();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditAluguerData();
            GotoMainForm();

        }

        void GetAluguerData()
        {
            AluguerClass aluguer = new AluguerClass();
            aluguer = aluguer.GetAluguerData(selectedAluguerID);

            if (aluguer.DataAluguer == DateTime.MinValue)
            {
                aluguer.DataAluguer = DateTime.Today;
            }

            if (aluguer.DataPrevistaDev == DateTime.MinValue)
            {
                aluguer.DataPrevistaDev = aluguer.DataAluguer.AddMonths(1);
            }

            txtCliente.Text = aluguer.Nome;
            txtFilme.Text = aluguer.Titulo;
            txtDataA.Text = aluguer.DataAluguer.ToString("dd-MM-yyyy");
            txtDataPrevDev.Text = aluguer.DataPrevistaDev.ToString("dd-MM-yyyy");
        }

        void GotoMainForm()
        {
            this.Close();
        }
        void EditAluguerData()
        {
            if (!DateTime.TryParse(txtDataA.Text, out DateTime dataAluguer) ||
                !DateTime.TryParse(txtDataPrevDev.Text, out DateTime dataPrevDev))
            {
                MessageBox.Show("Formato de data inválido! Use dd-MM-yyyy.");
                return;
            }

            AluguerClass aluguer = new AluguerClass();
            aluguer.AluguerID = selectedAluguerID;
            aluguer.DataAluguer = dataAluguer;
            aluguer.DataPrevistaDev = dataPrevDev;
            aluguer.UpdateAluguer(aluguer);
        }
    }
}

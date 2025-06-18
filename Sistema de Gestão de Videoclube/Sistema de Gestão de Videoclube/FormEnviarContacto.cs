using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class FormEnviarContacto : Form
    {
        private string _nomeCliente;
        private string _emailCliente;
        private string _telefoneCliente;
        private string _tituloFilme;
        private int _diasEmAtraso;
        private DateTime _dataAluguer;
        private DateTime _dataPrevistaDev;
        private string _nifCliente;

        public FormEnviarContacto()
        {
            InitializeComponent();
            
            this.Shown += (s, e) => AtualizarMensagem();
        }

        public string NomeCliente
        {
            get => _nomeCliente;
            set
            {
                _nomeCliente = value;
                lblNomeCliente.Text = value;
                AtualizarMensagem();
            }
        }

        public string NIFCliente
        {
            get => _nifCliente;
            set
            {
                _nifCliente = value;
                lblNIFCliente.Text = value;
                AtualizarMensagem();
            }
        }

        public string TituloFilme
        {
            get => _tituloFilme;
            set
            {
                _tituloFilme = value;
                lblFilme.Text = value;
                AtualizarMensagem();
            }
        }

        public int DiasEmAtraso
        {
            get => _diasEmAtraso;
            set
            {
                _diasEmAtraso = value;
                lblDiasEmAtraso.Text = value.ToString();
                AtualizarMensagem();
            }
        }

        public DateTime DataAluguer
        {
            get => _dataAluguer;
            set
            {
                _dataAluguer = value;
                AtualizarMensagem();
            }
        }

        public DateTime DataPrevistaDev
        {
            get => _dataPrevistaDev;
            set
            {
                _dataPrevistaDev = value;
                AtualizarMensagem();
            }
        }

        public string EmailCliente
        {
            get => _emailCliente;
            set
            {
                _emailCliente = value;
                if (radioButton1.Checked)
                    textBox1.Text = value;
            }
        }

        public string TelefoneCliente
        {
            get => _telefoneCliente;
            set
            {
                _telefoneCliente = value;
                if (radioButton2.Checked)
                    textBox1.Text = value;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtCampoContacto.Text = "Email:";
                textBox1.Text = _emailCliente;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtCampoContacto.Text = "Nº de Telemóvel:";
                textBox1.Text = _telefoneCliente;
            }
        }
        private void AtualizarMensagem()
        {
            // Garante que temos os dados necessários
            if (string.IsNullOrWhiteSpace(_nomeCliente) ||
                string.IsNullOrWhiteSpace(_tituloFilme) ||
                _dataAluguer == default ||
                _dataPrevistaDev == default)
                return;

            textBox2.Text =
                $"Estimado(a) {_nomeCliente},\r\n\r\n" +
                $"Gostaríamos de relembrar que o filme “{_tituloFilme}” alugado em {_dataAluguer:dd/MM/yyyy} " +
                $"deveria ter sido devolvido em {_dataPrevistaDev:dd/MM/yyyy}. " +
                $"Atualmente encontra-se com {_diasEmAtraso} dias de atraso.\r\n\r\n" +
                "Por favor, proceda à devolução o mais breve possível para evitar custos adicionais.\r\n" +
                "Agradecemos a sua atenção.\r\n\r\n" +
                "Com os melhores cumprimentos,\r\n" +
                "O seu Videoclube";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var to = _emailCliente;
                var subject = "Notificação de Devolução de Filme";
                var body = textBox2.Text;
                var mailto = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

                try
                {
                    Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
                }
                catch
                {
                    MessageBox.Show(
                        "Não foi possível abrir o cliente de e‑mail no sistema. Por favor copie a mensagem manualmente.",
                        "Falha ao abrir cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    $"[SIMULAÇÃO] A enviar SMS para {_telefoneCliente}...\r\n\r\n{textBox2.Text}",
                    "SMS Simulada", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


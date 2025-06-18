namespace Sistema_de_Gestão_de_Videoclube
{
    partial class FormEnviarContacto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBox2 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            txtCampoContacto = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label4 = new Label();
            groupBox2 = new GroupBox();
            lblDiasEmAtraso = new Label();
            lblNIFCliente = new Label();
            lblFilme = new Label();
            lblNomeCliente = new Label();
            txtDiasEmAtraso = new Label();
            txtNIF = new Label();
            txtNomeFilme = new Label();
            txtNomeCliente = new Label();
            label3 = new Label();
            label2 = new Label();
            btnEnviar = new Button();
            btnCancelar = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 56);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(387, 30);
            label1.TabIndex = 0;
            label1.Text = "Contactar Cliente - Aluguer em Atraso";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txtCampoContacto);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 453);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(18, 302);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(741, 145);
            textBox2.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(18, 282);
            label7.Name = "label7";
            label7.Size = new Size(79, 17);
            label7.TabIndex = 8;
            label7.Text = "Mensagem:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(365, 213);
            label6.Name = "label6";
            label6.Size = new Size(0, 17);
            label6.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 247);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 6;
            // 
            // txtCampoContacto
            // 
            txtCampoContacto.AutoSize = true;
            txtCampoContacto.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCampoContacto.Location = new Point(18, 227);
            txtCampoContacto.Name = "txtCampoContacto";
            txtCampoContacto.Size = new Size(46, 17);
            txtCampoContacto.TabIndex = 5;
            txtCampoContacto.Text = "Email:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(78, 189);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(48, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "SMS";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 189);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Email";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 157);
            label4.Name = "label4";
            label4.Size = new Size(138, 17);
            label4.TabIndex = 2;
            label4.Text = "Método de Contacto:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Silver;
            groupBox2.Controls.Add(lblDiasEmAtraso);
            groupBox2.Controls.Add(lblNIFCliente);
            groupBox2.Controls.Add(lblFilme);
            groupBox2.Controls.Add(lblNomeCliente);
            groupBox2.Controls.Add(txtDiasEmAtraso);
            groupBox2.Controls.Add(txtNIF);
            groupBox2.Controls.Add(txtNomeFilme);
            groupBox2.Controls.Add(txtNomeCliente);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(732, 111);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // lblDiasEmAtraso
            // 
            lblDiasEmAtraso.AutoSize = true;
            lblDiasEmAtraso.Location = new Point(485, 72);
            lblDiasEmAtraso.Name = "lblDiasEmAtraso";
            lblDiasEmAtraso.Size = new Size(44, 15);
            lblDiasEmAtraso.TabIndex = 8;
            lblDiasEmAtraso.Text = "label10";
            // 
            // lblNIFCliente
            // 
            lblNIFCliente.AutoSize = true;
            lblNIFCliente.Location = new Point(424, 48);
            lblNIFCliente.Name = "lblNIFCliente";
            lblNIFCliente.Size = new Size(38, 15);
            lblNIFCliente.TabIndex = 7;
            lblNIFCliente.Text = "label9";
            // 
            // lblFilme
            // 
            lblFilme.AutoSize = true;
            lblFilme.Location = new Point(59, 72);
            lblFilme.Name = "lblFilme";
            lblFilme.Size = new Size(38, 15);
            lblFilme.TabIndex = 6;
            lblFilme.Text = "label8";
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(59, 48);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(38, 15);
            lblNomeCliente.TabIndex = 5;
            lblNomeCliente.Text = "label5";
            // 
            // txtDiasEmAtraso
            // 
            txtDiasEmAtraso.AutoSize = true;
            txtDiasEmAtraso.Location = new Point(390, 72);
            txtDiasEmAtraso.Name = "txtDiasEmAtraso";
            txtDiasEmAtraso.Size = new Size(89, 15);
            txtDiasEmAtraso.TabIndex = 4;
            txtDiasEmAtraso.Text = "Dias em Atraso:";
            // 
            // txtNIF
            // 
            txtNIF.AutoSize = true;
            txtNIF.Location = new Point(390, 48);
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(28, 15);
            txtNIF.TabIndex = 3;
            txtNIF.Text = "NIF:";
            // 
            // txtNomeFilme
            // 
            txtNomeFilme.AutoSize = true;
            txtNomeFilme.Location = new Point(14, 72);
            txtNomeFilme.Name = "txtNomeFilme";
            txtNomeFilme.Size = new Size(39, 15);
            txtNomeFilme.TabIndex = 2;
            txtNomeFilme.Text = "Filme:";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.AutoSize = true;
            txtNomeCliente.Location = new Point(14, 48);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(43, 15);
            txtNomeCliente.TabIndex = 1;
            txtNomeCliente.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(179, 17);
            label3.TabIndex = 0;
            label3.Text = "INFORMAÇÕES DO CLIENTE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(268, 21);
            label2.TabIndex = 0;
            label2.Text = "Notificação de Aluguer em Atraso";
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.DodgerBlue;
            btnEnviar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnviar.ForeColor = SystemColors.Control;
            btnEnviar.Location = new Point(12, 521);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(97, 32);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DodgerBlue;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = SystemColors.Control;
            btnCancelar.Location = new Point(115, 521);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 32);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormEnviarContacto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 565);
            Controls.Add(btnCancelar);
            Controls.Add(btnEnviar);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "FormEnviarContacto";
            Text = "Contacto";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label4;
        private Label txtDiasEmAtraso;
        private Label txtNIF;
        private Label txtNomeFilme;
        private Label txtNomeCliente;
        private Label label3;
        private TextBox textBox1;
        private Label txtCampoContacto;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private Button btnEnviar;
        private Button btnCancelar;
        private Label lblDiasEmAtraso;
        private Label lblNIFCliente;
        private Label lblFilme;
        private Label lblNomeCliente;
    }
}
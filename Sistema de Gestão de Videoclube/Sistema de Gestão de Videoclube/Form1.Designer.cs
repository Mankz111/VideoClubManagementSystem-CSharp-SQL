namespace Sistema_de_Gestão_de_Videoclube
{
    partial class MainForm
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
            dataGridViewAlugueresRecentes = new DataGridView();
            label1 = new Label();
            clientesBTN = new Button();
            alugueresBTN = new Button();
            filmesBTN = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            historicoAlugueresBTN = new Button();
            panel1 = new Panel();
            btnRelatorios = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlugueresRecentes).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewAlugueresRecentes
            // 
            dataGridViewAlugueresRecentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlugueresRecentes.Location = new Point(36, 335);
            dataGridViewAlugueresRecentes.Name = "dataGridViewAlugueresRecentes";
            dataGridViewAlugueresRecentes.Size = new Size(739, 185);
            dataGridViewAlugueresRecentes.TabIndex = 0;
            dataGridViewAlugueresRecentes.CellContentClick += dataGridViewAlugueresRecentes_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(289, 35);
            label1.Name = "label1";
            label1.Size = new Size(226, 30);
            label1.TabIndex = 1;
            label1.Text = "Gestão de Videoclube";
            // 
            // clientesBTN
            // 
            clientesBTN.Location = new Point(6, 37);
            clientesBTN.Name = "clientesBTN";
            clientesBTN.Size = new Size(161, 37);
            clientesBTN.TabIndex = 2;
            clientesBTN.Text = "Gestão de Clientes\r\n";
            clientesBTN.UseVisualStyleBackColor = true;
            clientesBTN.Click += clientesBTN_Click;
            // 
            // alugueresBTN
            // 
            alugueresBTN.Location = new Point(353, 37);
            alugueresBTN.Name = "alugueresBTN";
            alugueresBTN.Size = new Size(179, 37);
            alugueresBTN.TabIndex = 3;
            alugueresBTN.Text = "Gestão de Alugueres";
            alugueresBTN.UseVisualStyleBackColor = true;
            alugueresBTN.Click += alugueresBTN_Click;
            // 
            // filmesBTN
            // 
            filmesBTN.Location = new Point(182, 37);
            filmesBTN.Name = "filmesBTN";
            filmesBTN.Size = new Size(165, 37);
            filmesBTN.TabIndex = 9;
            filmesBTN.Text = "Gestão de Filmes";
            filmesBTN.UseVisualStyleBackColor = true;
            filmesBTN.Click += filmesBTN_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 304);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 14;
            label2.Text = "Alugueres Atuais: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRelatorios);
            groupBox1.Controls.Add(historicoAlugueresBTN);
            groupBox1.Controls.Add(filmesBTN);
            groupBox1.Controls.Add(alugueresBTN);
            groupBox1.Controls.Add(clientesBTN);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(36, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(558, 165);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acesso Rápido";
            // 
            // historicoAlugueresBTN
            // 
            historicoAlugueresBTN.Location = new Point(60, 97);
            historicoAlugueresBTN.Name = "historicoAlugueresBTN";
            historicoAlugueresBTN.Size = new Size(189, 37);
            historicoAlugueresBTN.TabIndex = 10;
            historicoAlugueresBTN.Text = "Histórico de Alugueres";
            historicoAlugueresBTN.UseVisualStyleBackColor = true;
            historicoAlugueresBTN.Click += historicoAlugueresBTN_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(833, 100);
            panel1.TabIndex = 17;
            // 
            // btnRelatorios
            // 
            btnRelatorios.Location = new Point(277, 97);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(189, 37);
            btnRelatorios.TabIndex = 11;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = true;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 571);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(dataGridViewAlugueresRecentes);
            Name = "MainForm";
            Text = "Sistema de Gestão de Videoclube";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlugueresRecentes).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private DataGridView dataGridViewAlugueresRecentes;
        private Label label1;
        private Button clientesBTN;
        private Button alugueresBTN;
        private Button filmesBTN;
        private Label label2;
        private GroupBox groupBox1;
        private Button historicoAlugueresBTN;
        private Panel panel1;
        private Button btnRelatorios;
    }
}

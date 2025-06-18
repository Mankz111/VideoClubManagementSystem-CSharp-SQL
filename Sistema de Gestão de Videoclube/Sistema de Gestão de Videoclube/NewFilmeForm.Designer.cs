
namespace Sistema_de_Gestão_de_Videoclube
{
    partial class NewFilmeForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtFilme = new TextBox();
            txtGenero = new TextBox();
            label2 = new Label();
            txtRealizador = new TextBox();
            label3 = new Label();
            txtDuracao = new TextBox();
            label4 = new Label();
            txtAno = new TextBox();
            label5 = new Label();
            novoFilmeOK = new Button();
            novofilmeCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            lstSugestoesFilme = new ListBox();
            timerSugestao = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 51);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Título:";
            // 
            // txtFilme
            // 
            txtFilme.Location = new Point(54, 69);
            txtFilme.Name = "txtFilme";
            txtFilme.Size = new Size(353, 23);
            txtFilme.TabIndex = 1;
            txtFilme.TextChanged += txtFilme_TextChanged;
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(54, 138);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(353, 23);
            txtGenero.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 120);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Género:";
            // 
            // txtRealizador
            // 
            txtRealizador.Location = new Point(54, 194);
            txtRealizador.Name = "txtRealizador";
            txtRealizador.Size = new Size(353, 23);
            txtRealizador.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 176);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Realizador:";
            // 
            // txtDuracao
            // 
            txtDuracao.Location = new Point(54, 250);
            txtDuracao.Name = "txtDuracao";
            txtDuracao.Size = new Size(353, 23);
            txtDuracao.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 232);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 6;
            label4.Text = "Duração:";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(54, 303);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(353, 23);
            txtAno.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 285);
            label5.Name = "label5";
            label5.Size = new Size(117, 15);
            label5.TabIndex = 8;
            label5.Text = "Ano de Lançamento:";
            // 
            // novoFilmeOK
            // 
            novoFilmeOK.Location = new Point(54, 368);
            novoFilmeOK.Name = "novoFilmeOK";
            novoFilmeOK.Size = new Size(75, 23);
            novoFilmeOK.TabIndex = 10;
            novoFilmeOK.Text = "OK";
            novoFilmeOK.UseVisualStyleBackColor = true;
            novoFilmeOK.Click += novoFilmeOK_Click;
            // 
            // novofilmeCancel
            // 
            novofilmeCancel.Location = new Point(135, 368);
            novofilmeCancel.Name = "novofilmeCancel";
            novofilmeCancel.Size = new Size(75, 23);
            novofilmeCancel.TabIndex = 11;
            novofilmeCancel.Text = "Cancel";
            novofilmeCancel.UseVisualStyleBackColor = true;
            novofilmeCancel.Click += novofilmeCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lstSugestoesFilme
            // 
            lstSugestoesFilme.FormattingEnabled = true;
            lstSugestoesFilme.ItemHeight = 15;
            lstSugestoesFilme.Location = new Point(54, 98);
            lstSugestoesFilme.Name = "lstSugestoesFilme";
            lstSugestoesFilme.Size = new Size(353, 19);
            lstSugestoesFilme.TabIndex = 12;
            // 
            // timerSugestao
            // 
            timerSugestao.Interval = 500;
            // 
            // NewFilmeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 450);
            Controls.Add(lstSugestoesFilme);
            Controls.Add(novofilmeCancel);
            Controls.Add(novoFilmeOK);
            Controls.Add(txtAno);
            Controls.Add(label5);
            Controls.Add(txtDuracao);
            Controls.Add(label4);
            Controls.Add(txtRealizador);
            Controls.Add(label3);
            Controls.Add(txtGenero);
            Controls.Add(label2);
            Controls.Add(txtFilme);
            Controls.Add(label1);
            Name = "NewFilmeForm";
            Text = "Adicionar Novo Filme";
            Load += NewFilmeForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private TextBox txtFilme;
        private TextBox txtGenero;
        private Label label2;
        private TextBox txtRealizador;
        private Label label3;
        private TextBox txtDuracao;
        private Label label4;
        private TextBox txtAno;
        private Label label5;
        private Button novoFilmeOK;
        private Button novofilmeCancel;
        private ErrorProvider errorProvider1;
        private ListBox lstSugestoesFilme;
        private System.Windows.Forms.Timer timerSugestao;
    }
}
namespace Sistema_de_Gestão_de_Videoclube
{
    partial class NewAluguerForm
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
            button1OK = new Button();
            button2Cancel = new Button();
            label1 = new Label();
            txtNome = new TextBox();
            txtTitulo = new TextBox();
            label2 = new Label();
            txtDataAluguer = new TextBox();
            label3 = new Label();
            txtDataPrevistaDev = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1OK
            // 
            button1OK.Location = new Point(90, 382);
            button1OK.Name = "button1OK";
            button1OK.Size = new Size(75, 23);
            button1OK.TabIndex = 0;
            button1OK.Text = "OK";
            button1OK.UseVisualStyleBackColor = true;
            button1OK.Click += button1OK_Click;
            // 
            // button2Cancel
            // 
            button2Cancel.Location = new Point(171, 382);
            button2Cancel.Name = "button2Cancel";
            button2Cancel.Size = new Size(75, 23);
            button2Cancel.TabIndex = 1;
            button2Cancel.Text = "Cancel";
            button2Cancel.UseVisualStyleBackColor = true;
            button2Cancel.Click += button2Cancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 46);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Cliente:";
            // 
            // txtNome
            // 
            txtNome.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNome.Location = new Point(38, 64);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(233, 23);
            txtNome.TabIndex = 3;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(38, 117);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(233, 23);
            txtTitulo.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 99);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Filme:";
            // 
            // txtDataAluguer
            // 
            txtDataAluguer.Location = new Point(38, 183);
            txtDataAluguer.Name = "txtDataAluguer";
            txtDataAluguer.Size = new Size(233, 23);
            txtDataAluguer.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 165);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 6;
            label3.Text = "Data de Aluguer:";
            // 
            // txtDataPrevistaDev
            // 
            txtDataPrevistaDev.Location = new Point(38, 254);
            txtDataPrevistaDev.Name = "txtDataPrevistaDev";
            txtDataPrevistaDev.Size = new Size(233, 23);
            txtDataPrevistaDev.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 236);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 8;
            label4.Text = "Data Prevista Devolução:";
            // 
            // NewAluguerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 450);
            Controls.Add(txtDataPrevistaDev);
            Controls.Add(label4);
            Controls.Add(txtDataAluguer);
            Controls.Add(label3);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Controls.Add(button2Cancel);
            Controls.Add(button1OK);
            Name = "NewAluguerForm";
            Text = "Criar Novo Aluguer";
            Load += NewAluguerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1OK;
        private Button button2Cancel;
        private Label label1;
        private TextBox txtNome;
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtDataAluguer;
        private Label label3;
        private TextBox txtDataPrevistaDev;
        private Label label4;
    }
}
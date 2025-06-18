namespace Sistema_de_Gestão_de_Videoclube
{
    partial class EditFilmeForm
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
            label1 = new Label();
            txtTitulo = new TextBox();
            txtGenero = new TextBox();
            label2 = new Label();
            txtReal = new TextBox();
            label3 = new Label();
            txtDura = new TextBox();
            label4 = new Label();
            txtAno = new TextBox();
            label5 = new Label();
            EditarBTN = new Button();
            cancelEditar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 45);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Título:";
            label1.Click += label1_Click;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(44, 63);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(289, 23);
            txtTitulo.TabIndex = 1;
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(44, 122);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(289, 23);
            txtGenero.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 104);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Género:";
            // 
            // txtReal
            // 
            txtReal.Location = new Point(44, 179);
            txtReal.Name = "txtReal";
            txtReal.Size = new Size(289, 23);
            txtReal.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 161);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Realizador:";
            // 
            // txtDura
            // 
            txtDura.Location = new Point(44, 237);
            txtDura.Name = "txtDura";
            txtDura.Size = new Size(289, 23);
            txtDura.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 219);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 6;
            label4.Text = "Duração:";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(44, 302);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(289, 23);
            txtAno.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 284);
            label5.Name = "label5";
            label5.Size = new Size(117, 15);
            label5.TabIndex = 8;
            label5.Text = "Ano de Lançamento:";
            // 
            // EditarBTN
            // 
            EditarBTN.Location = new Point(44, 368);
            EditarBTN.Name = "EditarBTN";
            EditarBTN.Size = new Size(75, 23);
            EditarBTN.TabIndex = 10;
            EditarBTN.Text = "Editar";
            EditarBTN.UseVisualStyleBackColor = true;
            EditarBTN.Click += EditarBTN_Click;
            // 
            // cancelEditar
            // 
            cancelEditar.Location = new Point(125, 368);
            cancelEditar.Name = "cancelEditar";
            cancelEditar.Size = new Size(75, 23);
            cancelEditar.TabIndex = 11;
            cancelEditar.Text = "Cancelar";
            cancelEditar.UseVisualStyleBackColor = true;
            cancelEditar.Click += cancelEditar_Click;
            // 
            // EditFilmeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 450);
            Controls.Add(cancelEditar);
            Controls.Add(EditarBTN);
            Controls.Add(txtAno);
            Controls.Add(label5);
            Controls.Add(txtDura);
            Controls.Add(label4);
            Controls.Add(txtReal);
            Controls.Add(label3);
            Controls.Add(txtGenero);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(label1);
            Name = "EditFilmeForm";
            Text = "Editar Filme";
            Load += EditFilmeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitulo;
        private TextBox txtGenero;
        private Label label2;
        private TextBox txtReal;
        private Label label3;
        private TextBox txtDura;
        private Label label4;
        private TextBox txtAno;
        private Label label5;
        private Button EditarBTN;
        private Button cancelEditar;
    }
}
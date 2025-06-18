namespace Sistema_de_Gestão_de_Videoclube
{
    partial class EditAluguerForm
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
            button1 = new Button();
            button2 = new Button();
            txtCliente = new TextBox();
            txtFilme = new TextBox();
            label2 = new Label();
            txtDataA = new TextBox();
            label3 = new Label();
            txtDataPrevDev = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 29);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(85, 400);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Editar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(175, 400);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(40, 56);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(277, 23);
            txtCliente.TabIndex = 3;
            // 
            // txtFilme
            // 
            txtFilme.Location = new Point(40, 118);
            txtFilme.Name = "txtFilme";
            txtFilme.Size = new Size(277, 23);
            txtFilme.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 100);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Filme:";
            // 
            // txtDataA
            // 
            txtDataA.Location = new Point(40, 182);
            txtDataA.Name = "txtDataA";
            txtDataA.Size = new Size(277, 23);
            txtDataA.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 164);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 6;
            label3.Text = "Data de Aluguer:";
            // 
            // txtDataPrevDev
            // 
            txtDataPrevDev.Location = new Point(40, 245);
            txtDataPrevDev.Name = "txtDataPrevDev";
            txtDataPrevDev.Size = new Size(277, 23);
            txtDataPrevDev.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 227);
            label4.Name = "label4";
            label4.Size = new Size(153, 15);
            label4.TabIndex = 8;
            label4.Text = "Data Prevista de Devolução:";
            // 
            // EditAluguerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(txtDataPrevDev);
            Controls.Add(label4);
            Controls.Add(txtDataA);
            Controls.Add(label3);
            Controls.Add(txtFilme);
            Controls.Add(label2);
            Controls.Add(txtCliente);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "EditAluguerForm";
            Text = "Editar Aluguer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox txtCliente;
        private TextBox txtFilme;
        private Label label2;
        private TextBox txtDataA;
        private Label label3;
        private TextBox txtDataPrevDev;
        private Label label4;
    }
}
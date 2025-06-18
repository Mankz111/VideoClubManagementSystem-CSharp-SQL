namespace Sistema_de_Gestão_de_Videoclube
{
    partial class EditarCliente
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            editTEXT = new TextBox();
            editNIF = new TextBox();
            editTEL = new TextBox();
            editMAIL = new TextBox();
            editClienteOK = new Button();
            editClienteCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 51);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 116);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "NIF:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 159);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 245);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 185);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "Telefone:";
            // 
            // editTEXT
            // 
            editTEXT.Location = new Point(44, 69);
            editTEXT.Name = "editTEXT";
            editTEXT.Size = new Size(384, 23);
            editTEXT.TabIndex = 5;
            // 
            // editNIF
            // 
            editNIF.Location = new Point(44, 134);
            editNIF.Name = "editNIF";
            editNIF.Size = new Size(384, 23);
            editNIF.TabIndex = 6;
            // 
            // editTEL
            // 
            editTEL.Location = new Point(44, 203);
            editTEL.Name = "editTEL";
            editTEL.Size = new Size(384, 23);
            editTEL.TabIndex = 7;
            // 
            // editMAIL
            // 
            editMAIL.Location = new Point(44, 263);
            editMAIL.Name = "editMAIL";
            editMAIL.Size = new Size(384, 23);
            editMAIL.TabIndex = 8;
            // 
            // editClienteOK
            // 
            editClienteOK.Location = new Point(91, 331);
            editClienteOK.Name = "editClienteOK";
            editClienteOK.Size = new Size(114, 23);
            editClienteOK.TabIndex = 9;
            editClienteOK.Text = "OK";
            editClienteOK.UseVisualStyleBackColor = true;
            editClienteOK.Click += editClienteOK_Click;
            // 
            // editClienteCancel
            // 
            editClienteCancel.Location = new Point(280, 331);
            editClienteCancel.Name = "editClienteCancel";
            editClienteCancel.Size = new Size(114, 23);
            editClienteCancel.TabIndex = 10;
            editClienteCancel.Text = "Cancelar";
            editClienteCancel.UseVisualStyleBackColor = true;
            editClienteCancel.Click += editClienteCancel_Click;
            // 
            // EditarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 450);
            Controls.Add(editClienteCancel);
            Controls.Add(editClienteOK);
            Controls.Add(editMAIL);
            Controls.Add(editTEL);
            Controls.Add(editNIF);
            Controls.Add(editTEXT);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditarCliente";
            Text = "Editar Clientes";
            Load += EditarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox editTEXT;
        private TextBox editNIF;
        private TextBox editTEL;
        private TextBox editMAIL;
        private Button editClienteOK;
        private Button editClienteCancel;
    }
}
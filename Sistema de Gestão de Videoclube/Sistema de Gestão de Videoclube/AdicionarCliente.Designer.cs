namespace Sistema_de_Gestão_de_Videoclube
{
    partial class AdicionarCliente
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
            textBoxNOME = new TextBox();
            textBoxNIF = new TextBox();
            textBoxTEL = new TextBox();
            textBoxMAIL = new TextBox();
            addClienteOKbtn = new Button();
            addClienteCancelBTN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 123);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 223);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 1;
            label2.Text = "NIF:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 345);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 2;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 450);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            
            // 
            // textBoxNOME
            // 
            textBoxNOME.Location = new Point(77, 153);
            textBoxNOME.Margin = new Padding(4, 5, 4, 5);
            textBoxNOME.Name = "textBoxNOME";
            textBoxNOME.Size = new Size(390, 31);
            textBoxNOME.TabIndex = 4;
            // 
            // textBoxNIF
            // 
            textBoxNIF.Location = new Point(77, 268);
            textBoxNIF.Margin = new Padding(4, 5, 4, 5);
            textBoxNIF.Name = "textBoxNIF";
            textBoxNIF.Size = new Size(390, 31);
            textBoxNIF.TabIndex = 5;
            // 
            // textBoxTEL
            // 
            textBoxTEL.Location = new Point(77, 375);
            textBoxTEL.Margin = new Padding(4, 5, 4, 5);
            textBoxTEL.Name = "textBoxTEL";
            textBoxTEL.Size = new Size(390, 31);
            textBoxTEL.TabIndex = 6;
            // 
            // textBoxMAIL
            // 
            textBoxMAIL.Location = new Point(83, 480);
            textBoxMAIL.Margin = new Padding(4, 5, 4, 5);
            textBoxMAIL.Name = "textBoxMAIL";
            textBoxMAIL.Size = new Size(390, 31);
            textBoxMAIL.TabIndex = 7;
            // 
            // addClienteOKbtn
            // 
            addClienteOKbtn.Location = new Point(154, 622);
            addClienteOKbtn.Margin = new Padding(4, 5, 4, 5);
            addClienteOKbtn.Name = "addClienteOKbtn";
            addClienteOKbtn.Size = new Size(107, 38);
            addClienteOKbtn.TabIndex = 8;
            addClienteOKbtn.Text = "OK";
            addClienteOKbtn.UseVisualStyleBackColor = true;
            addClienteOKbtn.Click += addClienteOKbtn_Click;
            // 
            // addClienteCancelBTN
            // 
            addClienteCancelBTN.Location = new Point(270, 622);
            addClienteCancelBTN.Margin = new Padding(4, 5, 4, 5);
            addClienteCancelBTN.Name = "addClienteCancelBTN";
            addClienteCancelBTN.Size = new Size(107, 38);
            addClienteCancelBTN.TabIndex = 9;
            addClienteCancelBTN.Text = "Cancel";
            addClienteCancelBTN.UseVisualStyleBackColor = true;
            addClienteCancelBTN.Click += addClienteCancelBTN_Click;
            // 
            // AdicionarCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 900);
            Controls.Add(addClienteCancelBTN);
            Controls.Add(addClienteOKbtn);
            Controls.Add(textBoxMAIL);
            Controls.Add(textBoxTEL);
            Controls.Add(textBoxNIF);
            Controls.Add(textBoxNOME);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdicionarCliente";
            Text = "AdicionarCliente";
            Load += AdicionarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxNOME;
        private TextBox textBoxNIF;
        private TextBox textBoxTEL;
        private TextBox textBoxMAIL;
        private Button addClienteOKbtn;
        private Button addClienteCancelBTN;
    }
}
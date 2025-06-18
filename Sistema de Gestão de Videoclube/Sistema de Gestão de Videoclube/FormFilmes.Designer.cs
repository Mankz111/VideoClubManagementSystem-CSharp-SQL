
namespace Sistema_de_Gestão_de_Videoclube
{
    partial class FormFilmes
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
            dataGridViewFilmes = new DataGridView();
            addfilmeBTN = new Button();
            editfilmeBTN = new Button();
            apagarfilmeBTN = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilmes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFilmes
            // 
            dataGridViewFilmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFilmes.Location = new Point(59, 82);
            dataGridViewFilmes.Name = "dataGridViewFilmes";
            dataGridViewFilmes.RowHeadersWidth = 62;
            dataGridViewFilmes.Size = new Size(667, 257);
            dataGridViewFilmes.TabIndex = 4;
            dataGridViewFilmes.CellContentClick += dataGridViewFilmes_CellContentClick;
            // 
            // addfilmeBTN
            // 
            addfilmeBTN.Location = new Point(59, 367);
            addfilmeBTN.Name = "addfilmeBTN";
            addfilmeBTN.Size = new Size(102, 23);
            addfilmeBTN.TabIndex = 5;
            addfilmeBTN.Text = "Adicionar Filme";
            addfilmeBTN.UseVisualStyleBackColor = true;
            addfilmeBTN.Click += addfilmeBTN_Click;
            // 
            // editfilmeBTN
            // 
            editfilmeBTN.Location = new Point(167, 367);
            editfilmeBTN.Name = "editfilmeBTN";
            editfilmeBTN.Size = new Size(102, 23);
            editfilmeBTN.TabIndex = 6;
            editfilmeBTN.Text = "Editar Filme";
            editfilmeBTN.UseVisualStyleBackColor = true;
            editfilmeBTN.Click += editfilmeBTN_Click_1;
            // 
            // apagarfilmeBTN
            // 
            apagarfilmeBTN.Location = new Point(275, 367);
            apagarfilmeBTN.Name = "apagarfilmeBTN";
            apagarfilmeBTN.Size = new Size(102, 23);
            apagarfilmeBTN.TabIndex = 7;
            apagarfilmeBTN.Text = "Apagar Filme";
            apagarfilmeBTN.UseVisualStyleBackColor = true;
            apagarfilmeBTN.Click += apagarfilmeBTN_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 51);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 8;
            label1.Text = "Filmes:";
            // 
            // FormFilmes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(apagarfilmeBTN);
            Controls.Add(editfilmeBTN);
            Controls.Add(addfilmeBTN);
            Controls.Add(dataGridViewFilmes);
            Name = "FormFilmes";
            Text = "Gestão de Filmes";
            Load += FormFilmes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilmes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void FormFilmes_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private DataGridView dataGridViewFilmes;
        private Button addfilmeBTN;
        private Button editfilmeBTN;
        private Button apagarfilmeBTN;
        private Label label1;
        private EventHandler editfilmeBTN_Click;
    }
}
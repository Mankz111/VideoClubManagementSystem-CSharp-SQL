namespace Sistema_de_Gestão_de_Videoclube
{
    partial class FormHistoricoAlugueres
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridViewHistorico = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistorico).BeginInit();
            SuspendLayout();

            dataGridViewHistorico.AllowUserToAddRows = false;
            dataGridViewHistorico.AllowUserToDeleteRows = false;
            dataGridViewHistorico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistorico.Location = new Point(105, 93);
            dataGridViewHistorico.Name = "dataGridViewHistorico";
            dataGridViewHistorico.ReadOnly = true;
            dataGridViewHistorico.RowHeadersWidth = 51;
            dataGridViewHistorico.RowTemplate.Height = 24;
            dataGridViewHistorico.Size = new Size(588, 290);
            dataGridViewHistorico.TabIndex = 0;
            dataGridViewHistorico.CellContentClick += dataGridViewHistorico_CellContentClick;

            textBox1.Location = new Point(164, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged; // Evento TextChanged associado ao textBox1_TextChanged

            label1.AutoSize = true;
            label1.Location = new Point(118, 47);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Filtrar:";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 418);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewHistorico);
            Name = "FormHistoricoAlugueres";
            Text = "Histórico de Alugueres";
            Load += FormHistoricoAlugueres_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistorico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistorico;
        private TextBox textBox1;
        private Label label1;
    }
}
﻿namespace Sistema_de_Gestão_de_Videoclube
{
    partial class FormHistoricoAluguerCliente
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
            dgvHistoricoAluguer = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAluguer).BeginInit();
            SuspendLayout();
            // 
            // dgvHistoricoAluguer
            // 
            dgvHistoricoAluguer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoricoAluguer.Location = new Point(41, 82);
            dgvHistoricoAluguer.Name = "dgvHistoricoAluguer";
            dgvHistoricoAluguer.Size = new Size(558, 313);
            dgvHistoricoAluguer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 49);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 1;
            label1.Text = "Histórico Clientes: ";
            // 
            // FormHistoricoAluguerCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 469);
            Controls.Add(label1);
            Controls.Add(dgvHistoricoAluguer);
            Name = "FormHistoricoAluguerCliente";
            Text = "Histórico Cliente";
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAluguer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHistoricoAluguer;
        private Label label1;
    }
}
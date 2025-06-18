namespace Sistema_de_Gestão_de_Videoclube
{
    partial class RelatoriosForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatoriosForm));
            btnFilmesPorData = new Button();
            btnAtraso = new Button();
            btnFilmesNuncaAlugados = new Button();
            btnTopFilmes = new Button();
            btnAlugueresPorCliente = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            panelFilmesNuncaAlugados = new Panel();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            panelFilmesPorData = new Panel();
            dataGridView3 = new DataGridView();
            groupBox2 = new GroupBox();
            label7 = new Label();
            btnPesquisar = new Button();
            dtpDataInicial = new DateTimePicker();
            dtpDataFinal = new DateTimePicker();
            label8 = new Label();
            label6 = new Label();
            panelTopFilmes = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panelClientesAtraso = new Panel();
            dataGridView4 = new DataGridView();
            btnContactarColumn = new DataGridViewButtonColumn();
            groupBox4 = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            label19 = new Label();
            label18 = new Label();
            groupBox3 = new GroupBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panelAlugueresPorCliente = new Panel();
            dataGridView5 = new DataGridView();
            button2 = new Button();
            textBox2 = new TextBox();
            label21 = new Label();
            label20 = new Label();
            lblTotal = new Label();
            lblpercentagem = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelFilmesNuncaAlugados.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panelFilmesPorData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            groupBox2.SuspendLayout();
            panelTopFilmes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelClientesAtraso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            panelAlugueresPorCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            SuspendLayout();
            // 
            // btnFilmesPorData
            // 
            btnFilmesPorData.BackColor = SystemColors.Highlight;
            btnFilmesPorData.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilmesPorData.Location = new Point(503, 6);
            btnFilmesPorData.Margin = new Padding(2);
            btnFilmesPorData.Name = "btnFilmesPorData";
            btnFilmesPorData.Size = new Size(132, 28);
            btnFilmesPorData.TabIndex = 2;
            btnFilmesPorData.Text = "Filmes por Data";
            btnFilmesPorData.UseVisualStyleBackColor = false;
            btnFilmesPorData.Click += btnFilmesPorData_Click;
            // 
            // btnAtraso
            // 
            btnAtraso.BackColor = SystemColors.Highlight;
            btnAtraso.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtraso.Location = new Point(639, 6);
            btnAtraso.Margin = new Padding(2);
            btnAtraso.Name = "btnAtraso";
            btnAtraso.Size = new Size(214, 28);
            btnAtraso.TabIndex = 6;
            btnAtraso.Text = "Clientes com aluguer em atraso";
            btnAtraso.UseVisualStyleBackColor = false;
            btnAtraso.Click += btnAtraso_Click;
            // 
            // btnFilmesNuncaAlugados
            // 
            btnFilmesNuncaAlugados.BackColor = SystemColors.Highlight;
            btnFilmesNuncaAlugados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilmesNuncaAlugados.Location = new Point(188, 6);
            btnFilmesNuncaAlugados.Margin = new Padding(2);
            btnFilmesNuncaAlugados.Name = "btnFilmesNuncaAlugados";
            btnFilmesNuncaAlugados.Size = new Size(159, 28);
            btnFilmesNuncaAlugados.TabIndex = 5;
            btnFilmesNuncaAlugados.Text = "Filmes nunca Alugados";
            btnFilmesNuncaAlugados.UseVisualStyleBackColor = false;
            btnFilmesNuncaAlugados.Click += btnFilmesNuncaAlugados_Click;
            // 
            // btnTopFilmes
            // 
            btnTopFilmes.BackColor = SystemColors.MenuHighlight;
            btnTopFilmes.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTopFilmes.ForeColor = SystemColors.HighlightText;
            btnTopFilmes.Location = new Point(49, 6);
            btnTopFilmes.Margin = new Padding(2);
            btnTopFilmes.Name = "btnTopFilmes";
            btnTopFilmes.Size = new Size(135, 28);
            btnTopFilmes.TabIndex = 3;
            btnTopFilmes.Text = "Top Filmes";
            btnTopFilmes.UseVisualStyleBackColor = false;
            btnTopFilmes.Click += btnTopFilmes_Click;
            // 
            // btnAlugueresPorCliente
            // 
            btnAlugueresPorCliente.BackColor = SystemColors.Highlight;
            btnAlugueresPorCliente.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlugueresPorCliente.Location = new Point(351, 6);
            btnAlugueresPorCliente.Margin = new Padding(2);
            btnAlugueresPorCliente.Name = "btnAlugueresPorCliente";
            btnAlugueresPorCliente.Size = new Size(148, 28);
            btnAlugueresPorCliente.TabIndex = 4;
            btnAlugueresPorCliente.Text = "Alugueres por Cliente";
            btnAlugueresPorCliente.UseVisualStyleBackColor = false;
            btnAlugueresPorCliente.Click += btnAlugueresPorCliente_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-7, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(943, 59);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(49, 13);
            label2.Name = "label2";
            label2.Size = new Size(225, 30);
            label2.TabIndex = 0;
            label2.Text = "Relatórios Estatisticos";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DodgerBlue;
            panel2.Controls.Add(btnTopFilmes);
            panel2.Controls.Add(btnAtraso);
            panel2.Controls.Add(btnFilmesNuncaAlugados);
            panel2.Controls.Add(btnFilmesPorData);
            panel2.Controls.Add(btnAlugueresPorCliente);
            panel2.ForeColor = SystemColors.ButtonFace;
            panel2.Location = new Point(-7, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(943, 51);
            panel2.TabIndex = 9;
            // 
            // panelFilmesNuncaAlugados
            // 
            panelFilmesNuncaAlugados.Controls.Add(groupBox1);
            panelFilmesNuncaAlugados.Controls.Add(dataGridView2);
            panelFilmesNuncaAlugados.Controls.Add(label3);
            panelFilmesNuncaAlugados.Location = new Point(0, 103);
            panelFilmesNuncaAlugados.Name = "panelFilmesNuncaAlugados";
            panelFilmesNuncaAlugados.Size = new Size(936, 422);
            panelFilmesNuncaAlugados.TabIndex = 3;
            panelFilmesNuncaAlugados.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblpercentagem);
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(124, 310);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resumo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 53);
            label5.Name = "label5";
            label5.Size = new Size(88, 17);
            label5.TabIndex = 1;
            label5.Text = "Representam:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 28);
            label4.Name = "label4";
            label4.Size = new Size(202, 17);
            label4.TabIndex = 0;
            label4.Text = "Total de Filmes Nunca Alugados: ";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(124, 48);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(676, 238);
            dataGridView2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(118, 5);
            label3.Name = "label3";
            label3.Size = new Size(244, 30);
            label3.TabIndex = 0;
            label3.Text = "Filmes Nunca Alugados";
            // 
            // panelFilmesPorData
            // 
            panelFilmesPorData.Controls.Add(dataGridView3);
            panelFilmesPorData.Controls.Add(groupBox2);
            panelFilmesPorData.Controls.Add(label6);
            panelFilmesPorData.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelFilmesPorData.Location = new Point(0, 103);
            panelFilmesPorData.Name = "panelFilmesPorData";
            panelFilmesPorData.Size = new Size(936, 422);
            panelFilmesPorData.TabIndex = 3;
            panelFilmesPorData.Visible = false;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(42, 154);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(849, 237);
            dataGridView3.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ControlLight;
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnPesquisar);
            groupBox2.Controls.Add(dtpDataInicial);
            groupBox2.Controls.Add(dtpDataFinal);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(42, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(849, 76);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(11, 37);
            label7.Name = "label7";
            label7.Size = new Size(89, 21);
            label7.TabIndex = 2;
            label7.Text = "Data Inicial:";
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.OliveDrab;
            btnPesquisar.ForeColor = SystemColors.ButtonHighlight;
            btnPesquisar.Location = new Point(689, 30);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(104, 32);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Location = new Point(109, 34);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(200, 27);
            dtpDataInicial.TabIndex = 0;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Location = new Point(444, 33);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(200, 27);
            dtpDataFinal.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(356, 34);
            label8.Name = "label8";
            label8.Size = new Size(82, 21);
            label8.TabIndex = 3;
            label8.Text = "Data Final:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(42, 25);
            label6.Name = "label6";
            label6.Size = new Size(399, 30);
            label6.TabIndex = 1;
            label6.Text = "Filmes Alugados por Intervalo de Datas";
            // 
            // panelTopFilmes
            // 
            panelTopFilmes.Controls.Add(chart1);
            panelTopFilmes.Controls.Add(label1);
            panelTopFilmes.Controls.Add(dataGridView1);
            panelTopFilmes.Dock = DockStyle.Bottom;
            panelTopFilmes.Location = new Point(0, 103);
            panelTopFilmes.Name = "panelTopFilmes";
            panelTopFilmes.Size = new Size(935, 422);
            panelTopFilmes.TabIndex = 10;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(42, 78);
            chart1.Name = "chart1";
            chart1.Size = new Size(411, 300);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 15);
            label1.Name = "label1";
            label1.Size = new Size(286, 30);
            label1.TabIndex = 1;
            label1.Text = "Top 5 Filmes Mais Alugados";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(496, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(395, 149);
            dataGridView1.TabIndex = 0;
            // 
            // panelClientesAtraso
            // 
            panelClientesAtraso.Controls.Add(dataGridView4);
            panelClientesAtraso.Controls.Add(groupBox4);
            panelClientesAtraso.Controls.Add(label18);
            panelClientesAtraso.Controls.Add(groupBox3);
            panelClientesAtraso.Location = new Point(0, 103);
            panelClientesAtraso.Name = "panelClientesAtraso";
            panelClientesAtraso.Size = new Size(936, 422);
            panelClientesAtraso.TabIndex = 8;
            panelClientesAtraso.Visible = false;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Columns.AddRange(new DataGridViewColumn[] { btnContactarColumn });
            dataGridView4.Location = new Point(42, 216);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(849, 188);
            dataGridView4.TabIndex = 3;
            dataGridView4.CellContentClick += dataGridView4_CellContentClick;
            dataGridView4.CellFormatting += dataGridView4_CellFormatting;
            // 
            // btnContactarColumn
            // 
            btnContactarColumn.HeaderText = "Ação";
            btnContactarColumn.Name = "btnContactarColumn";
            btnContactarColumn.Text = "Contactar";
            btnContactarColumn.UseColumnTextForButtonValue = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(label19);
            groupBox4.Location = new Point(42, 140);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(849, 57);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGreen;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(250, 19);
            button1.Name = "button1";
            button1.Size = new Size(114, 29);
            button1.TabIndex = 2;
            button1.Text = "Pesquisar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 20);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nome ou NIF...";
            textBox1.Size = new Size(163, 23);
            textBox1.TabIndex = 1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 23);
            label19.Name = "label19";
            label19.Size = new Size(40, 15);
            label19.TabIndex = 0;
            label19.Text = "Filtrar:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(42, 13);
            label18.Name = "label18";
            label18.Size = new Size(349, 30);
            label18.TabIndex = 1;
            label18.Text = "Clientes com Alugueres em Atraso";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(42, 47);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(849, 87);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(676, 37);
            label17.Name = "label17";
            label17.Size = new Size(91, 15);
            label17.TabIndex = 8;
            label17.Text = "Atraso > 30 dias";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(480, 37);
            label16.Name = "label16";
            label16.Size = new Size(97, 15);
            label16.TabIndex = 7;
            label16.Text = "Atraso 16-30 dias";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(304, 37);
            label15.Name = "label15";
            label15.Size = new Size(91, 15);
            label15.TabIndex = 6;
            label15.Text = "Atraso 6-15 dias";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(132, 37);
            label14.Name = "label14";
            label14.Size = new Size(85, 15);
            label14.TabIndex = 5;
            label14.Text = "Atraso 1-5 dias";
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(192, 0, 0);
            label13.Location = new Point(650, 37);
            label13.Name = "label13";
            label13.Size = new Size(20, 20);
            label13.TabIndex = 4;
            // 
            // label12
            // 
            label12.BackColor = Color.Red;
            label12.Location = new Point(454, 37);
            label12.Name = "label12";
            label12.Size = new Size(20, 20);
            label12.TabIndex = 3;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(255, 128, 128);
            label11.Location = new Point(278, 37);
            label11.Name = "label11";
            label11.Size = new Size(20, 20);
            label11.TabIndex = 2;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(255, 192, 192);
            label10.Location = new Point(106, 37);
            label10.Name = "label10";
            label10.Size = new Size(20, 20);
            label10.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 37);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 0;
            label9.Text = "Legenda:";
            // 
            // panelAlugueresPorCliente
            // 
            panelAlugueresPorCliente.Controls.Add(dataGridView5);
            panelAlugueresPorCliente.Controls.Add(button2);
            panelAlugueresPorCliente.Controls.Add(textBox2);
            panelAlugueresPorCliente.Controls.Add(label21);
            panelAlugueresPorCliente.Controls.Add(label20);
            panelAlugueresPorCliente.Location = new Point(0, 103);
            panelAlugueresPorCliente.Name = "panelAlugueresPorCliente";
            panelAlugueresPorCliente.Size = new Size(936, 422);
            panelAlugueresPorCliente.TabIndex = 9;
            panelAlugueresPorCliente.Visible = false;
            // 
            // dataGridView5
            // 
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(42, 119);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.Size = new Size(832, 281);
            dataGridView5.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGreen;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(247, 79);
            button2.Name = "button2";
            button2.Size = new Size(112, 26);
            button2.TabIndex = 3;
            button2.Text = "Pesquisar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(92, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(149, 23);
            textBox2.TabIndex = 2;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.Location = new Point(42, 84);
            label21.Name = "label21";
            label21.Size = new Size(44, 17);
            label21.TabIndex = 1;
            label21.Text = "Filtrar:";
            label21.Click += label21_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(292, 25);
            label20.Name = "label20";
            label20.Size = new Size(311, 25);
            label20.TabIndex = 0;
            label20.Text = "Número de Alugueres por Cliente";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(214, 30);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(47, 15);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "label22";
            // 
            // lblpercentagem
            // 
            lblpercentagem.AutoSize = true;
            lblpercentagem.Location = new Point(96, 55);
            lblpercentagem.Name = "lblpercentagem";
            lblpercentagem.Size = new Size(47, 15);
            lblpercentagem.TabIndex = 3;
            lblpercentagem.Text = "label23";
            // 
            // RelatoriosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 525);
            Controls.Add(panelFilmesNuncaAlugados);
            Controls.Add(panelAlugueresPorCliente);
            Controls.Add(panelClientesAtraso);
            Controls.Add(panelFilmesPorData);
            Controls.Add(panelTopFilmes);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "RelatoriosForm";
            Text = "Relatórios";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panelFilmesNuncaAlugados.ResumeLayout(false);
            panelFilmesNuncaAlugados.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panelFilmesPorData.ResumeLayout(false);
            panelFilmesPorData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panelTopFilmes.ResumeLayout(false);
            panelTopFilmes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelClientesAtraso.ResumeLayout(false);
            panelClientesAtraso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panelAlugueresPorCliente.ResumeLayout(false);
            panelAlugueresPorCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnFilmesPorData;
        private Button btnFilmesNuncaAlugados;
        private Button btnAlugueresPorCliente;
        private Button btnTopFilmes;
        private Button btnAtraso;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Panel panelTopFilmes;
        private Label label1;
        private DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Panel panelFilmesNuncaAlugados;
        private GroupBox groupBox1;
        private DataGridView dataGridView2;
        private Label label3;
        private Label label5;
        private Label label4;
        private Panel panelFilmesPorData;
        private Button btnPesquisar;
        private DateTimePicker dtpDataFinal;
        private Label label8;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpDataInicial;
        private GroupBox groupBox2;
        private DataGridView dataGridView3;
        private Panel panelClientesAtraso;
        private GroupBox groupBox3;
        private Label label9;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private GroupBox groupBox4;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private DataGridView dataGridView4;
        private Button button1;
        private TextBox textBox1;
        private DataGridViewButtonColumn btnContactarColumn;
        private Panel panelAlugueresPorCliente;
        private Label label20;
        private DataGridView dataGridView5;
        private Button button2;
        private TextBox textBox2;
        private Label label21;
        private Label lblpercentagem;
        private Label lblTotal;
    }
}
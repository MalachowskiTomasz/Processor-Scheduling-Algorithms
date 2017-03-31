namespace ProcessorScheduling
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.algoComboBox = new MetroFramework.Controls.MetroComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.timeSliceText = new MetroFramework.Controls.MetroTextBox();
            this.speedText = new MetroFramework.Controls.MetroTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.processTable = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timeText = new System.Windows.Forms.TextBox();
            this.processInCPU = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.loadButton = new MetroFramework.Controls.MetroButton();
            this.btnStop = new MetroFramework.Controls.MetroButton();
            this.btnPlay = new MetroFramework.Controls.MetroButton();
            this.btnNext = new MetroFramework.Controls.MetroButton();
            this.btnPause = new MetroFramework.Controls.MetroButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.readyQueueText = new MetroFramework.Controls.MetroTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.timeSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.panel103 = new System.Windows.Forms.Panel();
            this.btnBanner = new MetroFramework.Controls.MetroButton();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTopic = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processTable)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel103.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(55, 425);
            this.panel1.MaximumSize = new System.Drawing.Size(556, 561);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 295);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(443, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Waiting Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(306, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Remaining Time";
            // 
            // algoComboBox
            // 
            this.algoComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.algoComboBox.FormattingEnabled = true;
            this.algoComboBox.ItemHeight = 23;
            this.algoComboBox.Items.AddRange(new object[] {
            "Select a scheduling method",
            "First Come First Serve (FCFS)",
            "Shortest Process Next (SPN)",
            "Shortest Remaining Time (SRT)",
            "Highest Response Ratio Next (HRRN)",
            "Round Robin"});
            this.algoComboBox.Location = new System.Drawing.Point(14, 31);
            this.algoComboBox.Name = "algoComboBox";
            this.algoComboBox.Size = new System.Drawing.Size(269, 29);
            this.algoComboBox.TabIndex = 4;
            this.algoComboBox.UseSelectable = true;
            this.algoComboBox.SelectedIndexChanged += new System.EventHandler(this.algoComboBox_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.timeSliceText);
            this.panel4.Controls.Add(this.speedText);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.algoComboBox);
            this.panel4.Location = new System.Drawing.Point(55, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(556, 77);
            this.panel4.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(13, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(166, 17);
            this.label22.TabIndex = 9;
            this.label22.Text = "Select Scheduling Method :";
            // 
            // timeSliceText
            // 
            this.timeSliceText.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.timeSliceText.Lines = new string[] {
        "1"};
            this.timeSliceText.Location = new System.Drawing.Point(492, 42);
            this.timeSliceText.MaxLength = 32767;
            this.timeSliceText.Name = "timeSliceText";
            this.timeSliceText.PasswordChar = '\0';
            this.timeSliceText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.timeSliceText.SelectedText = "";
            this.timeSliceText.Size = new System.Drawing.Size(41, 19);
            this.timeSliceText.TabIndex = 8;
            this.timeSliceText.Text = "1";
            this.timeSliceText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeSliceText.UseSelectable = true;
            // 
            // speedText
            // 
            this.speedText.BackColor = System.Drawing.SystemColors.Window;
            this.speedText.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.speedText.Lines = new string[] {
        "100"};
            this.speedText.Location = new System.Drawing.Point(492, 17);
            this.speedText.MaxLength = 32767;
            this.speedText.Name = "speedText";
            this.speedText.PasswordChar = '\0';
            this.speedText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.speedText.SelectedText = "";
            this.speedText.Size = new System.Drawing.Size(41, 19);
            this.speedText.TabIndex = 7;
            this.speedText.Text = "100";
            this.speedText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speedText.UseSelectable = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(306, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 17);
            this.label21.TabIndex = 6;
            this.label21.Text = "Quantum Time :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(306, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(154, 17);
            this.label20.TabIndex = 5;
            this.label20.Text = "Simulation Timer Inerval :";
            // 
            // processTable
            // 
            this.processTable.AllowUserToResizeRows = false;
            this.processTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.processTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.processTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.processTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.processTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.processTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.processTable.EnableHeadersVisualStyles = false;
            this.processTable.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.processTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.processTable.Location = new System.Drawing.Point(16, 13);
            this.processTable.MultiSelect = false;
            this.processTable.Name = "processTable";
            this.processTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.processTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.processTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.processTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.processTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processTable.Size = new System.Drawing.Size(343, 197);
            this.processTable.Style = MetroFramework.MetroColorStyle.Red;
            this.processTable.TabIndex = 4;
            this.processTable.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.processTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.processTable_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Job";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Arrival Time";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Service Time";
            this.Column3.Name = "Column3";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.processTable);
            this.panel3.Location = new System.Drawing.Point(56, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 227);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.timeText);
            this.panel2.Controls.Add(this.processInCPU);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Location = new System.Drawing.Point(445, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 75);
            this.panel2.TabIndex = 10;
            // 
            // timeText
            // 
            this.timeText.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeText.Location = new System.Drawing.Point(81, 39);
            this.timeText.Name = "timeText";
            this.timeText.ReadOnly = true;
            this.timeText.Size = new System.Drawing.Size(48, 22);
            this.timeText.TabIndex = 3;
            this.timeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // processInCPU
            // 
            this.processInCPU.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processInCPU.Location = new System.Drawing.Point(81, 10);
            this.processInCPU.Name = "processInCPU";
            this.processInCPU.ReadOnly = true;
            this.processInCPU.Size = new System.Drawing.Size(48, 22);
            this.processInCPU.TabIndex = 2;
            this.processInCPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(15, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 17);
            this.label19.TabIndex = 1;
            this.label19.Text = "Time";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(14, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "CPU";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.loadButton);
            this.panel5.Controls.Add(this.btnStop);
            this.panel5.Controls.Add(this.btnPlay);
            this.panel5.Controls.Add(this.btnNext);
            this.panel5.Controls.Add(this.btnPause);
            this.panel5.Location = new System.Drawing.Point(445, 227);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 192);
            this.panel5.TabIndex = 13;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.BackgroundImage = global::ProcessorScheduling.Properties.Resources.load;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadButton.Location = new System.Drawing.Point(17, 15);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(53, 51);
            this.loadButton.TabIndex = 23;
            this.loadButton.UseSelectable = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = global::ProcessorScheduling.Properties.Resources.stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(90, 129);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(53, 51);
            this.btnStop.TabIndex = 13;
            this.btnStop.UseSelectable = true;
            this.btnStop.Click += new System.EventHandler(this.metroButton4_Click_1);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = global::ProcessorScheduling.Properties.Resources.play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(17, 72);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(53, 51);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.UseSelectable = true;
            this.btnPlay.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = global::ProcessorScheduling.Properties.Resources.step_forward;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(17, 130);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(53, 51);
            this.btnNext.TabIndex = 12;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.metroButton3_Click_1);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Transparent;
            this.btnPause.BackgroundImage = global::ProcessorScheduling.Properties.Resources.pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(90, 72);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(53, 51);
            this.btnPause.TabIndex = 11;
            this.btnPause.UseSelectable = true;
            this.btnPause.Click += new System.EventHandler(this.metroButton2_Click_1);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.readyQueueText);
            this.panel7.Controls.Add(this.label23);
            this.panel7.Location = new System.Drawing.Point(55, 379);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(383, 40);
            this.panel7.TabIndex = 15;
            // 
            // readyQueueText
            // 
            this.readyQueueText.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.readyQueueText.Lines = new string[0];
            this.readyQueueText.Location = new System.Drawing.Point(107, 12);
            this.readyQueueText.MaxLength = 32767;
            this.readyQueueText.Name = "readyQueueText";
            this.readyQueueText.PasswordChar = '\0';
            this.readyQueueText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.readyQueueText.SelectedText = "";
            this.readyQueueText.Size = new System.Drawing.Size(252, 19);
            this.readyQueueText.TabIndex = 1;
            this.readyQueueText.UseSelectable = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(8, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 17);
            this.label23.TabIndex = 0;
            this.label23.Text = "Ready Queue :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(767, 230);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 21);
            this.label30.TabIndex = 20;
            this.label30.Text = "Timer";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeSpinner
            // 
            this.timeSpinner.Location = new System.Drawing.Point(660, 127);
            this.timeSpinner.Maximum = 100000;
            this.timeSpinner.Name = "timeSpinner";
            this.timeSpinner.Size = new System.Drawing.Size(260, 253);
            this.timeSpinner.Style = MetroFramework.MetroColorStyle.Red;
            this.timeSpinner.TabIndex = 18;
            this.timeSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.timeSpinner.UseSelectable = true;
            this.timeSpinner.Value = 100;
            // 
            // panel103
            // 
            this.panel103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel103.Controls.Add(this.btnBanner);
            this.panel103.Controls.Add(this.lblType);
            this.panel103.Controls.Add(this.lblDescription);
            this.panel103.Controls.Add(this.lblTopic);
            this.panel103.Location = new System.Drawing.Point(980, 127);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(335, 229);
            this.panel103.TabIndex = 21;
            // 
            // btnBanner
            // 
            this.btnBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBanner.BackgroundImage")));
            this.btnBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBanner.Enabled = false;
            this.btnBanner.Location = new System.Drawing.Point(0, 0);
            this.btnBanner.Name = "btnBanner";
            this.btnBanner.Size = new System.Drawing.Size(335, 229);
            this.btnBanner.TabIndex = 3;
            this.btnBanner.UseSelectable = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(16, 187);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 21);
            this.lblType.TabIndex = 2;
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(16, 54);
            this.lblDescription.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 21);
            this.lblDescription.TabIndex = 1;
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.ForeColor = System.Drawing.Color.White;
            this.lblTopic.Location = new System.Drawing.Point(15, 19);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(0, 25);
            this.lblTopic.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(620, 425);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.BorderColor = System.Drawing.Color.MediumBlue;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(695, 295);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPlay;
            this.ClientSize = new System.Drawing.Size(1378, 770);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel103);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.timeSpinner);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "PROCESS SCHEDULING";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel103.ResumeLayout(false);
            this.panel103.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox algoComboBox;
        private MetroFramework.Controls.MetroButton btnPlay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroGrid processTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox timeText;
        private System.Windows.Forms.TextBox processInCPU;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private MetroFramework.Controls.MetroButton btnPause;
        private MetroFramework.Controls.MetroButton btnNext;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label22;
        private MetroFramework.Controls.MetroTextBox timeSliceText;
        private MetroFramework.Controls.MetroTextBox speedText;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private MetroFramework.Controls.MetroButton btnStop;
        private System.Windows.Forms.Panel panel7;
        private MetroFramework.Controls.MetroTextBox readyQueueText;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label30;
        private MetroFramework.Controls.MetroProgressSpinner timeSpinner;
        private System.Windows.Forms.Panel panel103;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblType;
        private MetroFramework.Controls.MetroButton btnBanner;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private MetroFramework.Controls.MetroButton loadButton;
    }
}


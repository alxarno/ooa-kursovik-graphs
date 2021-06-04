namespace Graphs
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabs = new System.Windows.Forms.TabControl();
            this.GraphDataPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkAbsenceValueGroup = new System.Windows.Forms.GroupBox();
            this.linkAbscenseValueTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.graphPointsCountComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.simpleGraphRadioButton = new System.Windows.Forms.RadioButton();
            this.weightedGraphRadioButton = new System.Windows.Forms.RadioButton();
            this.directedGraphRadioButton = new System.Windows.Forms.RadioButton();
            this.MatrixGroup = new System.Windows.Forms.GroupBox();
            this.Pathes = new System.Windows.Forms.TabPage();
            this.ShortesPath = new System.Windows.Forms.TabPage();
            this.Cycles = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cyclesButton = new System.Windows.Forms.Button();
            this.cyclesResultsTextBox = new System.Windows.Forms.TextBox();
            this.cyclesLogsTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pathesExecButton = new System.Windows.Forms.Button();
            this.pathesLogs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pathesSourceList = new System.Windows.Forms.ComboBox();
            this.shortPathSource = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.shortPathExec = new System.Windows.Forms.Button();
            this.shortPathLogs = new System.Windows.Forms.TextBox();
            this.shortPathDestination = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Tabs.SuspendLayout();
            this.GraphDataPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.linkAbsenceValueGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Pathes.SuspendLayout();
            this.ShortesPath.SuspendLayout();
            this.Cycles.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.GraphDataPage);
            this.Tabs.Controls.Add(this.Pathes);
            this.Tabs.Controls.Add(this.ShortesPath);
            this.Tabs.Controls.Add(this.Cycles);
            this.Tabs.Location = new System.Drawing.Point(12, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(776, 436);
            this.Tabs.TabIndex = 0;
            // 
            // GraphDataPage
            // 
            this.GraphDataPage.Controls.Add(this.groupBox1);
            this.GraphDataPage.Controls.Add(this.MatrixGroup);
            this.GraphDataPage.Location = new System.Drawing.Point(4, 22);
            this.GraphDataPage.Name = "GraphDataPage";
            this.GraphDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.GraphDataPage.Size = new System.Drawing.Size(768, 410);
            this.GraphDataPage.TabIndex = 0;
            this.GraphDataPage.Text = "Данные о Графе";
            this.GraphDataPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkAbsenceValueGroup);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(552, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 398);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки Графа";
            // 
            // linkAbsenceValueGroup
            // 
            this.linkAbsenceValueGroup.Controls.Add(this.linkAbscenseValueTextBox);
            this.linkAbsenceValueGroup.Location = new System.Drawing.Point(6, 348);
            this.linkAbsenceValueGroup.Name = "linkAbsenceValueGroup";
            this.linkAbsenceValueGroup.Size = new System.Drawing.Size(200, 44);
            this.linkAbsenceValueGroup.TabIndex = 6;
            this.linkAbsenceValueGroup.TabStop = false;
            this.linkAbsenceValueGroup.Text = "Значение отсутствия связи";
            this.linkAbsenceValueGroup.Visible = false;
            // 
            // linkAbscenseValueTextBox
            // 
            this.linkAbscenseValueTextBox.Location = new System.Drawing.Point(9, 17);
            this.linkAbscenseValueTextBox.Name = "linkAbscenseValueTextBox";
            this.linkAbscenseValueTextBox.Size = new System.Drawing.Size(176, 20);
            this.linkAbscenseValueTextBox.TabIndex = 0;
            this.linkAbscenseValueTextBox.Text = "-9999";
            this.linkAbscenseValueTextBox.TextChanged += new System.EventHandler(this.linkAbscenseValueTextBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 150);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Справка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "⮨ - Связь между вершинами\r\nтолько из верхней вершины";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "⮭ - Связь между вершинами\r\nтолько из правой вершины";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "🗘 - Связь между вершинами\r\nдвусторонняя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x - Связи нет между вершинами";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.graphPointsCountComboBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество вершин";
            // 
            // graphPointsCountComboBox
            // 
            this.graphPointsCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphPointsCountComboBox.FormatString = "N0";
            this.graphPointsCountComboBox.FormattingEnabled = true;
            this.graphPointsCountComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.graphPointsCountComboBox.Location = new System.Drawing.Point(7, 20);
            this.graphPointsCountComboBox.Name = "graphPointsCountComboBox";
            this.graphPointsCountComboBox.Size = new System.Drawing.Size(187, 21);
            this.graphPointsCountComboBox.TabIndex = 1;
            this.graphPointsCountComboBox.SelectedIndexChanged += new System.EventHandler(this.graphPointsCountComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.simpleGraphRadioButton);
            this.groupBox2.Controls.Add(this.weightedGraphRadioButton);
            this.groupBox2.Controls.Add(this.directedGraphRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип Графа";
            // 
            // simpleGraphRadioButton
            // 
            this.simpleGraphRadioButton.AutoSize = true;
            this.simpleGraphRadioButton.Checked = true;
            this.simpleGraphRadioButton.Location = new System.Drawing.Point(6, 19);
            this.simpleGraphRadioButton.Name = "simpleGraphRadioButton";
            this.simpleGraphRadioButton.Size = new System.Drawing.Size(96, 17);
            this.simpleGraphRadioButton.TabIndex = 0;
            this.simpleGraphRadioButton.TabStop = true;
            this.simpleGraphRadioButton.Text = "Простой граф";
            this.simpleGraphRadioButton.UseVisualStyleBackColor = true;
            this.simpleGraphRadioButton.Click += new System.EventHandler(this.OnChangedGraphType);
            // 
            // weightedGraphRadioButton
            // 
            this.weightedGraphRadioButton.AutoSize = true;
            this.weightedGraphRadioButton.Location = new System.Drawing.Point(6, 65);
            this.weightedGraphRadioButton.Name = "weightedGraphRadioButton";
            this.weightedGraphRadioButton.Size = new System.Drawing.Size(118, 17);
            this.weightedGraphRadioButton.TabIndex = 2;
            this.weightedGraphRadioButton.TabStop = true;
            this.weightedGraphRadioButton.Text = "Взвешенный граф";
            this.weightedGraphRadioButton.UseVisualStyleBackColor = true;
            this.weightedGraphRadioButton.Click += new System.EventHandler(this.OnChangedGraphType);
            // 
            // directedGraphRadioButton
            // 
            this.directedGraphRadioButton.AutoSize = true;
            this.directedGraphRadioButton.Location = new System.Drawing.Point(6, 42);
            this.directedGraphRadioButton.Name = "directedGraphRadioButton";
            this.directedGraphRadioButton.Size = new System.Drawing.Size(129, 17);
            this.directedGraphRadioButton.TabIndex = 1;
            this.directedGraphRadioButton.TabStop = true;
            this.directedGraphRadioButton.Text = "Направленный граф";
            this.directedGraphRadioButton.UseVisualStyleBackColor = true;
            this.directedGraphRadioButton.Click += new System.EventHandler(this.OnChangedGraphType);
            // 
            // MatrixGroup
            // 
            this.MatrixGroup.Location = new System.Drawing.Point(6, 6);
            this.MatrixGroup.Name = "MatrixGroup";
            this.MatrixGroup.Size = new System.Drawing.Size(540, 398);
            this.MatrixGroup.TabIndex = 0;
            this.MatrixGroup.TabStop = false;
            this.MatrixGroup.Text = "Матрица смежности";
            // 
            // Pathes
            // 
            this.Pathes.Controls.Add(this.pathesSourceList);
            this.Pathes.Controls.Add(this.label9);
            this.Pathes.Controls.Add(this.label8);
            this.Pathes.Controls.Add(this.pathesExecButton);
            this.Pathes.Controls.Add(this.pathesLogs);
            this.Pathes.Location = new System.Drawing.Point(4, 22);
            this.Pathes.Name = "Pathes";
            this.Pathes.Size = new System.Drawing.Size(768, 410);
            this.Pathes.TabIndex = 2;
            this.Pathes.Text = "Пути";
            this.Pathes.UseVisualStyleBackColor = true;
            this.Pathes.Enter += new System.EventHandler(this.Tabs_VisibleChanged);
            // 
            // ShortesPath
            // 
            this.ShortesPath.Controls.Add(this.shortPathDestination);
            this.ShortesPath.Controls.Add(this.label11);
            this.ShortesPath.Controls.Add(this.shortPathSource);
            this.ShortesPath.Controls.Add(this.label7);
            this.ShortesPath.Controls.Add(this.label10);
            this.ShortesPath.Controls.Add(this.shortPathExec);
            this.ShortesPath.Controls.Add(this.shortPathLogs);
            this.ShortesPath.Location = new System.Drawing.Point(4, 22);
            this.ShortesPath.Name = "ShortesPath";
            this.ShortesPath.Padding = new System.Windows.Forms.Padding(3);
            this.ShortesPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShortesPath.Size = new System.Drawing.Size(768, 410);
            this.ShortesPath.TabIndex = 1;
            this.ShortesPath.Text = "Кратчайший путь";
            this.ShortesPath.UseVisualStyleBackColor = true;
            this.ShortesPath.Enter += new System.EventHandler(this.ShortesPath_Enter);
            // 
            // Cycles
            // 
            this.Cycles.Controls.Add(this.label6);
            this.Cycles.Controls.Add(this.label5);
            this.Cycles.Controls.Add(this.cyclesButton);
            this.Cycles.Controls.Add(this.cyclesResultsTextBox);
            this.Cycles.Controls.Add(this.cyclesLogsTextBox);
            this.Cycles.Location = new System.Drawing.Point(4, 22);
            this.Cycles.Name = "Cycles";
            this.Cycles.Size = new System.Drawing.Size(768, 410);
            this.Cycles.TabIndex = 3;
            this.Cycles.Text = "Циклы";
            this.Cycles.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Результат";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Логи";
            // 
            // cyclesButton
            // 
            this.cyclesButton.Location = new System.Drawing.Point(621, 384);
            this.cyclesButton.Name = "cyclesButton";
            this.cyclesButton.Size = new System.Drawing.Size(144, 23);
            this.cyclesButton.TabIndex = 6;
            this.cyclesButton.Text = "Выполнить";
            this.cyclesButton.UseVisualStyleBackColor = true;
            this.cyclesButton.Click += new System.EventHandler(this.cycles_Click);
            // 
            // cyclesResultsTextBox
            // 
            this.cyclesResultsTextBox.Enabled = false;
            this.cyclesResultsTextBox.Location = new System.Drawing.Point(3, 386);
            this.cyclesResultsTextBox.Name = "cyclesResultsTextBox";
            this.cyclesResultsTextBox.Size = new System.Drawing.Size(612, 20);
            this.cyclesResultsTextBox.TabIndex = 5;
            // 
            // cyclesLogsTextBox
            // 
            this.cyclesLogsTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cyclesLogsTextBox.Enabled = false;
            this.cyclesLogsTextBox.Location = new System.Drawing.Point(3, 20);
            this.cyclesLogsTextBox.Multiline = true;
            this.cyclesLogsTextBox.Name = "cyclesLogsTextBox";
            this.cyclesLogsTextBox.Size = new System.Drawing.Size(762, 344);
            this.cyclesLogsTextBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Логи";
            // 
            // pathesExecButton
            // 
            this.pathesExecButton.Location = new System.Drawing.Point(618, 381);
            this.pathesExecButton.Name = "pathesExecButton";
            this.pathesExecButton.Size = new System.Drawing.Size(144, 23);
            this.pathesExecButton.TabIndex = 11;
            this.pathesExecButton.Text = "Выполнить";
            this.pathesExecButton.UseVisualStyleBackColor = true;
            this.pathesExecButton.Click += new System.EventHandler(this.pathesExecButton_Click);
            // 
            // pathesLogs
            // 
            this.pathesLogs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pathesLogs.Enabled = false;
            this.pathesLogs.Location = new System.Drawing.Point(3, 20);
            this.pathesLogs.Multiline = true;
            this.pathesLogs.Name = "pathesLogs";
            this.pathesLogs.Size = new System.Drawing.Size(762, 344);
            this.pathesLogs.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Исходная вершина";
            // 
            // pathesSourceList
            // 
            this.pathesSourceList.FormattingEnabled = true;
            this.pathesSourceList.Location = new System.Drawing.Point(3, 383);
            this.pathesSourceList.Name = "pathesSourceList";
            this.pathesSourceList.Size = new System.Drawing.Size(121, 21);
            this.pathesSourceList.TabIndex = 15;
            // 
            // shortPathSource
            // 
            this.shortPathSource.FormattingEnabled = true;
            this.shortPathSource.Location = new System.Drawing.Point(3, 384);
            this.shortPathSource.Name = "shortPathSource";
            this.shortPathSource.Size = new System.Drawing.Size(121, 21);
            this.shortPathSource.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Исходная вершина";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Логи";
            // 
            // shortPathExec
            // 
            this.shortPathExec.Location = new System.Drawing.Point(618, 382);
            this.shortPathExec.Name = "shortPathExec";
            this.shortPathExec.Size = new System.Drawing.Size(144, 23);
            this.shortPathExec.TabIndex = 17;
            this.shortPathExec.Text = "Выполнить";
            this.shortPathExec.UseVisualStyleBackColor = true;
            this.shortPathExec.Click += new System.EventHandler(this.shortPathExec_Click);
            // 
            // shortPathLogs
            // 
            this.shortPathLogs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.shortPathLogs.Enabled = false;
            this.shortPathLogs.Location = new System.Drawing.Point(3, 21);
            this.shortPathLogs.Multiline = true;
            this.shortPathLogs.Name = "shortPathLogs";
            this.shortPathLogs.Size = new System.Drawing.Size(762, 344);
            this.shortPathLogs.TabIndex = 16;
            // 
            // shortPathDestination
            // 
            this.shortPathDestination.FormattingEnabled = true;
            this.shortPathDestination.Location = new System.Drawing.Point(145, 384);
            this.shortPathDestination.Name = "shortPathDestination";
            this.shortPathDestination.Size = new System.Drawing.Size(121, 21);
            this.shortPathDestination.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Конечная вершина";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 453);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Алгоритмы на графах";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tabs.ResumeLayout(false);
            this.GraphDataPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.linkAbsenceValueGroup.ResumeLayout(false);
            this.linkAbsenceValueGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Pathes.ResumeLayout(false);
            this.Pathes.PerformLayout();
            this.ShortesPath.ResumeLayout(false);
            this.ShortesPath.PerformLayout();
            this.Cycles.ResumeLayout(false);
            this.Cycles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage GraphDataPage;
        private System.Windows.Forms.TabPage ShortesPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox MatrixGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton simpleGraphRadioButton;
        private System.Windows.Forms.RadioButton weightedGraphRadioButton;
        private System.Windows.Forms.RadioButton directedGraphRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox graphPointsCountComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox linkAbsenceValueGroup;
        private System.Windows.Forms.TextBox linkAbscenseValueTextBox;
        private System.Windows.Forms.TabPage Pathes;
        private System.Windows.Forms.TabPage Cycles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cyclesButton;
        private System.Windows.Forms.TextBox cyclesResultsTextBox;
        private System.Windows.Forms.TextBox cyclesLogsTextBox;
        private System.Windows.Forms.ComboBox pathesSourceList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button pathesExecButton;
        private System.Windows.Forms.TextBox pathesLogs;
        private System.Windows.Forms.ComboBox shortPathDestination;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox shortPathSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button shortPathExec;
        private System.Windows.Forms.TextBox shortPathLogs;
    }
}


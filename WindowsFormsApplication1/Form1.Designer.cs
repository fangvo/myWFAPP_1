namespace WindowsFormsApplication1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.buttonPredAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPreds = new System.Windows.Forms.DataGridView();
            this.buttonCientFilter = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPageGoods = new System.Windows.Forms.TabPage();
            this.buttonGoodsFilters = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.buttonAdd_Goods = new System.Windows.Forms.Button();
            this.tabPageSells = new System.Windows.Forms.TabPage();
            this.buttonOtchet = new System.Windows.Forms.Button();
            this.buttonSellsFilter = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonAdd_Sells = new System.Windows.Forms.Button();
            this.dataGridSells = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonImpAdd = new System.Windows.Forms.Button();
            this.dataGridImp = new System.Windows.Forms.DataGridView();
            this.tabPageOtchet = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewOtchetProiz = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickerMontOnly = new System.Windows.Forms.DateTimePicker();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArenda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonMakeDataGrid = new System.Windows.Forms.Button();
            this.dataGridViewOthetByTimeAndName = new System.Windows.Forms.DataGridView();
            this.comboBoxOtchetByName = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.tabHost.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPageGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.tabPageSells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSells)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImp)).BeginInit();
            this.tabPageOtchet.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtchetProiz)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOthetByTimeAndName)).BeginInit();
            this.SuspendLayout();
            // 
            // tabHost
            // 
            this.tabHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabHost.Controls.Add(this.tabPageClients);
            this.tabHost.Controls.Add(this.tabPageGoods);
            this.tabHost.Controls.Add(this.tabPageSells);
            this.tabHost.Controls.Add(this.tabPage3);
            this.tabHost.Controls.Add(this.tabPageOtchet);
            this.tabHost.Location = new System.Drawing.Point(3, 13);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(775, 542);
            this.tabHost.TabIndex = 0;
            this.tabHost.SelectedIndexChanged += new System.EventHandler(this.TabIndexChanced);
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.buttonPredAdd);
            this.tabPageClients.Controls.Add(this.label1);
            this.tabPageClients.Controls.Add(this.dataGridViewPreds);
            this.tabPageClients.Controls.Add(this.buttonCientFilter);
            this.tabPageClients.Controls.Add(this.comboBox2);
            this.tabPageClients.Controls.Add(this.dataGridViewClients);
            this.tabPageClients.Controls.Add(this.button8);
            this.tabPageClients.Controls.Add(this.button2);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(767, 516);
            this.tabPageClients.TabIndex = 0;
            this.tabPageClients.Text = "Клиенты";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // buttonPredAdd
            // 
            this.buttonPredAdd.Location = new System.Drawing.Point(686, 411);
            this.buttonPredAdd.Name = "buttonPredAdd";
            this.buttonPredAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonPredAdd.TabIndex = 15;
            this.buttonPredAdd.Text = "Добавить";
            this.buttonPredAdd.UseVisualStyleBackColor = true;
            this.buttonPredAdd.Click += new System.EventHandler(this.buttonPredAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Предстовители";
            // 
            // dataGridViewPreds
            // 
            this.dataGridViewPreds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPreds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPreds.Location = new System.Drawing.Point(3, 441);
            this.dataGridViewPreds.Name = "dataGridViewPreds";
            this.dataGridViewPreds.RowHeadersVisible = false;
            this.dataGridViewPreds.Size = new System.Drawing.Size(760, 69);
            this.dataGridViewPreds.TabIndex = 13;
            // 
            // buttonCientFilter
            // 
            this.buttonCientFilter.Location = new System.Drawing.Point(106, 8);
            this.buttonCientFilter.Name = "buttonCientFilter";
            this.buttonCientFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonCientFilter.TabIndex = 12;
            this.buttonCientFilter.Text = "Filters";
            this.buttonCientFilter.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Покупатель",
            "Постовщик"});
            this.comboBox2.Location = new System.Drawing.Point(593, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(3, 37);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.RowHeadersVisible = false;
            this.dataGridViewClients.Size = new System.Drawing.Size(760, 364);
            this.dataGridViewClients.TabIndex = 10;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(478, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Refresh";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabPageGoods
            // 
            this.tabPageGoods.Controls.Add(this.buttonGoodsFilters);
            this.tabPageGoods.Controls.Add(this.button3);
            this.tabPageGoods.Controls.Add(this.dataGridViewGoods);
            this.tabPageGoods.Controls.Add(this.buttonAdd_Goods);
            this.tabPageGoods.Location = new System.Drawing.Point(4, 22);
            this.tabPageGoods.Name = "tabPageGoods";
            this.tabPageGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGoods.Size = new System.Drawing.Size(767, 516);
            this.tabPageGoods.TabIndex = 1;
            this.tabPageGoods.Text = "Товары";
            this.tabPageGoods.UseVisualStyleBackColor = true;
            // 
            // buttonGoodsFilters
            // 
            this.buttonGoodsFilters.Location = new System.Drawing.Point(649, 7);
            this.buttonGoodsFilters.Name = "buttonGoodsFilters";
            this.buttonGoodsFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonGoodsFilters.TabIndex = 14;
            this.buttonGoodsFilters.Text = "Filters";
            this.buttonGoodsFilters.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(493, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Location = new System.Drawing.Point(3, 35);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.RowHeadersVisible = false;
            this.dataGridViewGoods.Size = new System.Drawing.Size(760, 475);
            this.dataGridViewGoods.TabIndex = 1;
            // 
            // buttonAdd_Goods
            // 
            this.buttonAdd_Goods.Location = new System.Drawing.Point(18, 6);
            this.buttonAdd_Goods.Name = "buttonAdd_Goods";
            this.buttonAdd_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd_Goods.TabIndex = 0;
            this.buttonAdd_Goods.Text = "Добавить";
            this.buttonAdd_Goods.UseVisualStyleBackColor = true;
            this.buttonAdd_Goods.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPageSells
            // 
            this.tabPageSells.Controls.Add(this.buttonOtchet);
            this.tabPageSells.Controls.Add(this.buttonSellsFilter);
            this.tabPageSells.Controls.Add(this.button4);
            this.tabPageSells.Controls.Add(this.buttonAdd_Sells);
            this.tabPageSells.Controls.Add(this.dataGridSells);
            this.tabPageSells.Controls.Add(this.comboBox3);
            this.tabPageSells.Controls.Add(this.comboBox1);
            this.tabPageSells.Location = new System.Drawing.Point(4, 22);
            this.tabPageSells.Name = "tabPageSells";
            this.tabPageSells.Size = new System.Drawing.Size(767, 516);
            this.tabPageSells.TabIndex = 2;
            this.tabPageSells.Text = "Сделки";
            this.tabPageSells.UseVisualStyleBackColor = true;
            // 
            // buttonOtchet
            // 
            this.buttonOtchet.Location = new System.Drawing.Point(688, 46);
            this.buttonOtchet.Name = "buttonOtchet";
            this.buttonOtchet.Size = new System.Drawing.Size(75, 23);
            this.buttonOtchet.TabIndex = 8;
            this.buttonOtchet.Text = "Отчеты";
            this.buttonOtchet.UseVisualStyleBackColor = true;
            // 
            // buttonSellsFilter
            // 
            this.buttonSellsFilter.Location = new System.Drawing.Point(134, 46);
            this.buttonSellsFilter.Name = "buttonSellsFilter";
            this.buttonSellsFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonSellsFilter.TabIndex = 7;
            this.buttonSellsFilter.Text = "Filters";
            this.buttonSellsFilter.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Посмотреть";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // buttonAdd_Sells
            // 
            this.buttonAdd_Sells.Location = new System.Drawing.Point(415, 10);
            this.buttonAdd_Sells.Name = "buttonAdd_Sells";
            this.buttonAdd_Sells.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd_Sells.TabIndex = 5;
            this.buttonAdd_Sells.Text = "Добавить";
            this.buttonAdd_Sells.UseVisualStyleBackColor = true;
            this.buttonAdd_Sells.Click += new System.EventHandler(this.buttonAdd_Sells_Click);
            // 
            // dataGridSells
            // 
            this.dataGridSells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSells.Location = new System.Drawing.Point(3, 75);
            this.dataGridSells.Name = "dataGridSells";
            this.dataGridSells.RowHeadersVisible = false;
            this.dataGridSells.Size = new System.Drawing.Size(760, 435);
            this.dataGridSells.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Покупка",
            "Продажа"});
            this.comboBox3.Location = new System.Drawing.Point(288, 12);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonImpAdd);
            this.tabPage3.Controls.Add(this.dataGridImp);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(767, 516);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Сотрудники";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonImpAdd
            // 
            this.buttonImpAdd.Location = new System.Drawing.Point(5, 3);
            this.buttonImpAdd.Name = "buttonImpAdd";
            this.buttonImpAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonImpAdd.TabIndex = 1;
            this.buttonImpAdd.Text = "Добавить";
            this.buttonImpAdd.UseVisualStyleBackColor = true;
            this.buttonImpAdd.Click += new System.EventHandler(this.buttonImpAdd_Click);
            // 
            // dataGridImp
            // 
            this.dataGridImp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridImp.Location = new System.Drawing.Point(3, 70);
            this.dataGridImp.Name = "dataGridImp";
            this.dataGridImp.Size = new System.Drawing.Size(760, 440);
            this.dataGridImp.TabIndex = 0;
            // 
            // tabPageOtchet
            // 
            this.tabPageOtchet.Controls.Add(this.tabControl2);
            this.tabPageOtchet.Location = new System.Drawing.Point(4, 22);
            this.tabPageOtchet.Name = "tabPageOtchet";
            this.tabPageOtchet.Size = new System.Drawing.Size(767, 516);
            this.tabPageOtchet.TabIndex = 4;
            this.tabPageOtchet.Tag = "TabOtchet";
            this.tabPageOtchet.Text = "Отчеты";
            this.tabPageOtchet.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(767, 516);
            this.tabControl2.TabIndex = 10;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.OtchetTab_Changed);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.textBoxArenda);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.dateTimePickerMontOnly);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.comboBoxOtchetByName);
            this.tabPage4.Controls.Add(this.dataGridViewOthetByTimeAndName);
            this.tabPage4.Controls.Add(this.buttonMakeDataGrid);
            this.tabPage4.Controls.Add(this.dateTimePicker2);
            this.tabPage4.Controls.Add(this.dateTimePicker1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(759, 490);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Tag = "Tab1";
            this.tabPage4.Text = "Отчет по дням";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridViewOtchetProiz);
            this.tabPage6.Controls.Add(this.button9);
            this.tabPage6.Controls.Add(this.button10);
            this.tabPage6.Controls.Add(this.dateTimePicker3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(759, 490);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Tag = "Tab2";
            this.tabPage6.Text = "Отчет по произаводителю";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOtchetProiz
            // 
            this.dataGridViewOtchetProiz.AllowUserToAddRows = false;
            this.dataGridViewOtchetProiz.AllowUserToDeleteRows = false;
            this.dataGridViewOtchetProiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOtchetProiz.Location = new System.Drawing.Point(6, 36);
            this.dataGridViewOtchetProiz.MultiSelect = false;
            this.dataGridViewOtchetProiz.Name = "dataGridViewOtchetProiz";
            this.dataGridViewOtchetProiz.ReadOnly = true;
            this.dataGridViewOtchetProiz.RowHeadersVisible = false;
            this.dataGridViewOtchetProiz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOtchetProiz.Size = new System.Drawing.Size(747, 447);
            this.dataGridViewOtchetProiz.StandardTab = true;
            this.dataGridViewOtchetProiz.TabIndex = 22;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(490, 10);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 20);
            this.button9.TabIndex = 21;
            this.button9.Text = "В Word";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(409, 10);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 20);
            this.button10.TabIndex = 20;
            this.button10.Text = "Обновить";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "MMMM";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(6, 8);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 19;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button11);
            this.tabPage7.Controls.Add(this.button6);
            this.tabPage7.Controls.Add(this.chart1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(759, 490);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Tag = "Tab3";
            this.tabPage7.Text = "Гистограма";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(227, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(204, 23);
            this.button11.TabIndex = 22;
            this.button11.Text = "Доход";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(204, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "По Производителям";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorTickMark.IntervalOffset = double.NaN;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.MajorGrid.Interval = 50000D;
            chartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.MinorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet;
            chartArea1.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Straight;
            chartArea1.AxisY.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 30);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(753, 457);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // dateTimePickerMontOnly
            // 
            this.dateTimePickerMontOnly.CustomFormat = "MMMM";
            this.dateTimePickerMontOnly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMontOnly.Location = new System.Drawing.Point(6, 371);
            this.dateTimePickerMontOnly.Name = "dateTimePickerMontOnly";
            this.dateTimePickerMontOnly.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerMontOnly.TabIndex = 21;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(421, 377);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 20);
            this.button7.TabIndex = 22;
            this.button7.Text = "Обновить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Аренда";
            // 
            // textBoxArenda
            // 
            this.textBoxArenda.Location = new System.Drawing.Point(265, 374);
            this.textBoxArenda.Name = "textBoxArenda";
            this.textBoxArenda.Size = new System.Drawing.Size(150, 20);
            this.textBoxArenda.TabIndex = 25;
            this.textBoxArenda.Text = "50000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Расходы за ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = " ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(225, 7);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // buttonMakeDataGrid
            // 
            this.buttonMakeDataGrid.Location = new System.Drawing.Point(449, 7);
            this.buttonMakeDataGrid.Name = "buttonMakeDataGrid";
            this.buttonMakeDataGrid.Size = new System.Drawing.Size(75, 20);
            this.buttonMakeDataGrid.TabIndex = 12;
            this.buttonMakeDataGrid.Text = "Обновить";
            this.buttonMakeDataGrid.UseVisualStyleBackColor = true;
            this.buttonMakeDataGrid.Click += new System.EventHandler(this.buttonMakeDataGrid_Click);
            // 
            // dataGridViewOthetByTimeAndName
            // 
            this.dataGridViewOthetByTimeAndName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOthetByTimeAndName.Location = new System.Drawing.Point(6, 63);
            this.dataGridViewOthetByTimeAndName.Name = "dataGridViewOthetByTimeAndName";
            this.dataGridViewOthetByTimeAndName.Size = new System.Drawing.Size(747, 302);
            this.dataGridViewOthetByTimeAndName.TabIndex = 13;
            // 
            // comboBoxOtchetByName
            // 
            this.comboBoxOtchetByName.FormattingEnabled = true;
            this.comboBoxOtchetByName.Location = new System.Drawing.Point(6, 36);
            this.comboBoxOtchetByName.Name = "comboBoxOtchetByName";
            this.comboBoxOtchetByName.Size = new System.Drawing.Size(150, 21);
            this.comboBoxOtchetByName.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(552, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 20);
            this.button5.TabIndex = 15;
            this.button5.Text = "В Word";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabHost);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::WindowsFormsApplication1.Properties.Settings.Default, "MainFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::WindowsFormsApplication1.Properties.Settings.Default.MainFormLocation;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.tabHost.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPageGoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.tabPageSells.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSells)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImp)).EndInit();
            this.tabPageOtchet.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtchetProiz)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOthetByTimeAndName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabHost;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPageGoods;
        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.Button buttonAdd_Goods;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPageSells;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button buttonAdd_Sells;
        private System.Windows.Forms.DataGridView dataGridSells;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonCientFilter;
        private System.Windows.Forms.Button buttonGoodsFilters;
        private System.Windows.Forms.Button buttonSellsFilter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonImpAdd;
        private System.Windows.Forms.DataGridView dataGridImp;
        private System.Windows.Forms.Button buttonOtchet;
        private System.Windows.Forms.DataGridView dataGridViewPreds;
        private System.Windows.Forms.Button buttonPredAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageOtchet;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridViewOtchetProiz;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxArenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker dateTimePickerMontOnly;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBoxOtchetByName;
        private System.Windows.Forms.DataGridView dataGridViewOthetByTimeAndName;
        private System.Windows.Forms.Button buttonMakeDataGrid;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}


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
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
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
            this.buttonSellsFilter = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonAdd_Sells = new System.Windows.Forms.Button();
            this.dataGridSells = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabHost.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPageGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.tabPageSells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSells)).BeginInit();
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
            this.tabHost.Location = new System.Drawing.Point(3, 13);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(775, 542);
            this.tabHost.TabIndex = 0;
            this.tabHost.SelectedIndexChanged += new System.EventHandler(this.TabIndexChanced);
            // 
            // tabPageClients
            // 
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
            // buttonCientFilter
            // 
            this.buttonCientFilter.Location = new System.Drawing.Point(25, 42);
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
            this.dataGridViewClients.Location = new System.Drawing.Point(3, 71);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(758, 439);
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
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
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
            this.dataGridViewGoods.Location = new System.Drawing.Point(3, 36);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.Size = new System.Drawing.Size(758, 474);
            this.dataGridViewGoods.TabIndex = 1;
            this.dataGridViewGoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGoods_CellContentClick);
            // 
            // buttonAdd_Goods
            // 
            this.buttonAdd_Goods.Location = new System.Drawing.Point(18, 6);
            this.buttonAdd_Goods.Name = "buttonAdd_Goods";
            this.buttonAdd_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd_Goods.TabIndex = 0;
            this.buttonAdd_Goods.Text = "button4";
            this.buttonAdd_Goods.UseVisualStyleBackColor = true;
            this.buttonAdd_Goods.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPageSells
            // 
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
            // buttonSellsFilter
            // 
            this.buttonSellsFilter.Location = new System.Drawing.Point(133, 53);
            this.buttonSellsFilter.Name = "buttonSellsFilter";
            this.buttonSellsFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonSellsFilter.TabIndex = 7;
            this.buttonSellsFilter.Text = "Filters";
            this.buttonSellsFilter.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
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
            this.dataGridSells.Location = new System.Drawing.Point(3, 82);
            this.dataGridSells.Name = "dataGridSells";
            this.dataGridSells.Size = new System.Drawing.Size(758, 431);
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(767, 516);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Сотрудники";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabHost);
            this.Name = "Form1";
            this.tabHost.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPageGoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.tabPageSells.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSells)).EndInit();
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
    }
}


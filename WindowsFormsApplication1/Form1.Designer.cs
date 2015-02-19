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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button_Client_new = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonDel_Goods = new System.Windows.Forms.Button();
            this.buttonNew_Goods = new System.Windows.Forms.Button();
            this.buttonSave_Goods = new System.Windows.Forms.Button();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.buttonAdd_Goods = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(13, 13);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1326, 440);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewClients);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button_Client_new);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1318, 414);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(1306, 374);
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
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(369, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "delete";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button_Client_new
            // 
            this.button_Client_new.Location = new System.Drawing.Point(288, 6);
            this.button_Client_new.Name = "button_Client_new";
            this.button_Client_new.Size = new System.Drawing.Size(75, 23);
            this.button_Client_new.TabIndex = 7;
            this.button_Client_new.Text = "new";
            this.button_Client_new.UseVisualStyleBackColor = true;
            this.button_Client_new.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(207, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.buttonDel_Goods);
            this.tabPage4.Controls.Add(this.buttonNew_Goods);
            this.tabPage4.Controls.Add(this.buttonSave_Goods);
            this.tabPage4.Controls.Add(this.dataGridViewGoods);
            this.tabPage4.Controls.Add(this.buttonAdd_Goods);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1318, 414);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // buttonDel_Goods
            // 
            this.buttonDel_Goods.Location = new System.Drawing.Point(384, 7);
            this.buttonDel_Goods.Name = "buttonDel_Goods";
            this.buttonDel_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonDel_Goods.TabIndex = 12;
            this.buttonDel_Goods.Text = "delete";
            this.buttonDel_Goods.UseVisualStyleBackColor = true;
            this.buttonDel_Goods.Click += new System.EventHandler(this.buttonDel_Goods_Click);
            // 
            // buttonNew_Goods
            // 
            this.buttonNew_Goods.Location = new System.Drawing.Point(303, 7);
            this.buttonNew_Goods.Name = "buttonNew_Goods";
            this.buttonNew_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonNew_Goods.TabIndex = 11;
            this.buttonNew_Goods.Text = "new";
            this.buttonNew_Goods.UseVisualStyleBackColor = true;
            this.buttonNew_Goods.Click += new System.EventHandler(this.buttonNew_Goods_Click);
            // 
            // buttonSave_Goods
            // 
            this.buttonSave_Goods.Location = new System.Drawing.Point(222, 6);
            this.buttonSave_Goods.Name = "buttonSave_Goods";
            this.buttonSave_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonSave_Goods.TabIndex = 10;
            this.buttonSave_Goods.Text = "save";
            this.buttonSave_Goods.UseVisualStyleBackColor = true;
            this.buttonSave_Goods.Click += new System.EventHandler(this.buttonSave_Goods_Click);
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.Size = new System.Drawing.Size(853, 262);
            this.dataGridViewGoods.TabIndex = 1;
            // 
            // buttonAdd_Goods
            // 
            this.buttonAdd_Goods.Location = new System.Drawing.Point(6, 6);
            this.buttonAdd_Goods.Name = "buttonAdd_Goods";
            this.buttonAdd_Goods.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd_Goods.TabIndex = 0;
            this.buttonAdd_Goods.Text = "button4";
            this.buttonAdd_Goods.UseVisualStyleBackColor = true;
            this.buttonAdd_Goods.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1344, 455);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form1";
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
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
        private System.Windows.Forms.BindingSource myDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private System.Windows.Forms.BindingSource clientsBindingSource1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn uIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn клиентDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn иННDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кППDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn банкDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn рСDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кСDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn бИКDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.Button buttonAdd_Goods;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button_Client_new;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonDel_Goods;
        private System.Windows.Forms.Button buttonNew_Goods;
        private System.Windows.Forms.Button buttonSave_Goods;
    }
}


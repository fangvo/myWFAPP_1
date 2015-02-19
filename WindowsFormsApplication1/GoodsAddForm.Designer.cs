namespace WindowsFormsApplication1
{
    partial class GoodsAddForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxED = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTArticyl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStrihCod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKolvo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(692, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "ед";
            // 
            // textBoxED
            // 
            this.textBoxED.Location = new System.Drawing.Point(496, 66);
            this.textBoxED.Name = "textBoxED";
            this.textBoxED.Size = new System.Drawing.Size(356, 20);
            this.textBoxED.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Артикул";
            // 
            // textBoxTArticyl
            // 
            this.textBoxTArticyl.Location = new System.Drawing.Point(497, 14);
            this.textBoxTArticyl.Name = "textBoxTArticyl";
            this.textBoxTArticyl.Size = new System.Drawing.Size(356, 20);
            this.textBoxTArticyl.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Штрих код";
            // 
            // textBoxStrihCod
            // 
            this.textBoxStrihCod.Location = new System.Drawing.Point(496, 40);
            this.textBoxStrihCod.Name = "textBoxStrihCod";
            this.textBoxStrihCod.Size = new System.Drawing.Size(356, 20);
            this.textBoxStrihCod.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Колво";
            // 
            // textBoxKolvo
            // 
            this.textBoxKolvo.Location = new System.Drawing.Point(60, 66);
            this.textBoxKolvo.Name = "textBoxKolvo";
            this.textBoxKolvo.Size = new System.Drawing.Size(356, 20);
            this.textBoxKolvo.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Цена";
            // 
            // textBoxCena
            // 
            this.textBoxCena.Location = new System.Drawing.Point(60, 40);
            this.textBoxCena.Multiline = true;
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(356, 20);
            this.textBoxCena.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Название";
            // 
            // textBoxTName
            // 
            this.textBoxTName.Location = new System.Drawing.Point(74, 14);
            this.textBoxTName.Name = "textBoxTName";
            this.textBoxTName.Size = new System.Drawing.Size(342, 20);
            this.textBoxTName.TabIndex = 38;
            // 
            // TovarsAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 118);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxED);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTArticyl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStrihCod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxKolvo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTName);
            this.Name = "TovarsAddForm";
            this.Text = "TovarsAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxED;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTArticyl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStrihCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKolvo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTName;
    }
}
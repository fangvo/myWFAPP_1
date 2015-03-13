namespace WindowsFormsApplication1
{
    partial class Filters
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
            this.buttonRem = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAplay = new System.Windows.Forms.Button();
            this.buttonSbros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRem
            // 
            this.buttonRem.Location = new System.Drawing.Point(531, 10);
            this.buttonRem.Name = "buttonRem";
            this.buttonRem.Size = new System.Drawing.Size(65, 23);
            this.buttonRem.TabIndex = 100;
            this.buttonRem.Tag = "rem";
            this.buttonRem.Text = "Remove";
            this.buttonRem.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(460, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(65, 23);
            this.buttonAdd.TabIndex = 99;
            this.buttonAdd.Tag = "add";
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(512, 247);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 101;
            this.buttonBack.Tag = "back";
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonAplay
            // 
            this.buttonAplay.Location = new System.Drawing.Point(460, 68);
            this.buttonAplay.Name = "buttonAplay";
            this.buttonAplay.Size = new System.Drawing.Size(75, 23);
            this.buttonAplay.TabIndex = 102;
            this.buttonAplay.Tag = "aplay";
            this.buttonAplay.Text = "Пременить";
            this.buttonAplay.UseVisualStyleBackColor = true;
            // 
            // buttonSbros
            // 
            this.buttonSbros.Location = new System.Drawing.Point(460, 39);
            this.buttonSbros.Name = "buttonSbros";
            this.buttonSbros.Size = new System.Drawing.Size(75, 23);
            this.buttonSbros.TabIndex = 103;
            this.buttonSbros.Tag = "sbros";
            this.buttonSbros.Text = "Сброс";
            this.buttonSbros.UseVisualStyleBackColor = true;
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 282);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSbros);
            this.Controls.Add(this.buttonAplay);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonRem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Filters";
            this.Text = "Filters";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRem;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAplay;
        private System.Windows.Forms.Button buttonSbros;


    }
}
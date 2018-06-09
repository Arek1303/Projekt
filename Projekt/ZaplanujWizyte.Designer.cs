namespace Projekt
{
    partial class ZaplanujWizyte
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
            this.label1 = new System.Windows.Forms.Label();
            this.DataPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CzasPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(263, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zaproponuj wizytę";
            // 
            // DataPicker
            // 
            this.DataPicker.CustomFormat = "yyyy-MM-dd";
            this.DataPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DataPicker.Location = new System.Drawing.Point(29, 125);
            this.DataPicker.Name = "DataPicker";
            this.DataPicker.Size = new System.Drawing.Size(291, 20);
            this.DataPicker.TabIndex = 1;
     
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(56, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(544, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wyślij lekarzowi zapytanie o wizytę, obserwuj jej status w panelu zatwierdzonych " +
    "wizyt";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(267, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Zaproponuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(29, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "<<<";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // CzasPicker
            // 
            this.CzasPicker.CustomFormat = "HH:mm";
            this.CzasPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CzasPicker.Location = new System.Drawing.Point(348, 125);
            this.CzasPicker.Name = "CzasPicker";
            this.CzasPicker.Size = new System.Drawing.Size(200, 20);
            this.CzasPicker.TabIndex = 5;
            // 
            // ZaplanujWizyte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 318);
            this.Controls.Add(this.CzasPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataPicker);
            this.Controls.Add(this.label1);
            this.Name = "ZaplanujWizyte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZaplanujWizyte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.label3_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DataPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker CzasPicker;
    }
}
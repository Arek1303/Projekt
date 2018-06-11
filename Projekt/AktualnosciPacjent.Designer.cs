namespace Projekt
{
    partial class PatientNews
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
            this.FirstDate = new System.Windows.Forms.Label();
            this.SecondTitle = new System.Windows.Forms.Label();
            this.ThirdTitle = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Label();
            this.FirstTitle = new System.Windows.Forms.Label();
            this.FirstDescription = new System.Windows.Forms.RichTextBox();
            this.SecondDate = new System.Windows.Forms.Label();
            this.SecondDescription = new System.Windows.Forms.RichTextBox();
            this.ThirdDate = new System.Windows.Forms.Label();
            this.ThirdDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(241, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktualności";
            // 
            // FirstDate
            // 
            this.FirstDate.AutoSize = true;
            this.FirstDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FirstDate.Location = new System.Drawing.Point(58, 59);
            this.FirstDate.Name = "FirstDate";
            this.FirstDate.Size = new System.Drawing.Size(46, 17);
            this.FirstDate.TabIndex = 1;
            this.FirstDate.Text = "Data1";
            // 
            // SecondTitle
            // 
            this.SecondTitle.AutoSize = true;
            this.SecondTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.SecondTitle.Location = new System.Drawing.Point(171, 188);
            this.SecondTitle.Name = "SecondTitle";
            this.SecondTitle.Size = new System.Drawing.Size(46, 17);
            this.SecondTitle.TabIndex = 3;
            this.SecondTitle.Text = "Data2";
            // 
            // ThirdTitle
            // 
            this.ThirdTitle.AutoSize = true;
            this.ThirdTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ThirdTitle.Location = new System.Drawing.Point(168, 318);
            this.ThirdTitle.Name = "ThirdTitle";
            this.ThirdTitle.Size = new System.Drawing.Size(46, 17);
            this.ThirdTitle.TabIndex = 5;
            this.ThirdTitle.Text = "Data3";
            // 
            // BtnBack
            // 
            this.BtnBack.AutoSize = true;
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnBack.Location = new System.Drawing.Point(26, 18);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(39, 20);
            this.BtnBack.TabIndex = 9;
            this.BtnBack.Text = "<<<";
            this.BtnBack.Click += new System.EventHandler(this.Label5_Click);
            // 
            // FirstTitle
            // 
            this.FirstTitle.AutoSize = true;
            this.FirstTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FirstTitle.Location = new System.Drawing.Point(171, 59);
            this.FirstTitle.Name = "FirstTitle";
            this.FirstTitle.Size = new System.Drawing.Size(46, 17);
            this.FirstTitle.TabIndex = 10;
            this.FirstTitle.Text = "label2";
            // 
            // FirstDescription
            // 
            this.FirstDescription.Location = new System.Drawing.Point(346, 59);
            this.FirstDescription.Name = "FirstDescription";
            this.FirstDescription.Size = new System.Drawing.Size(251, 107);
            this.FirstDescription.TabIndex = 11;
            this.FirstDescription.Text = "";
            // 
            // SecondDate
            // 
            this.SecondDate.AutoSize = true;
            this.SecondDate.Location = new System.Drawing.Point(66, 191);
            this.SecondDate.Name = "SecondDate";
            this.SecondDate.Size = new System.Drawing.Size(35, 13);
            this.SecondDate.TabIndex = 12;
            this.SecondDate.Text = "label2";
            // 
            // SecondDescription
            // 
            this.SecondDescription.Location = new System.Drawing.Point(346, 188);
            this.SecondDescription.Name = "SecondDescription";
            this.SecondDescription.Size = new System.Drawing.Size(251, 107);
            this.SecondDescription.TabIndex = 13;
            this.SecondDescription.Text = "";
            // 
            // ThirdDate
            // 
            this.ThirdDate.AutoSize = true;
            this.ThirdDate.Location = new System.Drawing.Point(58, 322);
            this.ThirdDate.Name = "ThirdDate";
            this.ThirdDate.Size = new System.Drawing.Size(35, 13);
            this.ThirdDate.TabIndex = 14;
            this.ThirdDate.Text = "label2";
            // 
            // ThirdDescription
            // 
            this.ThirdDescription.Location = new System.Drawing.Point(346, 318);
            this.ThirdDescription.Name = "ThirdDescription";
            this.ThirdDescription.Size = new System.Drawing.Size(251, 102);
            this.ThirdDescription.TabIndex = 15;
            this.ThirdDescription.Text = "";
            // 
            // PatientNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 558);
            this.Controls.Add(this.ThirdDescription);
            this.Controls.Add(this.ThirdDate);
            this.Controls.Add(this.SecondDescription);
            this.Controls.Add(this.SecondDate);
            this.Controls.Add(this.FirstDescription);
            this.Controls.Add(this.FirstTitle);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.ThirdTitle);
            this.Controls.Add(this.SecondTitle);
            this.Controls.Add(this.FirstDate);
            this.Controls.Add(this.label1);
            this.Name = "PatientNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AktualnosciPacjent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Label5_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FirstDate;
        private System.Windows.Forms.Label SecondTitle;
        private System.Windows.Forms.Label ThirdTitle;
        private System.Windows.Forms.Label BtnBack;
        private System.Windows.Forms.Label FirstTitle;
        private System.Windows.Forms.RichTextBox FirstDescription;
        private System.Windows.Forms.Label SecondDate;
        private System.Windows.Forms.RichTextBox SecondDescription;
        private System.Windows.Forms.Label ThirdDate;
        private System.Windows.Forms.RichTextBox ThirdDescription;
    }
}
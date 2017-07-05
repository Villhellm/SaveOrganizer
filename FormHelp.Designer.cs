namespace SaveOrganizer
{
    partial class FormHelp
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
            this.LnkLblEmail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LnkLblEmail
            // 
            this.LnkLblEmail.AutoSize = true;
            this.LnkLblEmail.Location = new System.Drawing.Point(138, 111);
            this.LnkLblEmail.Name = "LnkLblEmail";
            this.LnkLblEmail.Size = new System.Drawing.Size(128, 13);
            this.LnkLblEmail.TabIndex = 0;
            this.LnkLblEmail.TabStop = true;
            this.LnkLblEmail.Text = "VillhellmSouls@gmail.com";
            this.LnkLblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblEmail_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email me your problem, I try to help you out as soon as I can";
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LnkLblEmail);
            this.Name = "FormHelp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.FormHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LnkLblEmail;
        private System.Windows.Forms.Label label1;
    }
}
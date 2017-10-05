namespace SaveOrganizer
{
    partial class FormUpdatePrompt
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
            this.BtnYes = new System.Windows.Forms.Button();
            this.BtnNo = new System.Windows.Forms.Button();
            this.CBNeverAgain = new System.Windows.Forms.CheckBox();
            this.LblUpdateText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnYes
            // 
            this.BtnYes.Location = new System.Drawing.Point(40, 104);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(106, 31);
            this.BtnYes.TabIndex = 0;
            this.BtnYes.Text = "Yes";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(170, 104);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(106, 31);
            this.BtnNo.TabIndex = 1;
            this.BtnNo.Text = "No";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // CBNeverAgain
            // 
            this.CBNeverAgain.AutoSize = true;
            this.CBNeverAgain.Location = new System.Drawing.Point(40, 71);
            this.CBNeverAgain.Name = "CBNeverAgain";
            this.CBNeverAgain.Size = new System.Drawing.Size(136, 17);
            this.CBNeverAgain.TabIndex = 2;
            this.CBNeverAgain.Text = "Never prompt me again";
            this.CBNeverAgain.UseVisualStyleBackColor = true;
            // 
            // LblUpdateText
            // 
            this.LblUpdateText.AutoSize = true;
            this.LblUpdateText.Location = new System.Drawing.Point(37, 31);
            this.LblUpdateText.Name = "LblUpdateText";
            this.LblUpdateText.Size = new System.Drawing.Size(63, 13);
            this.LblUpdateText.TabIndex = 3;
            this.LblUpdateText.Text = "UpdateText";
            // 
            // FormUpdatePrompt
            // 
            this.AcceptButton = this.BtnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 148);
            this.Controls.Add(this.LblUpdateText);
            this.Controls.Add(this.CBNeverAgain);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnYes);
            this.Name = "FormUpdatePrompt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Available";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnYes;
        private System.Windows.Forms.Button BtnNo;
        private System.Windows.Forms.CheckBox CBNeverAgain;
        private System.Windows.Forms.Label LblUpdateText;
    }
}
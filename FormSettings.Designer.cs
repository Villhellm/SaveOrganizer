namespace SaveOrganizer
{
    partial class FormSettings
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
            this.CBToggleGlobalHotkeys = new System.Windows.Forms.CheckBox();
            this.CBAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnManualUpdateCheck = new System.Windows.Forms.Button();
            this.FLPHotkeys = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // CBToggleGlobalHotkeys
            // 
            this.CBToggleGlobalHotkeys.AutoSize = true;
            this.CBToggleGlobalHotkeys.Location = new System.Drawing.Point(52, 75);
            this.CBToggleGlobalHotkeys.Name = "CBToggleGlobalHotkeys";
            this.CBToggleGlobalHotkeys.Size = new System.Drawing.Size(134, 17);
            this.CBToggleGlobalHotkeys.TabIndex = 0;
            this.CBToggleGlobalHotkeys.Text = "Toggle Global Hotkeys";
            this.CBToggleGlobalHotkeys.UseVisualStyleBackColor = true;
            this.CBToggleGlobalHotkeys.CheckedChanged += new System.EventHandler(this.CBToggleGlobalHotkeys_CheckedChanged);
            // 
            // CBAlwaysOnTop
            // 
            this.CBAlwaysOnTop.AutoSize = true;
            this.CBAlwaysOnTop.Location = new System.Drawing.Point(52, 52);
            this.CBAlwaysOnTop.Name = "CBAlwaysOnTop";
            this.CBAlwaysOnTop.Size = new System.Drawing.Size(98, 17);
            this.CBAlwaysOnTop.TabIndex = 4;
            this.CBAlwaysOnTop.Text = "Always On Top";
            this.CBAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(52, 398);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(194, 398);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(12, 9);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(42, 13);
            this.LblVersion.TabIndex = 20;
            this.LblVersion.Text = "Version";
            // 
            // BtnManualUpdateCheck
            // 
            this.BtnManualUpdateCheck.Location = new System.Drawing.Point(153, 4);
            this.BtnManualUpdateCheck.Name = "BtnManualUpdateCheck";
            this.BtnManualUpdateCheck.Size = new System.Drawing.Size(116, 23);
            this.BtnManualUpdateCheck.TabIndex = 21;
            this.BtnManualUpdateCheck.Text = "Check for updates";
            this.BtnManualUpdateCheck.UseVisualStyleBackColor = true;
            this.BtnManualUpdateCheck.Click += new System.EventHandler(this.BtnManualUpdateCheck_Click);
            // 
            // FLPHotkeys
            // 
            this.FLPHotkeys.AutoSize = true;
            this.FLPHotkeys.Location = new System.Drawing.Point(69, 95);
            this.FLPHotkeys.Margin = new System.Windows.Forms.Padding(0);
            this.FLPHotkeys.Name = "FLPHotkeys";
            this.FLPHotkeys.Size = new System.Drawing.Size(332, 264);
            this.FLPHotkeys.TabIndex = 0;
            this.FLPHotkeys.Resize += new System.EventHandler(this.FLPHotkeys_Resize);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 433);
            this.Controls.Add(this.FLPHotkeys);
            this.Controls.Add(this.BtnManualUpdateCheck);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CBAlwaysOnTop);
            this.Controls.Add(this.CBToggleGlobalHotkeys);
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.Text = "User Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBToggleGlobalHotkeys;
        private System.Windows.Forms.CheckBox CBAlwaysOnTop;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Button BtnManualUpdateCheck;
        private System.Windows.Forms.FlowLayoutPanel FLPHotkeys;
    }
}
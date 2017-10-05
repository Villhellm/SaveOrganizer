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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FLPHotkeys = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.BtnSave.Location = new System.Drawing.Point(52, 362);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(194, 362);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(69, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 264);
            this.panel1.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FLPHotkeys, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 264);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FLPHotkeys
            // 
            this.FLPHotkeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPHotkeys.Location = new System.Drawing.Point(0, 0);
            this.FLPHotkeys.Margin = new System.Windows.Forms.Padding(0);
            this.FLPHotkeys.Name = "FLPHotkeys";
            this.FLPHotkeys.Size = new System.Drawing.Size(332, 264);
            this.FLPHotkeys.TabIndex = 0;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 410);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel FLPHotkeys;
    }
}
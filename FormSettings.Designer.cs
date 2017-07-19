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
            this.CBExportSelectedSave = new System.Windows.Forms.CheckBox();
            this.CBImportCurrentSave = new System.Windows.Forms.CheckBox();
            this.CBToggleReadOnly = new System.Windows.Forms.CheckBox();
            this.CBAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtToggleReadOnlyHotkey = new System.Windows.Forms.Label();
            this.TxtExportSaveHotkey = new System.Windows.Forms.Label();
            this.TxtImportSaveHotkey = new System.Windows.Forms.Label();
            this.TxtQuickSaveHotkey = new System.Windows.Forms.Label();
            this.CBQuicksave = new System.Windows.Forms.CheckBox();
            this.TxtQuickLoadHotkey = new System.Windows.Forms.Label();
            this.CBQuickload = new System.Windows.Forms.CheckBox();
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
            // CBExportSelectedSave
            // 
            this.CBExportSelectedSave.AutoSize = true;
            this.CBExportSelectedSave.Enabled = false;
            this.CBExportSelectedSave.Location = new System.Drawing.Point(68, 98);
            this.CBExportSelectedSave.Name = "CBExportSelectedSave";
            this.CBExportSelectedSave.Size = new System.Drawing.Size(129, 17);
            this.CBExportSelectedSave.TabIndex = 1;
            this.CBExportSelectedSave.Text = "Export Selected Save";
            this.CBExportSelectedSave.UseVisualStyleBackColor = true;
            // 
            // CBImportCurrentSave
            // 
            this.CBImportCurrentSave.AutoSize = true;
            this.CBImportCurrentSave.Enabled = false;
            this.CBImportCurrentSave.Location = new System.Drawing.Point(68, 131);
            this.CBImportCurrentSave.Name = "CBImportCurrentSave";
            this.CBImportCurrentSave.Size = new System.Drawing.Size(120, 17);
            this.CBImportCurrentSave.TabIndex = 2;
            this.CBImportCurrentSave.Text = "Import Current Save";
            this.CBImportCurrentSave.UseVisualStyleBackColor = true;
            // 
            // CBToggleReadOnly
            // 
            this.CBToggleReadOnly.AutoSize = true;
            this.CBToggleReadOnly.Enabled = false;
            this.CBToggleReadOnly.Location = new System.Drawing.Point(68, 164);
            this.CBToggleReadOnly.Name = "CBToggleReadOnly";
            this.CBToggleReadOnly.Size = new System.Drawing.Size(112, 17);
            this.CBToggleReadOnly.TabIndex = 3;
            this.CBToggleReadOnly.Text = "Toggle Read Only";
            this.CBToggleReadOnly.UseVisualStyleBackColor = true;
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
            this.BtnSave.Location = new System.Drawing.Point(52, 267);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(194, 267);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtToggleReadOnlyHotkey
            // 
            this.TxtToggleReadOnlyHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtToggleReadOnlyHotkey.Enabled = false;
            this.TxtToggleReadOnlyHotkey.Location = new System.Drawing.Point(205, 164);
            this.TxtToggleReadOnlyHotkey.Name = "TxtToggleReadOnlyHotkey";
            this.TxtToggleReadOnlyHotkey.Size = new System.Drawing.Size(184, 24);
            this.TxtToggleReadOnlyHotkey.TabIndex = 11;
            this.TxtToggleReadOnlyHotkey.Click += new System.EventHandler(this.SaveHotkey_Click);
            this.TxtToggleReadOnlyHotkey.Enter += new System.EventHandler(this.SaveHotkey_Enter);
            this.TxtToggleReadOnlyHotkey.Leave += new System.EventHandler(this.SaveHotkey_Leave);
            // 
            // TxtExportSaveHotkey
            // 
            this.TxtExportSaveHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtExportSaveHotkey.Enabled = false;
            this.TxtExportSaveHotkey.Location = new System.Drawing.Point(205, 96);
            this.TxtExportSaveHotkey.Name = "TxtExportSaveHotkey";
            this.TxtExportSaveHotkey.Size = new System.Drawing.Size(184, 24);
            this.TxtExportSaveHotkey.TabIndex = 12;
            this.TxtExportSaveHotkey.Click += new System.EventHandler(this.SaveHotkey_Click);
            this.TxtExportSaveHotkey.Enter += new System.EventHandler(this.SaveHotkey_Enter);
            this.TxtExportSaveHotkey.Leave += new System.EventHandler(this.SaveHotkey_Leave);
            // 
            // TxtImportSaveHotkey
            // 
            this.TxtImportSaveHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtImportSaveHotkey.Enabled = false;
            this.TxtImportSaveHotkey.Location = new System.Drawing.Point(205, 130);
            this.TxtImportSaveHotkey.Name = "TxtImportSaveHotkey";
            this.TxtImportSaveHotkey.Size = new System.Drawing.Size(184, 24);
            this.TxtImportSaveHotkey.TabIndex = 13;
            this.TxtImportSaveHotkey.Click += new System.EventHandler(this.SaveHotkey_Click);
            this.TxtImportSaveHotkey.Enter += new System.EventHandler(this.SaveHotkey_Enter);
            this.TxtImportSaveHotkey.Leave += new System.EventHandler(this.SaveHotkey_Leave);
            // 
            // TxtQuickSaveHotkey
            // 
            this.TxtQuickSaveHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtQuickSaveHotkey.Enabled = false;
            this.TxtQuickSaveHotkey.Location = new System.Drawing.Point(205, 199);
            this.TxtQuickSaveHotkey.Name = "TxtQuickSaveHotkey";
            this.TxtQuickSaveHotkey.Size = new System.Drawing.Size(184, 24);
            this.TxtQuickSaveHotkey.TabIndex = 15;
            this.TxtQuickSaveHotkey.Click += new System.EventHandler(this.SaveHotkey_Click);
            this.TxtQuickSaveHotkey.Enter += new System.EventHandler(this.SaveHotkey_Enter);
            this.TxtQuickSaveHotkey.Leave += new System.EventHandler(this.SaveHotkey_Leave);
            // 
            // CBQuicksave
            // 
            this.CBQuicksave.AutoSize = true;
            this.CBQuicksave.Enabled = false;
            this.CBQuicksave.Location = new System.Drawing.Point(68, 199);
            this.CBQuicksave.Name = "CBQuicksave";
            this.CBQuicksave.Size = new System.Drawing.Size(82, 17);
            this.CBQuicksave.TabIndex = 14;
            this.CBQuicksave.Text = "Quick-Save";
            this.CBQuicksave.UseVisualStyleBackColor = true;
            // 
            // TxtQuickLoadHotkey
            // 
            this.TxtQuickLoadHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtQuickLoadHotkey.Enabled = false;
            this.TxtQuickLoadHotkey.Location = new System.Drawing.Point(205, 233);
            this.TxtQuickLoadHotkey.Name = "TxtQuickLoadHotkey";
            this.TxtQuickLoadHotkey.Size = new System.Drawing.Size(184, 24);
            this.TxtQuickLoadHotkey.TabIndex = 17;
            this.TxtQuickLoadHotkey.Click += new System.EventHandler(this.SaveHotkey_Click);
            this.TxtQuickLoadHotkey.Enter += new System.EventHandler(this.SaveHotkey_Enter);
            this.TxtQuickLoadHotkey.Leave += new System.EventHandler(this.SaveHotkey_Leave);
            // 
            // CBQuickload
            // 
            this.CBQuickload.AutoSize = true;
            this.CBQuickload.Enabled = false;
            this.CBQuickload.Location = new System.Drawing.Point(68, 233);
            this.CBQuickload.Name = "CBQuickload";
            this.CBQuickload.Size = new System.Drawing.Size(81, 17);
            this.CBQuickload.TabIndex = 16;
            this.CBQuickload.Text = "Quick-Load";
            this.CBQuickload.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 316);
            this.Controls.Add(this.TxtQuickLoadHotkey);
            this.Controls.Add(this.CBQuickload);
            this.Controls.Add(this.TxtQuickSaveHotkey);
            this.Controls.Add(this.CBQuicksave);
            this.Controls.Add(this.TxtImportSaveHotkey);
            this.Controls.Add(this.TxtExportSaveHotkey);
            this.Controls.Add(this.TxtToggleReadOnlyHotkey);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CBAlwaysOnTop);
            this.Controls.Add(this.CBToggleReadOnly);
            this.Controls.Add(this.CBImportCurrentSave);
            this.Controls.Add(this.CBExportSelectedSave);
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
        private System.Windows.Forms.CheckBox CBExportSelectedSave;
        private System.Windows.Forms.CheckBox CBImportCurrentSave;
        private System.Windows.Forms.CheckBox CBToggleReadOnly;
        private System.Windows.Forms.CheckBox CBAlwaysOnTop;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label TxtToggleReadOnlyHotkey;
        private System.Windows.Forms.Label TxtExportSaveHotkey;
        private System.Windows.Forms.Label TxtImportSaveHotkey;
        private System.Windows.Forms.Label TxtQuickSaveHotkey;
        private System.Windows.Forms.CheckBox CBQuicksave;
        private System.Windows.Forms.Label TxtQuickLoadHotkey;
        private System.Windows.Forms.CheckBox CBQuickload;
    }
}
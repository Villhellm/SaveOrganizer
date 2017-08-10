namespace SaveOrganizer
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ComboBoxSelectGame = new System.Windows.Forms.ComboBox();
            this.CSMGameEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSavefileSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboBoxSelectSubDirectory = new System.Windows.Forms.ComboBox();
            this.CMSProfileEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExistingProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnImportSave = new System.Windows.Forms.Button();
            this.BtnExportSave = new System.Windows.Forms.Button();
            this.BtnDeleteSave = new System.Windows.Forms.Button();
            this.TTProfile = new System.Windows.Forms.ToolTip(this.components);
            this.TSMain = new System.Windows.Forms.ToolStrip();
            this.TSDDFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.editCurrentGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSavefileSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInFileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoFileDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.LblGame = new System.Windows.Forms.Label();
            this.LblProfile = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGVSaveFiles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TxtFileSearch = new System.Windows.Forms.TextBox();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.CSMGameEdit.SuspendLayout();
            this.CMSProfileEdit.SuspendLayout();
            this.TSMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaveFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxSelectGame
            // 
            this.ComboBoxSelectGame.ContextMenuStrip = this.CSMGameEdit;
            this.ComboBoxSelectGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxSelectGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSelectGame.FormattingEnabled = true;
            this.ComboBoxSelectGame.Location = new System.Drawing.Point(3, 33);
            this.ComboBoxSelectGame.Name = "ComboBoxSelectGame";
            this.ComboBoxSelectGame.Size = new System.Drawing.Size(154, 21);
            this.ComboBoxSelectGame.TabIndex = 0;
            this.TTProfile.SetToolTip(this.ComboBoxSelectGame, "Right click for more options");
            this.ComboBoxSelectGame.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectGame_SelectedIndexChanged);
            // 
            // CSMGameEdit
            // 
            this.CSMGameEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteGameToolStripMenuItem1,
            this.changeSavefileSourceToolStripMenuItem});
            this.CSMGameEdit.Name = "CSMGameEdit";
            this.CSMGameEdit.Size = new System.Drawing.Size(198, 48);
            // 
            // deleteGameToolStripMenuItem1
            // 
            this.deleteGameToolStripMenuItem1.Name = "deleteGameToolStripMenuItem1";
            this.deleteGameToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.deleteGameToolStripMenuItem1.Text = "Delete Game";
            this.deleteGameToolStripMenuItem1.Click += new System.EventHandler(this.deleteGameToolStripMenuItem1_Click);
            // 
            // changeSavefileSourceToolStripMenuItem
            // 
            this.changeSavefileSourceToolStripMenuItem.Name = "changeSavefileSourceToolStripMenuItem";
            this.changeSavefileSourceToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.changeSavefileSourceToolStripMenuItem.Text = "Change Savefile Source";
            this.changeSavefileSourceToolStripMenuItem.Click += new System.EventHandler(this.changeSavefileSourceToolStripMenuItem_Click);
            // 
            // ComboBoxSelectSubDirectory
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBoxSelectSubDirectory, 2);
            this.ComboBoxSelectSubDirectory.ContextMenuStrip = this.CMSProfileEdit;
            this.ComboBoxSelectSubDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxSelectSubDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSelectSubDirectory.FormattingEnabled = true;
            this.ComboBoxSelectSubDirectory.Items.AddRange(new object[] {
            "Default"});
            this.ComboBoxSelectSubDirectory.Location = new System.Drawing.Point(163, 33);
            this.ComboBoxSelectSubDirectory.Name = "ComboBoxSelectSubDirectory";
            this.ComboBoxSelectSubDirectory.Size = new System.Drawing.Size(328, 21);
            this.ComboBoxSelectSubDirectory.TabIndex = 1;
            this.TTProfile.SetToolTip(this.ComboBoxSelectSubDirectory, "Right click for more options");
            this.ComboBoxSelectSubDirectory.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectSubDirectory_SelectedIndexChanged);
            // 
            // CMSProfileEdit
            // 
            this.CMSProfileEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameCurrentProfileToolStripMenuItem,
            this.deleteCurrentProfileToolStripMenuItem,
            this.addNewProfileToolStripMenuItem,
            this.importExistingProfileToolStripMenuItem});
            this.CMSProfileEdit.Name = "CMSProfileEdit";
            this.CMSProfileEdit.Size = new System.Drawing.Size(198, 92);
            // 
            // renameCurrentProfileToolStripMenuItem
            // 
            this.renameCurrentProfileToolStripMenuItem.Name = "renameCurrentProfileToolStripMenuItem";
            this.renameCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.renameCurrentProfileToolStripMenuItem.Text = "Rename Current Profile";
            this.renameCurrentProfileToolStripMenuItem.Click += new System.EventHandler(this.renameCurrentProfileToolStripMenuItem_Click);
            // 
            // deleteCurrentProfileToolStripMenuItem
            // 
            this.deleteCurrentProfileToolStripMenuItem.Name = "deleteCurrentProfileToolStripMenuItem";
            this.deleteCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.deleteCurrentProfileToolStripMenuItem.Text = "Delete Current Profile";
            this.deleteCurrentProfileToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentProfileToolStripMenuItem_Click);
            // 
            // addNewProfileToolStripMenuItem
            // 
            this.addNewProfileToolStripMenuItem.Name = "addNewProfileToolStripMenuItem";
            this.addNewProfileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addNewProfileToolStripMenuItem.Text = "Add New Profile";
            this.addNewProfileToolStripMenuItem.Click += new System.EventHandler(this.addNewProfileToolStripMenuItem_Click);
            // 
            // importExistingProfileToolStripMenuItem
            // 
            this.importExistingProfileToolStripMenuItem.Name = "importExistingProfileToolStripMenuItem";
            this.importExistingProfileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.importExistingProfileToolStripMenuItem.Text = "Import Existing Profile";
            this.importExistingProfileToolStripMenuItem.Click += new System.EventHandler(this.importExistingProfileToolStripMenuItem_Click);
            // 
            // BtnImportSave
            // 
            this.BtnImportSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnImportSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BtnImportSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImportSave.Location = new System.Drawing.Point(3, 374);
            this.BtnImportSave.Name = "BtnImportSave";
            this.BtnImportSave.Size = new System.Drawing.Size(154, 49);
            this.BtnImportSave.TabIndex = 6;
            this.BtnImportSave.Text = "Import Save";
            this.BtnImportSave.UseVisualStyleBackColor = false;
            this.BtnImportSave.Click += new System.EventHandler(this.BtnImportSave_Click);
            // 
            // BtnExportSave
            // 
            this.BtnExportSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExportSave.BackColor = System.Drawing.Color.SandyBrown;
            this.BtnExportSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportSave.Location = new System.Drawing.Point(163, 374);
            this.BtnExportSave.Name = "BtnExportSave";
            this.BtnExportSave.Size = new System.Drawing.Size(161, 49);
            this.BtnExportSave.TabIndex = 7;
            this.BtnExportSave.Text = "Export Selected";
            this.BtnExportSave.UseVisualStyleBackColor = false;
            this.BtnExportSave.Click += new System.EventHandler(this.BtnExportSave_Click);
            // 
            // BtnDeleteSave
            // 
            this.BtnDeleteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDeleteSave.BackColor = System.Drawing.Color.Firebrick;
            this.BtnDeleteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteSave.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnDeleteSave.Location = new System.Drawing.Point(330, 374);
            this.BtnDeleteSave.Name = "BtnDeleteSave";
            this.BtnDeleteSave.Size = new System.Drawing.Size(161, 49);
            this.BtnDeleteSave.TabIndex = 9;
            this.BtnDeleteSave.Text = "Delete Selected";
            this.BtnDeleteSave.UseVisualStyleBackColor = false;
            this.BtnDeleteSave.Click += new System.EventHandler(this.BtnDeleteSave_Click);
            // 
            // TSMain
            // 
            this.TSMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDDFile,
            this.TSBtnHelp});
            this.TSMain.Location = new System.Drawing.Point(0, 0);
            this.TSMain.Name = "TSMain";
            this.TSMain.Size = new System.Drawing.Size(494, 25);
            this.TSMain.TabIndex = 12;
            this.TSMain.Text = "MainTools";
            // 
            // TSDDFile
            // 
            this.TSDDFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSDDFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCurrentGameToolStripMenuItem,
            this.editCurrentProfileToolStripMenuItem,
            this.addProfileToolStripMenuItem,
            this.selectedSaveToolStripMenuItem,
            this.undoFileDeleteToolStripMenuItem,
            this.undoExportToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.TSDDFile.Image = ((System.Drawing.Image)(resources.GetObject("TSDDFile.Image")));
            this.TSDDFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDDFile.Name = "TSDDFile";
            this.TSDDFile.Size = new System.Drawing.Size(38, 22);
            this.TSDDFile.Text = "File";
            this.TSDDFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // editCurrentGameToolStripMenuItem
            // 
            this.editCurrentGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteGameToolStripMenuItem,
            this.setSavefileSourceToolStripMenuItem});
            this.editCurrentGameToolStripMenuItem.Name = "editCurrentGameToolStripMenuItem";
            this.editCurrentGameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.editCurrentGameToolStripMenuItem.Text = "Edit Current Game";
            // 
            // deleteGameToolStripMenuItem
            // 
            this.deleteGameToolStripMenuItem.Name = "deleteGameToolStripMenuItem";
            this.deleteGameToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deleteGameToolStripMenuItem.Text = "Delete Game";
            this.deleteGameToolStripMenuItem.Click += new System.EventHandler(this.deleteGameToolStripMenuItem_Click);
            // 
            // setSavefileSourceToolStripMenuItem
            // 
            this.setSavefileSourceToolStripMenuItem.Name = "setSavefileSourceToolStripMenuItem";
            this.setSavefileSourceToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.setSavefileSourceToolStripMenuItem.Text = "Set Savefile Source";
            this.setSavefileSourceToolStripMenuItem.Click += new System.EventHandler(this.setSavefileSourceToolStripMenuItem_Click);
            // 
            // editCurrentProfileToolStripMenuItem
            // 
            this.editCurrentProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editCurrentProfileToolStripMenuItem.Name = "editCurrentProfileToolStripMenuItem";
            this.editCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.editCurrentProfileToolStripMenuItem.Text = "Edit Current Profile";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addProfileToolStripMenuItem
            // 
            this.addProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.importExistingToolStripMenuItem});
            this.addProfileToolStripMenuItem.Name = "addProfileToolStripMenuItem";
            this.addProfileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addProfileToolStripMenuItem.Text = "Add Profile";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // importExistingToolStripMenuItem
            // 
            this.importExistingToolStripMenuItem.Name = "importExistingToolStripMenuItem";
            this.importExistingToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importExistingToolStripMenuItem.Text = "Import Existing";
            this.importExistingToolStripMenuItem.Click += new System.EventHandler(this.importExistingToolStripMenuItem_Click);
            // 
            // selectedSaveToolStripMenuItem
            // 
            this.selectedSaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.openInFileExplorerToolStripMenuItem});
            this.selectedSaveToolStripMenuItem.Name = "selectedSaveToolStripMenuItem";
            this.selectedSaveToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.selectedSaveToolStripMenuItem.Text = "Selected Save";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // openInFileExplorerToolStripMenuItem
            // 
            this.openInFileExplorerToolStripMenuItem.Name = "openInFileExplorerToolStripMenuItem";
            this.openInFileExplorerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openInFileExplorerToolStripMenuItem.Text = "Open in File Explorer";
            this.openInFileExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInFileExplorerToolStripMenuItem_Click);
            // 
            // undoFileDeleteToolStripMenuItem
            // 
            this.undoFileDeleteToolStripMenuItem.Enabled = false;
            this.undoFileDeleteToolStripMenuItem.Name = "undoFileDeleteToolStripMenuItem";
            this.undoFileDeleteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoFileDeleteToolStripMenuItem.Text = "Undo File Delete";
            this.undoFileDeleteToolStripMenuItem.Click += new System.EventHandler(this.undoFileDeleteToolStripMenuItem_Click);
            // 
            // undoExportToolStripMenuItem
            // 
            this.undoExportToolStripMenuItem.Enabled = false;
            this.undoExportToolStripMenuItem.Name = "undoExportToolStripMenuItem";
            this.undoExportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoExportToolStripMenuItem.Text = "Undo Export";
            this.undoExportToolStripMenuItem.Click += new System.EventHandler(this.undoExportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // TSBtnHelp
            // 
            this.TSBtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("TSBtnHelp.Image")));
            this.TSBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnHelp.Name = "TSBtnHelp";
            this.TSBtnHelp.Size = new System.Drawing.Size(36, 22);
            this.TSBtnHelp.Text = "Help";
            this.TSBtnHelp.Click += new System.EventHandler(this.TSBtnHelp_Click);
            // 
            // LblGame
            // 
            this.LblGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblGame.AutoSize = true;
            this.LblGame.Location = new System.Drawing.Point(3, 17);
            this.LblGame.Name = "LblGame";
            this.LblGame.Size = new System.Drawing.Size(35, 13);
            this.LblGame.TabIndex = 13;
            this.LblGame.Text = "Game";
            // 
            // LblProfile
            // 
            this.LblProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblProfile.AutoSize = true;
            this.LblProfile.Location = new System.Drawing.Point(163, 17);
            this.LblProfile.Name = "LblProfile";
            this.LblProfile.Size = new System.Drawing.Size(36, 13);
            this.LblProfile.TabIndex = 14;
            this.LblProfile.Text = "Profile";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LblGame, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblProfile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxSelectSubDirectory, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVSaveFiles, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxSelectGame, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtFileSearch, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnImportSave, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnExportSave, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnDeleteSave, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGVSaveFiles
            // 
            this.DGVSaveFiles.AllowUserToAddRows = false;
            this.DGVSaveFiles.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVSaveFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSaveFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSaveFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSaveFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1});
            this.tableLayoutPanel1.SetColumnSpan(this.DGVSaveFiles, 3);
            this.DGVSaveFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSaveFiles.EnableHeadersVisualStyles = false;
            this.DGVSaveFiles.Location = new System.Drawing.Point(3, 93);
            this.DGVSaveFiles.Name = "DGVSaveFiles";
            this.DGVSaveFiles.RowHeadersVisible = false;
            this.DGVSaveFiles.Size = new System.Drawing.Size(488, 275);
            this.DGVSaveFiles.TabIndex = 8;
            this.DGVSaveFiles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGVSaveFiles_CellBeginEdit);
            this.DGVSaveFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSaveFiles_CellEndEdit);
            this.DGVSaveFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSaveFiles_CellValueChanged);
            this.DGVSaveFiles.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGVSaveFiles_CurrentCellDirtyStateChanged);
            this.DGVSaveFiles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVSaveFiles_DataBindingComplete);
            this.DGVSaveFiles.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.DGVSaveFiles_SortCompare);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 40F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.FillWeight = 40F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Date Created";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewCheckBoxColumn1.FillWeight = 20F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Read Only";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TxtFileSearch
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TxtFileSearch, 3);
            this.TxtFileSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFileSearch.Location = new System.Drawing.Point(3, 63);
            this.TxtFileSearch.Name = "TxtFileSearch";
            this.TxtFileSearch.Size = new System.Drawing.Size(488, 20);
            this.TxtFileSearch.TabIndex = 3;
            this.TxtFileSearch.Text = "Search...";
            this.TxtFileSearch.TextChanged += new System.EventHandler(this.TxtFileSearch_TextChanged);
            this.TxtFileSearch.Enter += new System.EventHandler(this.TxtFileSearch_Enter);
            this.TxtFileSearch.Leave += new System.EventHandler(this.TxtFileSearch_Leave);
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(471, 5);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(20, 20);
            this.Browser.TabIndex = 13;
            this.Browser.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 451);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TSMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Save Organizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.CSMGameEdit.ResumeLayout(false);
            this.CMSProfileEdit.ResumeLayout(false);
            this.TSMain.ResumeLayout(false);
            this.TSMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaveFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxSelectGame;
        private System.Windows.Forms.ComboBox ComboBoxSelectSubDirectory;
        private System.Windows.Forms.Button BtnImportSave;
        private System.Windows.Forms.Button BtnExportSave;
        private System.Windows.Forms.Button BtnDeleteSave;
        private System.Windows.Forms.ContextMenuStrip CMSProfileEdit;
        private System.Windows.Forms.ToolStripMenuItem renameCurrentProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExistingProfileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CSMGameEdit;
        private System.Windows.Forms.ToolStripMenuItem changeSavefileSourceToolStripMenuItem;
        private System.Windows.Forms.ToolTip TTProfile;
        private System.Windows.Forms.ToolStrip TSMain;
        private System.Windows.Forms.ToolStripDropDownButton TSDDFile;
        private System.Windows.Forms.ToolStripMenuItem editCurrentProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label LblGame;
        private System.Windows.Forms.Label LblProfile;
        private System.Windows.Forms.ToolStripMenuItem addProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExistingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInFileExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSBtnHelp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DGVSaveFiles;
        private System.Windows.Forms.TextBox TxtFileSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem editCurrentGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSavefileSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoFileDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoExportToolStripMenuItem;
        private System.Windows.Forms.WebBrowser Browser;
    }
}


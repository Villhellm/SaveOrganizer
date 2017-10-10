namespace SaveOrganizer
{
    partial class FormToastResponse
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
            this.LblToast = new System.Windows.Forms.Label();
            this.TimerStart = new System.Windows.Forms.Timer(this.components);
            this.TimerStop = new System.Windows.Forms.Timer(this.components);
            this.EventsTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnOkay = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblToast
            // 
            this.LblToast.BackColor = System.Drawing.Color.Teal;
            this.LblToast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblToast.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblToast.ForeColor = System.Drawing.Color.White;
            this.LblToast.Location = new System.Drawing.Point(0, -2);
            this.LblToast.Name = "LblToast";
            this.LblToast.Size = new System.Drawing.Size(367, 103);
            this.LblToast.TabIndex = 2;
            this.LblToast.Text = "Hello There";
            this.LblToast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerStart
            // 
            this.TimerStart.Interval = 10;
            this.TimerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
            // 
            // TimerStop
            // 
            this.TimerStop.Interval = 10;
            this.TimerStop.Tick += new System.EventHandler(this.TimerStop_Tick);
            // 
            // BtnOkay
            // 
            this.BtnOkay.Location = new System.Drawing.Point(72, 131);
            this.BtnOkay.Name = "BtnOkay";
            this.BtnOkay.Size = new System.Drawing.Size(92, 35);
            this.BtnOkay.TabIndex = 0;
            this.BtnOkay.Text = "Yes";
            this.BtnOkay.UseVisualStyleBackColor = true;
            this.BtnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(207, 131);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(87, 35);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "No";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormToastResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(366, 200);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOkay);
            this.Controls.Add(this.LblToast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToastResponse";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormToast";
            this.Load += new System.EventHandler(this.ToastForm_Load);
            this.Shown += new System.EventHandler(this.FormToastResponse_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ToastForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblToast;
        private System.Windows.Forms.Timer TimerStart;
        private System.Windows.Forms.Timer TimerStop;
        private System.Windows.Forms.Timer EventsTimer;
        private System.Windows.Forms.Button BtnOkay;
        private System.Windows.Forms.Button BtnCancel;
    }
}
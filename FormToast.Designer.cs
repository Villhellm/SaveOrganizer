namespace SaveOrganizer
{
    partial class FormToast
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
            this.SuspendLayout();
            // 
            // LblToast
            // 
            this.LblToast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblToast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblToast.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblToast.ForeColor = System.Drawing.Color.White;
            this.LblToast.Location = new System.Drawing.Point(0, 0);
            this.LblToast.Name = "LblToast";
            this.LblToast.Size = new System.Drawing.Size(366, 366);
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
            // EventsTimer
            // 
            this.EventsTimer.Tick += new System.EventHandler(this.EventsTimer_Tick);
            // 
            // FormToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(366, 366);
            this.Controls.Add(this.LblToast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToast";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormToast";
            this.Load += new System.EventHandler(this.ToastForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ToastForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblToast;
        private System.Windows.Forms.Timer TimerStart;
        private System.Windows.Forms.Timer TimerStop;
        private System.Windows.Forms.Timer EventsTimer;
    }
}
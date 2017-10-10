using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class FormRename : Form
    {
        public FormRename()
        {
            InitializeComponent();
        }

        public string NewName { get; set; }
    
        private void BtnOkay_Click(object sender, EventArgs e)
        {
            NewName = TxtRename.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        private void TxtRename_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                NewName = TxtRename.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class FormUpdatePrompt : Form
    {
        public FormUpdatePrompt(string VersionNumber)
        {
            InitializeComponent();
            LblUpdateText.Text = VersionNumber;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            if (CBNeverAgain.Checked)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void LnkLblEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:"+"Kind.Dragonfruit@gmail.com");
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}

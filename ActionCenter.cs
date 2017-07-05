using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    class ActionCenter
    {
        public static void Toast(string Toast, Point StartPoint, double Seconds = 1)
        {
            try
            {
                FormToast ShowToast = new FormToast(Toast, StartPoint, Seconds);
                ShowToast.StartPosition = FormStartPosition.CenterParent;
                var secondFormThread = new Thread(() => Application.Run(ShowToast));
                secondFormThread.Start();
            }
            catch
            {
                MessageBox.Show("There was an error trying to display an error. How embarrasing.");
            }
        }

        public static DialogResult DialogResponse(string Toast)
        {
            FormToastResponse ShowToast = new FormToastResponse(Toast);
            ShowToast.StartPosition = FormStartPosition.CenterParent;
            ShowToast.ShowDialog();
            return ShowToast.DialogResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class ProgressForm : Form
    {
        private CancellationTokenSource cts;

        public ProgressForm(CancellationTokenSource cts)
        {
            InitializeComponent();
            this.cts = cts;
        }

        public void UpdateProgress(int percent)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(UpdateProgress), percent);
                return;
            }
            progressBar1.Value = percent;
        }

       

        private void ProgressForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cancelBtn.Enabled = false;
        }
    }
}

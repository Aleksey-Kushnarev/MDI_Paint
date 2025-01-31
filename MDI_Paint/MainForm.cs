using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class MainForm : Form
    {
        public static Color currentColor = Color.Black;
        public static float currentPenSize = 1f;
        public static int standartWidth = 200;
        public static int standartHeight = 200;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAbout = new AboutBox1();
            formAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var document = new DocForm();
            document.MdiParent = this;
            document.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toRedButton_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void toYellowButton_Click(object sender, EventArgs e)
        {
            currentColor = Color.Yellow;
        }

        private void toBlueButton_Click(object sender, EventArgs e)
        {
            currentColor= Color.Blue;
        }

        private void toBlackButton_Click(object sender, EventArgs e)
        {
            currentColor= Color.Black;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
        }

        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPenSize = 1f;
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentPenSize = 5f;
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentPenSize = 10f;
        }

        private bool ValidatePosInt(int? value)
        {
            if (value != null) {
                if( value > 0) {
                    return true;
                }
            }
            return false;
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resizeWindow = new CanvasSizeForm(); 
            if (resizeWindow.ShowDialog() == DialogResult.OK)
            {
                int width = CanvasSizeForm.ResizeWidth;
                int height = CanvasSizeForm.ResizeHeight;
                var activeChild = ActiveMdiChild;
                if (activeChild == null)
                    MessageBox.Show();
                if (ValidatePosInt(width) && ValidatePosInt(height))
                {
                    var Child = l;
                    //Resize()
                }
            }

        }
       
        private void рисунокToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
                размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            
        }
    }
}

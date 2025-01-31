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
    public partial class CanvasSizeForm : Form
    {
        public static int ResizeWidth;
        public static int ResizeHeight;
        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (widthTextBox.Text != null)
            {
                bool result = int.TryParse(widthTextBox.Text, out ResizeWidth);
                bool result2 = int.TryParse(HeightTextBox.Text, out ResizeHeight);
               
            }
        }
    }
}

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
    public partial class TextForm : Form
    {
        public string text;
        public TextForm()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;

        }
    }
}

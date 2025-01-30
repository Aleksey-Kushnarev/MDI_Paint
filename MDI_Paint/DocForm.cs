using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MDI_Paint
{
    public partial class DocForm : Form

    {
        int oldX, oldY;
        Bitmap bitmap;

     
        public DocForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(this.Width, this.Height);
        }

        private void DocForm_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X; 
            oldY = e.Y;

        }

        private void DocForm_MouseMove(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left)
            {
                var graphics =  Graphics.FromImage(bitmap);
                graphics.DrawLine(new Pen(MainForm.currentColor), oldX, oldY, e.X, e.Y);
                oldY = e.Y;
                oldX = e.X;

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);

        }


    }
}

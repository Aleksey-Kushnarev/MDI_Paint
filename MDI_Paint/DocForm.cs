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
        Bitmap originalBitmap;
        private Point eraserPreviewLocation;
        public string FilePath;
        public float zoomFactor = 1f;

        public DocForm()
        {

            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            originalBitmap = (Bitmap)bitmap.Clone();
            InitializeComponent();
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

                    var graphics = Graphics.FromImage(bitmap);
                    switch (MainForm.currentTool)
                    {
                        case Tool.Pen:
                        {
                                graphics.DrawLine(new Pen(MainForm.currentColor, MainForm.currentPenSize), oldX, oldY, e.X, e.Y);
                                oldY = e.Y;
                                oldX = e.X;
                                break;
                    }
                    case Tool.Eraser:
                        {
                            graphics.FillRectangle(new SolidBrush(Control.DefaultBackColor),
                                e.X - MainForm.currentPenSize/2, e.Y - MainForm.currentPenSize/ 2,
                                MainForm.currentPenSize * 2, MainForm.currentPenSize * 2);
                            break;
                        }
                }
                
            }

            if (MainForm.currentTool == Tool.Eraser)
            {
                // Обновляем позицию квадратика при движении мыши
                eraserPreviewLocation = new Point(e.X, e.Y);
                // Перерисовываем форму, чтобы отобразить квадратик
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (MainForm.currentTool == Tool.Eraser)
            {
                int eraserSize = MainForm.currentPenSize * 2;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)),
                    eraserPreviewLocation.X - eraserSize / 2,
                    eraserPreviewLocation.Y - eraserSize / 2,
                    eraserSize, eraserSize); // Рисуем полупрозрачный квадратик
            }
            NormalizeOrig();
        
            e.Graphics.DrawImage(bitmap, 0, 0);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeCanvas(Width, Height);
        }

        public void ResizeCanvas(int newWidth, int newHeight)
        {
            Bitmap tmp_bitMap = (Bitmap)bitmap.Clone();
            bitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(tmp_bitMap, 0, 0);
            Invalidate();

        }

        public void SaveAs(string path)
        {
            bitmap.Save(path);
            FilePath = path;
        }

        public void LoadImage(string filePath)
        {
            if (originalBitmap != null)
            {
                originalBitmap.Dispose();
            }

            originalBitmap = new Bitmap(filePath);
            bitmap = (Bitmap)originalBitmap.Clone();
            zoomFactor = 1.0f;
            FilePath = filePath;
            Invalidate();
        }

        public void NormalizeOrig()
        {
            

            int newWidth = (int)(originalBitmap.Width);
            int newHeight = (int)(originalBitmap.Height);

            Bitmap tmp_bitmap = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
               
            }
            originalBitmap = (Bitmap)bitmap.Clone();
        }

        public void SetZoom(float factor)
        {
            if (originalBitmap == null || factor <= 0) return;

            zoomFactor = factor;
            

            int newWidth = (int)(originalBitmap.Width * zoomFactor);
            int newHeight = (int)(originalBitmap.Height * zoomFactor);

            bitmap?.Dispose();
            bitmap = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);
            }

            Invalidate();
        }

    }
}

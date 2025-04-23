using PluginInterface;
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
        private bool isDrawing = false;
        private Point startPoint; 
        private Rectangle shapeRect;
        public bool isModified = false;
        public bool isFilled = false;


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
            if (MainForm.currentTool == Tool.Rectangle || MainForm.currentTool == Tool.Circle || MainForm.currentTool == Tool.Smiley)
            {
                isDrawing = true;
                startPoint = e.Location;
            }
            if (MainForm.currentTool == Tool.Text)
            {
                // Запросить ввод текста
                TextForm textForm = new TextForm();
                if (textForm.ShowDialog() == DialogResult.OK)

                    if (!string.IsNullOrEmpty(textForm.text))
                    {
                        // Нарисовать текст в точке клика
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            Font font = new Font("Arial", 20); // Выбор шрифта и размера
                            Brush brush = new SolidBrush(MainForm.currentColor);
                            g.DrawString(textForm.text, font, brush, e.X, e.Y);
                        }

                        Invalidate();  // Обновить экран
                    }
            }

        }

       

        public void CancelDrawing()
        {
            isDrawing = false;
            Invalidate(); // Перерисовываем, убирая временную фигуру
        }


        private void DocForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    switch (MainForm.currentTool)
                    {
                        case Tool.Pen:
                            graphics.DrawLine(new Pen(MainForm.currentColor, MainForm.currentPenSize), oldX, oldY, e.X, e.Y);
                            oldX = e.X;
                            oldY = e.Y;
                            Invalidate();
                            break;

                        case Tool.Eraser:
                            graphics.DrawLine(new Pen(Control.DefaultBackColor, MainForm.currentPenSize),
                                oldX, oldY, e.X, e.Y);

                            Invalidate();
                            break;
                    }
                }

                if (isDrawing && (MainForm.currentTool == Tool.Rectangle || MainForm.currentTool == Tool.Circle || MainForm.currentTool == Tool.Smiley))
                {
                    shapeRect = new Rectangle(
                        Math.Min(startPoint.X, e.X),
                        Math.Min(startPoint.Y, e.Y),
                        Math.Abs(e.X - startPoint.X),
                        Math.Abs(e.Y - startPoint.Y)
                    );
                    Invalidate(); // Перерисовываем экран, но не меняем bitmap
                }
                isModified = true;

            }
            if (MainForm.currentTool == Tool.Eraser)
            {
                // Обновляем позицию квадратика при движении мыши
                eraserPreviewLocation = new Point(e.X, e.Y);
                isModified = true;
                // Перерисовываем форму, чтобы отобразить квадратик
                Invalidate();
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

             // Рисуем сохранённое изображение

            if (isDrawing)
            {
                using (Pen pen = new Pen(MainForm.currentColor, MainForm.currentPenSize))
                {
                    if (MainForm.currentTool == Tool.Rectangle)
                        e.Graphics.DrawRectangle(pen, shapeRect);
                    else if (MainForm.currentTool == Tool.Circle)
                        e.Graphics.DrawEllipse(pen, shapeRect);
                    else if (MainForm.currentTool == Tool.Smiley)
                    {
                        DrawSmiley(e.Graphics, shapeRect);

                    }
                }
            }
            NormalizeOrig();
            e.Graphics.DrawImage(bitmap, 0, 0);
            // Отображение курсора ластика
            if (MainForm.currentTool == Tool.Eraser)
            {
                int eraserSize = MainForm.currentPenSize * 2;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)),
                    eraserPreviewLocation.X - eraserSize / 2,
                    eraserPreviewLocation.Y - eraserSize / 2,
                    eraserSize, eraserSize);
            }
            
        }

        private void DrawSmiley(Graphics g, Rectangle rect)
        {
            Pen pen = new Pen(MainForm.currentColor, MainForm.currentPenSize);
            Brush brush = new SolidBrush(MainForm.currentColor);
            Brush eyeBrush = new SolidBrush(Color.Black);
            Pen penMouth = new Pen(Color.Black, MainForm.currentPenSize);
            // Голова
            if (isFilled) g.FillEllipse(brush, rect);

            g.DrawEllipse(pen, rect);

            // Глаза
            int eyeWidth = rect.Width / 6;
            int eyeHeight = rect.Height / 6;
            int eyeOffsetX = rect.Width / 4;
            int eyeOffsetY = rect.Height / 4;
            if (isFilled)
            {
                g.FillEllipse(eyeBrush, rect.X + eyeOffsetX, rect.Y + eyeOffsetY, eyeWidth, eyeHeight);
                g.FillEllipse(eyeBrush, rect.X + rect.Width - eyeOffsetX - eyeWidth, rect.Y + eyeOffsetY, eyeWidth, eyeHeight);
            }
            else
            {
                g.DrawEllipse(pen, rect.X + eyeOffsetX, rect.Y + eyeOffsetY, eyeWidth, eyeHeight);
                g.DrawEllipse(pen, rect.X + rect.Width - eyeOffsetX - eyeWidth, rect.Y + eyeOffsetY, eyeWidth, eyeHeight);
            }
            // Рот
            int mouthWidth = Math.Max(rect.Width / 2, 5);  // Убедитесь, что ширина рта не меньше 1
            int mouthHeight = Math.Max(rect.Height / 4, 5); // Убедитесь, что высота рта не меньше 1
            int mouthX = rect.X + (rect.Width - mouthWidth) / 2;
            int mouthY = rect.Y + rect.Height / 2;

            if (isFilled)
            {
                g.DrawArc(penMouth, mouthX, mouthY, mouthWidth, mouthHeight, 0, 180);
            }
            else { g.DrawArc(pen, mouthX, mouthY, mouthWidth, mouthHeight, 0, 180); }
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
            isModified = false;
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
            isModified = false;
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

        private void DocForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && (MainForm.currentTool == Tool.Rectangle || MainForm.currentTool == Tool.Circle || MainForm.currentTool == Tool.Smiley))
            {
                isDrawing = false;
                Console.WriteLine("dasd");
                // Сохраняем фигуру в bitmap
                Graphics g = Graphics.FromImage(bitmap);
                Pen pen = new Pen(MainForm.currentColor, MainForm.currentPenSize);
                if (MainForm.currentTool == Tool.Rectangle)
                    g.DrawRectangle(pen, shapeRect);
                else if (MainForm.currentTool == Tool.Circle)
                    g.DrawEllipse(pen, shapeRect);
                else if (MainForm.currentTool == Tool.Smiley)
                {
                    DrawSmiley(g, shapeRect);
                }

                Invalidate(); // Перерисовываем холст
            }
        }

        public void ApplyFilter(IPlugin plugin)
        {
            if (bitmap == null || plugin == null) return;

            plugin.Apply(bitmap);   // Изменяет изображение
            Invalidate();           // Обновляем отображение
            isModified = true;
            Refresh();
        }

        private void FillArea(Point point, Color newColor)
        {
            Color oldColor = bitmap.GetPixel(point.X, point.Y);

            if (oldColor.ToArgb() == newColor.ToArgb()) return;

            Queue<Point> pixels = new Queue<Point>();
            pixels.Enqueue(point);

            while (pixels.Count > 0)
            {
                Point p = pixels.Dequeue();

                if (p.X < 0 || p.X >= bitmap.Width || p.Y < 0 || p.Y >= bitmap.Height)
                    continue;

                if (bitmap.GetPixel(p.X, p.Y) == oldColor)
                {
                    bitmap.SetPixel(p.X, p.Y, newColor);

                    // Добавляем смежные пиксели в очередь
                    pixels.Enqueue(new Point(p.X + 1, p.Y));
                    pixels.Enqueue(new Point(p.X - 1, p.Y));
                    pixels.Enqueue(new Point(p.X, p.Y + 1));
                    pixels.Enqueue(new Point(p.X, p.Y - 1));
                }
            }

            Invalidate();
        }

        private void DocForm_MouseClick(object sender, MouseEventArgs e)
        {
            // Проверяем, выбран ли инструмент заливки
            if (MainForm.currentTool == Tool.Fill)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Цвет заливки, который выбран пользователем
                    Color fillColor = MainForm.currentColor;

                    // Применение заливки
                    FillArea(e.Location, MainForm.currentColor);

                    Invalidate(); // Перерисовываем холст
                }
            }
        }

        private void DocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                var result = MessageBox.Show("Хотите сохранить изменения?", "Сохранить изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var dc = ParentForm as MainForm;
                    if (dc != null)
                    {
                        dc.сохранитьToolStripMenuItem_Click(sender, e);
                    }
                }
            }
        }

        public void SetZoom(float factor)
        {
            if (originalBitmap == null || factor <= 0.3 || factor > 2.5) return;

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

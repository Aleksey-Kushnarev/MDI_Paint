﻿using System;
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
        public static Tool currentTool = Tool.Pen;
        public static int currentPenSize = 1;
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
            currentPenSize = 1;
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentPenSize = 5;
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentPenSize = 10;
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
                {
                    MessageBox.Show("Не выбрано окно");
                    return;
                }
                if (ValidatePosInt(width) && ValidatePosInt(height))
                {
                    if (activeChild is DocForm docForm) 
                    {
                        docForm.Width = width;
                        docForm.Height = height;
                    }
                }
            }

        }
       
        private void рисунокToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
                размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            
        }

        private void brushButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pen;
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocForm;

            if (d != null)
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg, *.jpeg)|*.jpg;*.jpeg|BMP Image (*.bmp)|*.bmp|All Files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    d.SaveAs(dlg.FileName);
                }
            }
        }

        private void файлToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            var dc = ActiveMdiChild as DocForm;
            сохранитьКакToolStripMenuItem.Enabled= !(dc == null || !dc.isModified);

            сохранитьToolStripMenuItem.Enabled = !(dc == null || !dc.isModified);
        }
            
        public void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocForm;

            if (d != null)
            {
                if (string.IsNullOrEmpty(d.FilePath))
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    d.SaveAs(d.FilePath);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Filter = "JPEG Image (*.jpg; *.jpeg)|*.jpg;*.jpeg|BMP Image (*.bmp)|*.bmp|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            { 
                    var newDoc = new DocForm();
                    newDoc.LoadImage(dlg.FileName);
                    newDoc.MdiParent = this;
                    newDoc.Show();
                
            }
        }

        private void zoomPlus_Click(object sender, EventArgs e)
        {

            var d = ActiveMdiChild as DocForm;
            if (d != null && d.zoomFactor > 0.1f && d.zoomFactor < 2.5)
            {
                d.SetZoom(d.zoomFactor * 1.2f); // Увеличиваем на 20%
            }
        }

        private void zoomMinus_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocForm;
            if (d != null && d.zoomFactor > 0.5f && d.zoomFactor < 2.5)
            {
                d.SetZoom(d.zoomFactor / 1.2f); // Уменьшаем на 20%
            }

        }

        private void circle_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Circle;
            var activeChild = ActiveMdiChild as DocForm;
            if (activeChild != null)
            {
                activeChild.CancelDrawing(); // Отменяем незавершенное рисование
            }
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Rectangle;
            var activeChild = ActiveMdiChild as DocForm;
            if (activeChild != null)
            {
                activeChild.CancelDrawing(); // Отменяем незавершенное рисование
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            currentTool = Tool.Fill;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Smiley;
            
            var activeChild = ActiveMdiChild as DocForm;
            activeChild.isFilled = true;
            if (activeChild != null)
            {
                activeChild.CancelDrawing(); // Отменяем незавершенное рисование
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Smiley;

            var activeChild = ActiveMdiChild as DocForm;
            activeChild.isFilled = false;
            if (activeChild != null)
            {
                activeChild.CancelDrawing(); // Отменяем незавершенное рисование
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Text;
        }
    }
}

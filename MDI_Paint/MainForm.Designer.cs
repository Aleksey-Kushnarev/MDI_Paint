﻿namespace MDI_Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерХолстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toRedButton = new System.Windows.Forms.ToolStripButton();
            this.toYellowButton = new System.Windows.Forms.ToolStripButton();
            this.toBlueButton = new System.Windows.Forms.ToolStripButton();
            this.toBlackButton = new System.Windows.Forms.ToolStripButton();
            this.chooseColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.brushButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.circle = new System.Windows.Forms.ToolStripButton();
            this.rectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomPlus = new System.Windows.Forms.ToolStripButton();
            this.zoomMinus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.плагиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.filtersToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.плагиныToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.DropDownOpened += new System.EventHandler(this.файлToolStripMenuItem_DropDownOpened);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерХолстаToolStripMenuItem});
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            this.рисунокToolStripMenuItem.DropDownOpened += new System.EventHandler(this.рисунокToolStripMenuItem_DropDownOpened);
            // 
            // размерХолстаToolStripMenuItem
            // 
            this.размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            this.размерХолстаToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.размерХолстаToolStripMenuItem.Text = "Размер холста";
            this.размерХолстаToolStripMenuItem.Click += new System.EventHandler(this.размерХолстаToolStripMenuItem_Click);
            // 
            // filtersToolStrip
            // 
            this.filtersToolStrip.Name = "filtersToolStrip";
            this.filtersToolStrip.Size = new System.Drawing.Size(69, 20);
            this.filtersToolStrip.Text = "Фильтры";
            this.filtersToolStrip.DropDownOpened += new System.EventHandler(this.filtersToolStrip_DropDownOpened);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toRedButton,
            this.toYellowButton,
            this.toBlueButton,
            this.toBlackButton,
            this.chooseColor,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.brushButton,
            this.eraserButton,
            this.circle,
            this.rectangle,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.zoomPlus,
            this.zoomMinus,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toRedButton
            // 
            this.toRedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toRedButton.Image = ((System.Drawing.Image)(resources.GetObject("toRedButton.Image")));
            this.toRedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toRedButton.Name = "toRedButton";
            this.toRedButton.Size = new System.Drawing.Size(23, 22);
            this.toRedButton.Text = "toolStripButton1";
            this.toRedButton.Click += new System.EventHandler(this.toRedButton_Click);
            // 
            // toYellowButton
            // 
            this.toYellowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toYellowButton.Image = ((System.Drawing.Image)(resources.GetObject("toYellowButton.Image")));
            this.toYellowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toYellowButton.Name = "toYellowButton";
            this.toYellowButton.Size = new System.Drawing.Size(23, 22);
            this.toYellowButton.Text = "toolStripButton2";
            this.toYellowButton.Click += new System.EventHandler(this.toYellowButton_Click);
            // 
            // toBlueButton
            // 
            this.toBlueButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toBlueButton.Image = ((System.Drawing.Image)(resources.GetObject("toBlueButton.Image")));
            this.toBlueButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toBlueButton.Name = "toBlueButton";
            this.toBlueButton.Size = new System.Drawing.Size(23, 22);
            this.toBlueButton.Text = "toolStripButton3";
            this.toBlueButton.Click += new System.EventHandler(this.toBlueButton_Click);
            // 
            // toBlackButton
            // 
            this.toBlackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toBlackButton.Image = ((System.Drawing.Image)(resources.GetObject("toBlackButton.Image")));
            this.toBlackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toBlackButton.Name = "toBlackButton";
            this.toBlackButton.Size = new System.Drawing.Size(23, 22);
            this.toBlackButton.Text = "toolStripButton4";
            this.toBlackButton.Click += new System.EventHandler(this.toBlackButton_Click);
            // 
            // chooseColor
            // 
            this.chooseColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chooseColor.Image = ((System.Drawing.Image)(resources.GetObject("chooseColor.Image")));
            this.chooseColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chooseColor.Name = "chooseColor";
            this.chooseColor.Size = new System.Drawing.Size(23, 22);
            this.chooseColor.Text = "toolStripButton1";
            this.chooseColor.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pxToolStripMenuItem,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem.Text = "1px";
            this.pxToolStripMenuItem.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem1.Text = "5px";
            this.pxToolStripMenuItem1.Click += new System.EventHandler(this.pxToolStripMenuItem1_Click);
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem2.Text = "10px";
            this.pxToolStripMenuItem2.Click += new System.EventHandler(this.pxToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // brushButton
            // 
            this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushButton.Image = ((System.Drawing.Image)(resources.GetObject("brushButton.Image")));
            this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushButton.Name = "brushButton";
            this.brushButton.Size = new System.Drawing.Size(23, 22);
            this.brushButton.Text = "toolStripButton1";
            this.brushButton.Click += new System.EventHandler(this.brushButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(23, 22);
            this.eraserButton.Text = "toolStripButton2";
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // circle
            // 
            this.circle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circle.Image = ((System.Drawing.Image)(resources.GetObject("circle.Image")));
            this.circle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(23, 22);
            this.circle.Text = "toolStripButton3";
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // rectangle
            // 
            this.rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangle.Image = ((System.Drawing.Image)(resources.GetObject("rectangle.Image")));
            this.rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(23, 22);
            this.rectangle.Text = "toolStripButton4";
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomPlus
            // 
            this.zoomPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomPlus.Image = ((System.Drawing.Image)(resources.GetObject("zoomPlus.Image")));
            this.zoomPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomPlus.Name = "zoomPlus";
            this.zoomPlus.Size = new System.Drawing.Size(23, 22);
            this.zoomPlus.Text = "toolStripButton1";
            this.zoomPlus.Click += new System.EventHandler(this.zoomPlus_Click);
            // 
            // zoomMinus
            // 
            this.zoomMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomMinus.Image = ((System.Drawing.Image)(resources.GetObject("zoomMinus.Image")));
            this.zoomMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomMinus.Name = "zoomMinus";
            this.zoomMinus.Size = new System.Drawing.Size(23, 22);
            this.zoomMinus.Text = "toolStripButton2";
            this.zoomMinus.Click += new System.EventHandler(this.zoomMinus_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // плагиныToolStripMenuItem
            // 
            this.плагиныToolStripMenuItem.Name = "плагиныToolStripMenuItem";
            this.плагиныToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.плагиныToolStripMenuItem.Text = "Плагины";
            this.плагиныToolStripMenuItem.Click += new System.EventHandler(this.плагиныToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toRedButton;
        private System.Windows.Forms.ToolStripButton toYellowButton;
        private System.Windows.Forms.ToolStripButton toBlueButton;
        private System.Windows.Forms.ToolStripButton toBlackButton;
        private System.Windows.Forms.ToolStripButton chooseColor;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерХолстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton brushButton;
        private System.Windows.Forms.ToolStripButton eraserButton;
        private System.Windows.Forms.ToolStripButton circle;
        private System.Windows.Forms.ToolStripButton rectangle;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton zoomPlus;
        private System.Windows.Forms.ToolStripButton zoomMinus;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStrip;
        private System.Windows.Forms.ToolStripMenuItem плагиныToolStripMenuItem;
    }
}


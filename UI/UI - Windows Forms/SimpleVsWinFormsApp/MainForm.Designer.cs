﻿namespace SimpleVsWinFormsApp
{
   partial class MainForm
   {
      /// <summary>
      /// Требуется переменная конструктора.
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
      /// Обязательный метод для поддержки конструктора - не изменяйте
      /// содержимое данного метода при помощи редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mainMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainMenuStrip
         // 
         this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this.mainMenuStrip.Name = "mainMenuStrip";
         this.mainMenuStrip.Size = new System.Drawing.Size(284, 24);
         this.mainMenuStrip.TabIndex = 0;
         this.mainMenuStrip.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.mainMenuStrip);
         this.MainMenuStrip = this.mainMenuStrip;
         this.Name = "MainForm";
         this.Opacity = 0.8D;
         this.Text = "Main window";
         this.Activated += new System.EventHandler(this.MainForm_Activated);
         this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.mainMenuStrip.ResumeLayout(false);
         this.mainMenuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
   }
}


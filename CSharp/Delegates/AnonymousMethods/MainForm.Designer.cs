﻿namespace AnonymousMethods
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpdateTextBoxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdateTextBoxt
            // 
            this.UpdateTextBoxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateTextBoxt.Location = new System.Drawing.Point(12, 62);
            this.UpdateTextBoxt.Multiline = true;
            this.UpdateTextBoxt.Name = "UpdateTextBoxt";
            this.UpdateTextBoxt.ReadOnly = true;
            this.UpdateTextBoxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.UpdateTextBoxt.Size = new System.Drawing.Size(260, 411);
            this.UpdateTextBoxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move and click the mouse around the window";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateTextBoxt);
            this.Name = "Form1";
            this.Text = "Anonymous Methods";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UpdateTextBoxt;
        private System.Windows.Forms.Label label1;
    }
}


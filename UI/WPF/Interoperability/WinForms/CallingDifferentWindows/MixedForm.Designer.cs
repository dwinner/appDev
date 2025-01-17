﻿namespace CallingDifferentWindows
{
	partial class MixedForm
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
			this.WpfHostFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.WinFormContentButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// WpfHostFlowLayoutPanel
			// 
			this.WpfHostFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WpfHostFlowLayoutPanel.Location = new System.Drawing.Point(13, 42);
			this.WpfHostFlowLayoutPanel.Name = "WpfHostFlowLayoutPanel";
			this.WpfHostFlowLayoutPanel.Size = new System.Drawing.Size(259, 207);
			this.WpfHostFlowLayoutPanel.TabIndex = 0;
			// 
			// WinFormContentButton
			// 
			this.WinFormContentButton.Location = new System.Drawing.Point(13, 13);
			this.WinFormContentButton.Name = "WinFormContentButton";
			this.WinFormContentButton.Size = new System.Drawing.Size(75, 23);
			this.WinFormContentButton.TabIndex = 1;
			this.WinFormContentButton.Text = "WinForms Content";
			this.WinFormContentButton.UseVisualStyleBackColor = true;
			this.WinFormContentButton.Click += new System.EventHandler(this.OnHostWpfContent);
			// 
			// MixedForm
			// 
			this.AcceptButton = this.WinFormContentButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.WinFormContentButton);
			this.Controls.Add(this.WpfHostFlowLayoutPanel);
			this.Name = "MixedForm";
			this.Text = "Mixed form";
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel WpfHostFlowLayoutPanel;
		private System.Windows.Forms.Button WinFormContentButton;
	}
}


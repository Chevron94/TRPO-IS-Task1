﻿namespace ServerGUI
{
    partial class Form1
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
            this.MessageLog = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ServerStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageLog
            // 
            this.MessageLog.FormattingEnabled = true;
            this.MessageLog.Location = new System.Drawing.Point(0, 26);
            this.MessageLog.Name = "MessageLog";
            this.MessageLog.Size = new System.Drawing.Size(283, 238);
            this.MessageLog.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerStart,
            this.ServerStop});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ServerStart
            // 
            this.ServerStart.Name = "ServerStart";
            this.ServerStart.Size = new System.Drawing.Size(43, 20);
            this.ServerStart.Text = "Start";
            this.ServerStart.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // ServerStop
            // 
            this.ServerStop.Enabled = false;
            this.ServerStop.Name = "ServerStop";
            this.ServerStop.Size = new System.Drawing.Size(43, 20);
            this.ServerStop.Text = "Stop";
            this.ServerStop.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MessageLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MessageLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ServerStart;
        private System.Windows.Forms.ToolStripMenuItem ServerStop;
    }
}


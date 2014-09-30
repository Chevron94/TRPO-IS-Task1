namespace ClientGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConnectClient = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectClient = new System.Windows.Forms.ToolStripMenuItem();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageLog = new System.Windows.Forms.ListBox();
            this.MessageInput = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectClient,
            this.DisconnectClient});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConnectClient
            // 
            this.ConnectClient.Name = "ConnectClient";
            this.ConnectClient.Size = new System.Drawing.Size(64, 20);
            this.ConnectClient.Text = "Connect";
            this.ConnectClient.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // DisconnectClient
            // 
            this.DisconnectClient.Enabled = false;
            this.DisconnectClient.Name = "DisconnectClient";
            this.DisconnectClient.Size = new System.Drawing.Size(78, 20);
            this.DisconnectClient.Text = "Disconnect";
            this.DisconnectClient.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(95, 227);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageLog
            // 
            this.MessageLog.FormattingEnabled = true;
            this.MessageLog.Location = new System.Drawing.Point(0, 27);
            this.MessageLog.Name = "MessageLog";
            this.MessageLog.Size = new System.Drawing.Size(284, 173);
            this.MessageLog.TabIndex = 2;
            // 
            // MessageInput
            // 
            this.MessageInput.Location = new System.Drawing.Point(0, 201);
            this.MessageInput.Name = "MessageInput";
            this.MessageInput.Size = new System.Drawing.Size(284, 20);
            this.MessageInput.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MessageInput);
            this.Controls.Add(this.MessageLog);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConnectClient;
        private System.Windows.Forms.ToolStripMenuItem DisconnectClient;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListBox MessageLog;
        private System.Windows.Forms.TextBox MessageInput;
    }
}


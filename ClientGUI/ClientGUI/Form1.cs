using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Client = new Client(6008,ref MessageLog);
        }
        Client Client;
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Client.Connect();
                ConnectClient.Enabled = false;
                DisconnectClient.Enabled = true;
            }
            catch (Exception)
            { MessageBox.Show("Server not responding"); }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Client.SendMessage(MessageInput.Text);
            MessageInput.Text = "";
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            ConnectClient.Enabled = true;
            DisconnectClient.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Client.Disconnect();
        }
    }
}

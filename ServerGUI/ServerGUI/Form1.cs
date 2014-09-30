﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerGUI
{
    public partial class Form1 : Form
    {
        Server Server;
        public Form1()
        {
            InitializeComponent();
            Server = new Server(6008,ref MessageLog);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Server.Start();
            ServerStart.Enabled = false;
            ServerStop.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Server.Stop();
            ServerStart.Enabled = true;
            ServerStop.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.Stop();
        }
    }
}

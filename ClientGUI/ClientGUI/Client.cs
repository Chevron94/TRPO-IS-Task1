using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ClientGUI
{
    class Client
    {
        TcpClient TClient;
        int Port;
        StreamReader Reader;
        StreamWriter Writer;
        ListBox lb;
        Thread WaitMessage;
        bool stop;

        public Client(int port, ref ListBox _lb)
        {
            Port = port;
            TClient = new TcpClient();
            lb = _lb;
        }

        public void Connect()
        {
            TClient.Connect("localhost", Port);
            stop = false;
            var Stream = TClient.GetStream();
            Reader = new StreamReader(Stream);
            Writer = new StreamWriter(Stream);
            Writer.AutoFlush = true;
            WaitMessage = new Thread(new ThreadStart(ThreadClient));
            WaitMessage.Start();
        }

        public void Disconnect()
        {
            if (TClient.Connected)
            {
                stop = true;
                WaitMessage.Abort();
                TClient.Close();
            }
        }

        void ThreadClient()
        {
            while (!stop)
            {
                try
                {
                    string Message = Reader.ReadLine();
                    lb.Invoke(new Action(() => lb.Items.Add(Message)));
                }
                catch (Exception)
                { stop = true; }
            }
        }

        public void SendMessage(string Message)
        {
            Writer.WriteLine(Message);
        }
    }
}

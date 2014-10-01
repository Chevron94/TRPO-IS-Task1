using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
        string IP;
        string NickName;
        StreamReader Reader;
        StreamWriter Writer;
        ListBox lb;
        Thread WaitMessage;
       // bool stop;
        public bool CONNECTED;
        public Client(string ip, int port, string nickname, ref ListBox _lb)
        {
            Port = port;
            IP = ip;
            TClient = new TcpClient();
            lb = _lb;
            NickName = nickname;
            CONNECTED = false;
        }

        public void Connect()
        {
            IPAddress Address;
            if (IPAddress.TryParse(IP, out Address))
            {
                TClient.Connect(Address, Port);
                // stop = false;
                var Stream = TClient.GetStream();
                Reader = new StreamReader(Stream);
                Writer = new StreamWriter(Stream);
                Writer.AutoFlush = true;
                CONNECTED = true;
                WaitMessage = new Thread(new ThreadStart(ThreadClient));
                Writer.WriteLine(NickName);
                WaitMessage.Start();
            }
            else MessageBox.Show("WRONG IP!");
        }

        public void Disconnect()
        {
            if (TClient.Connected)
            {
              //  stop = true;
                CONNECTED = false;
                WaitMessage.Abort();
                TClient.Close();
            }
        }

        void ThreadClient()
        {
            while (TClient.Connected)
            {
                try
                {
                    string Message = Reader.ReadLine();
                    if (Message == "")
                    {
                        Message = "SERVER SHUTDOWN!";
                        lb.Invoke(new Action(() => lb.Items.Add(Message)));
                        Disconnect();
                    }
                    else
                    {
                        Message = "[" + DateTime.Now.ToString() + "] " + Message;
                        lb.Invoke(new Action(() => lb.Items.Add(Message)));
                    }
                }
                catch (Exception)
                { Disconnect(); }
            }
        }

        public void SendMessage(string Message)
        {
            Writer.WriteLine(Message);
        }
    }
}

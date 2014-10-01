using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace ServerGUI
{
    class Server
    {
        TcpListener Listner;
        static ListBox lb;
        static ArrayList Writers = new ArrayList();
        static bool stop;
        static object locker = new object();
        static string Message;
        Thread Accepting;
        public Server(int Port, ref ListBox _lb)
        {
            Listner = new TcpListener(Port);
            lb = _lb;
            stop = true;
        }
        public void Start()
        {
            Listner.Start();
            stop = false;
            Accepting = new Thread(new ThreadStart(Start_Accept));
            Accepting.Start();
        }

        void Start_Accept()
        {
            while(!stop)
            {
                try
                {
                    TcpClient Client = Listner.AcceptTcpClient();
                    Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                    Thread.Start(Client);
                }
                catch (SocketException)
                { }
            }
        }

        public void Stop()
        {
            if (Listner != null)
            {
                stop = true;
                //Accepting.Abort();
                SendMessages("");
                Listner.Stop();
            }
        }

       static void SendMessages(string Message)
        {
            StreamWriter writer;
            for (int i = 0; i < Writers.Count; i++)
            {
                writer = (StreamWriter)Writers[i];
                try
                {
                    writer.WriteLine(Message);
                }
                catch (Exception)
                { }
            }
            if (Message == "")
                Message = "SERVER SHUTDOWN!";
            Message = "[" + DateTime.Now.ToString() + "] " + Message;
            lb.Invoke(new Action(() => lb.Items.Add(Message)));
        }

        static void ClientThread(Object StateInfo)
        {
            TcpClient Client = (TcpClient)StateInfo;
            var stream = Client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            string NickName = reader.ReadLine();
            SendMessages("\""+NickName+"\"" + " CONNECTED!");
            Writers.Add(writer);
            writer.AutoFlush = true;
            while (Client.Connected)
            {
                try
                {
                    Message = reader.ReadLine();
                    if (Message == null)
                        Message = "\"" + NickName + "\"" + " DISCONNECTED!"; 
                    SendMessages(Message);
                }
                catch (Exception)
                { }
            }
        }

    }
}

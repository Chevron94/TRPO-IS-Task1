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
                Listner.Stop();
            }
        }


        static void ClientThread(Object StateInfo)
        {
            TcpClient Client = (TcpClient)StateInfo;
            var stream = Client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            Writers.Add(writer);
            writer.AutoFlush = true;
            while (Client.Connected)
            {
                try
                {
                    Message = reader.ReadLine();
                    for (int i = 0; i < Writers.Count; i++)
                    {
                        writer = (StreamWriter)Writers[i];
                        writer.WriteLine(Message);
                    }
                    lb.Invoke(new Action(() => lb.Items.Add(Message)));
                }
                catch (Exception)
                { }
            }
        }

    }
}

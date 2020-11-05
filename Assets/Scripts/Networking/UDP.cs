using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Networking
{
    [System.Serializable]
    public class UDP
    {
        #region Singleton
        
        private static UDP instance;
        
        public static UDP Instance
        {
            get
            {
                if (instance == null)
                    instance = new UDP();
                return instance;
            }
        }

        #endregion

        private const int listenPort = 11100;
        private const string serverIP = "192.168.8.100";

        public static string logText;

        public static Action<byte[]> InterpreteData;

        private UDP()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            Task.Run(() => Listen(listener, groupEP));
        }

        private void WriteToLog(string text)
        {
            Debug.Log(text);
            logText += text + "\n";
        }

        public static void SendMessage(byte[] bytes, string iP = serverIP)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse(iP);
            IPEndPoint ep = new IPEndPoint(broadcast, listenPort);

            s.SendTo(bytes, ep);
        }

        private void Listen(UdpClient listener, IPEndPoint groupEP)
        {
            WriteToLog("Waiting for broadcast");
            while (true)
            {
                try
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    WriteToLog($"Received broadcast from {groupEP} :");
                    InterpreteData.Invoke(bytes);
                }
                catch (Exception e)
                {
                    WriteToLog(e.ToString());
                    break;
                }
            }
        }
    }
}

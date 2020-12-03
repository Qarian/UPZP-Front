using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace Networking
{
    internal class TCP : Connection
    {
        private TcpClient client;
        private NetworkStream stream;
        
        public TCP(string targetIP, int targetPort) : base(targetIP, targetPort)
        {
        }

        public override void Initialize()
        {
            try
            {
                client = new TcpClient(targetIP, targetPort);
                stream = client.GetStream();
                active = true;
                Task.Run(Listen);
                Debug.Log("Connected using TCP");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                Debug.LogError(e.ToString());
            }
        }

        public override void SendData(byte[] data)
        {
            stream.Write(data, 0, data.Length);
            stream.Flush();
            Debug.Log("Send");
        }

        public override void Stop()
        {
            client.Close();
            active = false;
        }

        private void Listen()
        {
            Debug.Log("TCP waiting for message");
            while (true)
            {
                try
                {
                    if (!active)
                        return;
                    byte[] data = new byte[500];
                    stream.Read(data, 0, data.Length);
                    InterpreteData.Invoke(new Message(data));
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                    break;
                }
            }
        }
    }
}
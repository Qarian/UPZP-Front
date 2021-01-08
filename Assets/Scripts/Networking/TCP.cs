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
                Task.Run(Listen);
                active = true;
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
            if (client != null)
                client.Close();
            active = false;
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    if (!client.Connected)
                        return;
                    byte[] data = new byte[1000];
                    stream.Read(data, 0, data.Length);
                    Message message = new Message(data);
                    if (message.Version == 0)
                        break;
                    InterpreteData?.Invoke(message);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                    //break;
                }
            }
        }
    }
}
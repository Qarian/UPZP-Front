using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace Networking
{
    [System.Serializable]
    internal class UDP : Connection
    {
        protected int listeningPort;
        
        public struct UdpState
        {
            public UdpClient Client;
            public IPEndPoint EndPoint;
        }

        private UdpState state;
        private Socket socket;

        public UDP(string targetIP, int targetPort, int listeningPort) : base(targetIP, targetPort)
        {
            this.listeningPort = listeningPort;
        }

        public override void Initialize()
        {
            if (active)
                return;

            state = new UdpState
            {
                Client = new UdpClient(listeningPort),
                EndPoint = new IPEndPoint(IPAddress.Any, listeningPort)
            };

            ReceiveMessages();
            active = true;
            Debug.Log("Waiting for UDP broadcast");
        }

        public override void Stop()
        {
            try
            {
                active = false;
                state.Client.Close();
            }
            catch
            {
                // ignored
            }
        }

        public override void SendData(byte[] data)
        {
            if (socket == null)
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse(targetIP);
            IPEndPoint ep = new IPEndPoint(broadcast, targetPort);

            socket.SendTo(data, ep);
        }
        
        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] data = state.Client.EndReceive(ar, ref state.EndPoint);
            
            Debug.Log($"Received broadcast from {state.EndPoint}");

            try
            {
                InterpreteData.Invoke(new Message(data));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
            if (active)
                ReceiveMessages();
        }

        public void ReceiveMessages()
        {
            state.Client.BeginReceive(ReceiveCallback, new object());
        }
    }
}

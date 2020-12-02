using System;
using Unity.Collections;
using UnityEngine;

namespace Networking
{
    internal abstract class Connection
    {
        public Action<Message> InterpreteData;
        
        public bool active { get; protected set; }

        protected string targetIP = "192.168.8.100";
        protected int targetPort = 11100;

        protected Connection(string targetIP, int targetPort)
        {
            this.targetIP = targetIP;
            this.targetPort = targetPort;
        }
        
        public abstract void Initialize();

        public abstract void SendData(byte[] data);

        public abstract void Stop();
    }
}
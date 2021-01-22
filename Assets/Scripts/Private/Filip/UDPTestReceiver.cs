using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPTestReceiver : MonoBehaviour {

    public int port;

    Thread receiverThread;
    UdpClient client;
    
    public string lastReceivedPacket = "";
    public string allReceivedPackets = "";
    
    public void Start() {
        init();
    }
    
    private void init() {
        port = 11100;
        receiverThread = new Thread(
            new ThreadStart(ReceiveData)) {
            IsBackground = true
        };
        receiverThread.Start();
    }
    
    private void ReceiveData() {
        client = new UdpClient(port);
        while (true) {
            try {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref endPoint);
                string text = Encoding.UTF8.GetString(data);
                print(">> " + text);
                lastReceivedPacket = text;
                allReceivedPackets = allReceivedPackets + text;
            }
            catch (Exception err) {
                print(err.ToString());
            }
        }
    }

    void OnDisable() {
        if (receiverThread != null) {
            receiverThread.Abort();
        }
        client.Close();
    }
    
    void OnGUI() {
        Rect rectObj = new Rect(40, 40, 190, 380);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "Receiver test:" +
                         "\nIP: 127.0.0.1" +
                         "\nPort: " + port + " \n" +
                         "\nLast received: \n" + lastReceivedPacket // +
                         // "\n\nAll received: \n" + allReceivedPackets
                         , style);
    }

}
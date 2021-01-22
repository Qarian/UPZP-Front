using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPTestSender : MonoBehaviour{
    
    private string IP;
    public int port;

    IPEndPoint endPoint;
    UdpClient client;
    
    string message = "";
    
    public void Start() {
        init();
    }

    public void init() {
        
        IP = "127.0.0.1";
        port = 11100;
        
        endPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
        
        print("Test data being sent to: " + IP + " : " + port);
        //sendString("test" + "\n");

    }
    
    private void sendString(string message) {
        try {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, endPoint);
        }   
        catch (Exception ex) {
            print(ex.ToString());
        }
    }
    
    void OnGUI() {
        Rect rectObj = new Rect(40, 360, 190, 380);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "Sender test: " +
                         "\nIP: 127.0.0.1" +
                         "\nPort: " + port
                         , style);
        
        message = GUI.TextField(new Rect(40, 420, 140, 20), message);
        if (GUI.Button(new Rect(87, 445, 50, 25), "SEND")) {
            sendString(message + "\n");
        }
    }

}
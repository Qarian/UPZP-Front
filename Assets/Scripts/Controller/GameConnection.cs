using FlatBuffers;
using mainServer.schemas.FGameStarted;
using Networking;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

internal class GameConnection : Controller
{
    private Coroutine cor;

    private Thread first;
    
    public void OnOpenScene(string sceneName)
    {
        if (sceneName == "Gra")
            first.Abort();
    }

    public void Receive(Message message)
    {
        if (message.Version != 9)
            return;

        var buffer = new ByteBuffer(message.Payload);
        var game = FGameStarted.GetRootAsFGameStarted(buffer);
        string targetIP = game.Ip;
        int targetPort = game.Port;
        
        Communication.InitializeGame(targetIP, targetPort);
        Debug.Log("Connecting...");

        first = new Thread(Send);
        first.Start();
    }

    public static void Send()
    {
        FlatBufferBuilder biuld = new FlatBufferBuilder(200);
        var offset = Upzp.PlayerInput.Input.CreateInput(biuld, 1, 0, false, 0, false);
        Upzp.PlayerInput.Input.FinishInputBuffer(biuld, offset);
        var mess = biuld.SizedByteArray();

        Communication.SendToGame(new Message(mess, 101));
        Thread.Sleep(100);
        Send();
    }
    
}
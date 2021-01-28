using FlatBuffers;
using mainServer.schemas.FGameStarted;
using Networking;
using System;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;
using UnityEngine.SceneManagement;
using Mapbox.Examples;
using System.Runtime.InteropServices;

internal class GameConnection : Controller
{
    public void OnOpenScene(string sceneName)
    {

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
        FlatBufferBuilder biuld = new FlatBufferBuilder(200);
        var offset = Upzp.PlayerInput.Input.CreateInput(biuld, 1, 0, false, 0, true);
        Upzp.PlayerInput.Input.FinishInputBuffer(biuld, offset);
        var mess = biuld.SizedByteArray();
        Debug.Log(Communication.SendToGame(new Message(mess, 101)));
       
    }
     
}
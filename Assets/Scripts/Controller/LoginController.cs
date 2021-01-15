using System;
using FlatBuffers;
using Networking;
using UnityEngine;
using mainServer.schemas.FLoggingClient;

public class LoginController : Controller
{
    private LoginHandler loginHandler;

    public static string playerName;

    public void OnOpenScene(string sceneName)
    {
        if (sceneName.Equals("Ekran Logowania"))
        {
            loginHandler = GameObject.FindObjectOfType<LoginHandler>();
            if (!loginHandler)
                throw new Exception("Can't find Login handler class");
            
            Debug.Log("found loging handler");
            loginHandler.addLoginReceivers(Login);
        }
    }

    private void Login(string username, string password)
    {
        playerName = username;
        
        var builder = new FlatBufferBuilder(200);
        
        var l = builder.CreateString(username);
        var h = builder.CreateString(password);
        
        FLoggingClient.StartFLoggingClient(builder);
        FLoggingClient.AddName(builder, l);
        FLoggingClient.AddPassword(builder, h);
        var obj = FLoggingClient.EndFLoggingClient(builder);
        builder.Finish(obj.Value);

        byte[] bytes = builder.SizedByteArray();
        Communication.SendToServer(new Message(bytes, 2));
    }

    public void Receive(Message message)
    {
        Debug.Log(message.Version);
        if (message.Version != 7)
            return;
        
        ControllersManager.Instance.OpenScene("Lista Gier");
    }
}

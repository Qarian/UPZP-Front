using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using mainServer.schemas.FClientId;
using Networking;
using UnityEngine;

public class PlayerIDController : Controller
{
    public static int id;
    
    public void OnOpenScene(string sceneName)
    {
        // nothing
    }

    public void Receive(Message message)
    {
        if (message.Version != 13)
            return;
        
        var buffer = new ByteBuffer(message.Payload);
        FClientId clientId = FClientId.GetRootAsFClientId(buffer);
        id = clientId.Id;

        WaitingRoomPrezenter.userID = id;
    }
}

using System;
using FlatBuffers;
using mainServer.schemas.FWaitingRoom;
using Networking;
using UnityEngine;

public class WaitingRoomController : Controller
{
    public WaitingRoomInfo currentWaitingRoom;

    private WaitingRoomPrezenter prezenter;

    public void OnOpenScene(string sceneName)
    {
        if (sceneName.Equals("Lista Gier"))
            currentWaitingRoom = null;
        
        else if (sceneName.Equals("Szczegóły gry"))
        {
            prezenter = GameObject.FindObjectOfType<WaitingRoomPrezenter>();
            if (!prezenter)
                throw new Exception("Can't find games list prezenter");
            if (currentWaitingRoom != null)
                prezenter.UpdateInfo(currentWaitingRoom);
        }
    }

    public void Receive(Message message)
    {
        if (message.Version != 4)
            return;
        
        ControllersManager.Instance.OpenScene("Szczegóły gry");
        
        var buffer = new ByteBuffer(message.Payload);
        FWaitingRoom roomInfo = FWaitingRoom.GetRootAsFWaitingRoom(buffer);
        currentWaitingRoom = new WaitingRoomInfo(roomInfo);
        prezenter?.UpdateInfo(currentWaitingRoom, true);
    }
}

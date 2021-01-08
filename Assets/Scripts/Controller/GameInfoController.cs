using FlatBuffers;
using mainServer.schemas.FWaitingRoom;
using Networking;

public class GameInfoController : Controller
{
    private FWaitingRoom currentRoom;
    
    public void OnOpenScene(string sceneName)
    {
        //nothing
    }

    public void Receive(Message message)
    {
        if (message.Version != 4)
            return;

        var buffer = new ByteBuffer(message.Payload);
        currentRoom = FWaitingRoom.GetRootAsFWaitingRoom(buffer);
    }
}

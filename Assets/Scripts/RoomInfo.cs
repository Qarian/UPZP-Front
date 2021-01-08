using mainServer.schemas.FWaitingRoomsList;

public struct RoomInfo
{
    public int id;
    public string city;
    public int host;
    public int currentPlayers;
    public int maxPlayers;
    public bool status;
    
    public RoomInfo(FWaitingRoom waitingRoom)
    {
        city = waitingRoom.City;
        id = waitingRoom.Id;
        host = waitingRoom.Host;
        currentPlayers = waitingRoom.ClientsLogged;
        maxPlayers = waitingRoom.ClientsMax;
        status = waitingRoom.Status;
    }
}

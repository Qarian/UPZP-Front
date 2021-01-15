using mainServer.schemas.FWaitingRoomsList;

public struct GameInfo
{
    public readonly int id;
    public readonly string city;
    public readonly string host;
    public readonly int currentPlayers;
    public readonly int maxPlayers;
    public readonly bool status;
    
    public GameInfo(FWaitingRoom waitingRoom)
    {
        id = waitingRoom.Id;
        city = waitingRoom.City;
        host = waitingRoom.Host;
        currentPlayers = waitingRoom.ClientsLogged;
        maxPlayers = waitingRoom.ClientsMax;
        status = waitingRoom.Status;
    }
}

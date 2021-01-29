using System;
using FlatBuffers;
using Networking;
using UnityEngine;
using mainServer.schemas.FWaitingRoomsList;

public class GamesListController : Controller
{
    private GamesListPrezenter gamesListPrezenter;

    private GameInfo[] rooms;

    public void OnOpenScene(string sceneName)
    {
        if (!sceneName.Equals("Lista Gier"))
            return;

        gamesListPrezenter = GameObject.FindObjectOfType<GamesListPrezenter>();
        if (!gamesListPrezenter)
            throw new Exception("Can't find games list prezenter");
        if (rooms != null)
            gamesListPrezenter.UpdateList(rooms);
    }

    public void Receive(Message message)
    {
        if (message.Version != 7)
            return;
        Communication.CloseGame();
        string debugText = "";
        var buffer = new ByteBuffer(message.Payload);
        FWaitingRoomsList roomsList = FWaitingRoomsList.GetRootAsFWaitingRoomsList(buffer);
        /*debugText += $"New list arrived!\nAmount of games: {roomsList.WaitingRoomLength}\n";
        for (int i = 0; i < roomsList.WaitingRoomLength; i++)
        {
            var room = roomsList.WaitingRoom(i).Value;
            debugText += $"City:\t{room.City}, Players:\t{room.ClientsLogged}/{room.ClientsLogged}, Host:\t{room.Host}\n";
        }
        Debug.Log(debugText);*/
        
        rooms = new GameInfo[roomsList.WaitingRoomLength];
        for (int i = 0; i < roomsList.WaitingRoomLength; i++)
        {
            rooms[i] = new GameInfo(roomsList.WaitingRoom(i).Value);
        }
        gamesListPrezenter?.UpdateList(rooms, true);
    }
}

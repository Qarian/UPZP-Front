using System;
using FlatBuffers;
using Networking;
using UnityEngine;
using TMPro;
using mainServer.schemas.FWaitingRoomsList;

[RequireComponent(typeof(TMP_Text))]
public class LoggerTMP : MonoBehaviour
{
    private TMP_Text text;

    private string tmpLog = string.Empty;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(tmpLog))
            return;
        
        text.text += tmpLog;
        tmpLog = String.Empty;
    }

    private void OnEnable()
    {
        Communication.Listeners += InterpreteData;
    }

    private void OnDisable()
    {
        Communication.Listeners -= InterpreteData;
    }

    private void InterpreteData(Message message)
    {
        if (message == null)
            return;
        
        if (message.Version == 7)
        {
            var buffer = new ByteBuffer(message.Payload);
            FWaitingRoomsList list = FWaitingRoomsList.GetRootAsFWaitingRoomsList(buffer);
            
            tmpLog += $"\n\n\nNew list arrived!\nAmount of games: {list.WaitingRoomLength}\n";
            int j = 0;
            while (true)
            {
                if (list.WaitingRoom(j).HasValue)
                {
                    var room = list.WaitingRoom(j).Value;
                    tmpLog += $"City:\t{room.City}, Players:\t{room.ClientsLogged}/{room.ClientsLogged}, Host:\t{room.Host}\n";
                    j++;
                }
                else
                {
                    break;
                }
            }
            
            for (int i = 0; i < list.WaitingRoomLength; i++)
            {
                var room = list.WaitingRoom(i).Value;
                tmpLog += $"City:\t{room.City}, Players:\t{room.ClientsLogged}/{room.ClientsLogged}, Host:\t{room.Host}\n";
            }
        }
        else
        {
            tmpLog += $"Unexpected version: {message.Version}\n";
            
        }
    }
}

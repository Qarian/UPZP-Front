using System.Collections;
using System.Collections.Generic;
using Networking;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.Types;

public class RoomInfoDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text name = default;
    [SerializeField] private TMP_Text city = default;
    [SerializeField] private TMP_Text players = default;
    [SerializeField] private TMP_Text status = default;

    private int id;

    public void Initialize(RoomInfo info)
    {
        name.text = info.host.ToString();
        city.text = info.city;
        players.text = $"{info.currentPlayers}/{info.maxPlayers}";
        status.text = info.status ? "In progress" : "Waiting";
        id = info.id;
    }
    
    public void SelectRoom()
    {
        Communication.SendToServer(new Message(Serializer.ChooseRoom(id), 6));
    }
}

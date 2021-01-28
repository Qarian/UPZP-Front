using Networking;
using TMPro;
using UnityEngine;

public class WaitingRoomPrezenter : MonoBehaviour
{
    [SerializeField] private WaitingRoomPlayerInfo playerInfoPrefab = default;
    [SerializeField] private Sprite pedestrianIcon;
    [SerializeField] private Sprite cyclistIcon;
    [SerializeField] private Sprite carIcon;
    
    [Space]
    [SerializeField] private Transform team1 = default;
    [SerializeField] private Transform team2 = default;

    [SerializeField] private TMP_Text city;
    [SerializeField] private TMP_Text players;
        
    [SerializeField] private GameObject startGame = default;
    public static int userID;
    
    
    private WaitingRoomInfo gameInfo;

    private void Update()
    {
        if (gameInfo != null)
        {
            UpdateInfo(gameInfo);
            gameInfo = null;
        }
    }
    
    public void SetNewVehicle(int newVehicle)
    {
        Communication.SendToServer(new Message(Serializer.NewVehicle(newVehicle), 8));
    }

    public void GoBack()
    {
        Communication.SendToServer(new Message(Serializer.SimpleMessage(1), 3));
        ControllersManager.Instance.OpenScene("Lista Gier");
    }

    public void StartGame()
    {
        Communication.SendToServer(new Message(Serializer.SimpleMessage(0), 3));
    }

    public void UpdateInfo(WaitingRoomInfo data, bool onNextFrame = false)
    {
        if (onNextFrame)
        {
            gameInfo = data;
            return;
        }

        foreach (Transform child in team1)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in team2)
        {
            Destroy(child.gameObject);
        }

        city.text = data.city;

        int team1Size = data.teams[0].Length;
        int team2Size = data.teams[1].Length;
        players.text = $"{team1Size + team2Size}\\{data.maxClients}";
        
        for (int i = 0; i < team1Size; i++)
        {
            SpawnPlayerInfo(data.teams[0][i], team1);
        }
        for (int i = 0; i < team2Size; i++)
        {
            SpawnPlayerInfo(data.teams[1][i], team2);
        }

        startGame.SetActive(userID == data.host);
    }

    private void SpawnPlayerInfo(WaitingRoomInfo.Player player, Transform team)
    {
        Sprite icon;
        switch (player.Vehicle)
        {
            case WaitingRoomInfo.Vehicle.Pedestrian:
                icon = pedestrianIcon;
                break;
            case WaitingRoomInfo.Vehicle.Cyclist:
                icon = cyclistIcon;
                break;
            case WaitingRoomInfo.Vehicle.Car:
            default:
                icon = carIcon;
                break;
        }
        
        Instantiate(playerInfoPrefab, team).Initialize(icon, player.name);

        if (player.name == LoginController.playerName)
            userID = player.id;
    }
}

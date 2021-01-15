
using UnityEngine;

public class GamesListPrezenter : MonoBehaviour
{
    [SerializeField] private RoomInfoDisplayer roomRowPrefab = default;
    [SerializeField] private Transform listParent = default;

    private GameInfo[] roomsToUpdate;

    private void Update()
    {
        if (roomsToUpdate != null)
        {
            UpdateList(roomsToUpdate);
            roomsToUpdate = null;
        }
    }

    public void UpdateList(GameInfo[] rooms, bool onNextFrame = false)
    {
        if (onNextFrame)
        {
            roomsToUpdate = rooms;
            return;
        }
        
        foreach (Transform child in listParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < rooms.Length; i++)
        {
            Instantiate(roomRowPrefab, listParent).Initialize(rooms[i]);
        }
    }
}

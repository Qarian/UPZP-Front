using UnityEngine;

public class GamesListPrezenter : MonoBehaviour
{
    [SerializeField] private RoomInfoDisplayer roomRowPrefab = default;
    [SerializeField] private Transform listParent = default;
    
    public void UpdateList(RoomInfo[] rooms)
    {
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

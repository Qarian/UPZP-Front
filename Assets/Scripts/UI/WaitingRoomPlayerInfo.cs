using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomPlayerInfo : MonoBehaviour
{
    [SerializeField] private Image icon = default;
    [SerializeField] private TMP_Text name = default;

    public void Initialize(Sprite sprite, string username)
    {
        icon.sprite = sprite;
        name.text = username;
    }
}

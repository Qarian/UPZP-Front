using System;
using Networking;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CreateNewGame : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown city = default;
        [SerializeField] private TMP_InputField name = default;
        [SerializeField] private TMP_InputField maxClients = default;
        [SerializeField] private Button button = default;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (string.IsNullOrWhiteSpace(name.text))
                return;
            byte[] message = Serializer.NewGameCreated(city.options[city.value].text, name.text, int.Parse(maxClients.text));
            Communication.SendToServer(new Message(message, 5));
        }
    }
}
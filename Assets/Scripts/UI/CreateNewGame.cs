using System;
using Networking;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CreateNewGame : MonoBehaviour
    {
        [SerializeField] private TMP_InputField city = default;
        //[SerializeField] private TMP_InputField name = default;
        [SerializeField] private TMP_InputField maxClients = default;
        [SerializeField] private Button button = default;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            byte[] message = Serializer.NewGameCreated(city.text, "default name", int.Parse(maxClients.text));
            Communication.SendToServer(new Message(message, 5));
        }
    }
}
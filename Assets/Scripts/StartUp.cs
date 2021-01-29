using Networking;
using TMPro;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField iP = default;
    [SerializeField] private TMP_InputField port = default;
    [SerializeField] private string firstScene;
    [SerializeField] private bool isServer;

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if (isServer)
        {
            if (Communication.InitializeServer(iP.text, int.Parse(port.text)))
                ControllersManager.Instance.OpenScene(firstScene);
        }
        else
        {
            Communication.InitializeGame(iP.text, int.Parse(port.text));
        }
    }
}

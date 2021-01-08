using Networking;
using TMPro;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField iP = default;
    [SerializeField] private TMP_InputField port = default;
    
    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if (Communication.InitializeServer(iP.text, int.Parse(port.text)))
            ControllersManager.Instance.OpenScene("Ekran Logowania");
    }
}

using FlatBuffers;
using Networking;
using TMPro;
using UnityEngine;
using mainServer.schemas.FError;

public class ErrorController : MonoBehaviour, Controller
{
    [SerializeField] private TMP_Text text = default;

    private void Awake()
    {
        gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void OnOpenScene(string sceneName)
    {
        //Do nothing
    }

    public void Receive(Message message)
    {
        if (message.Version != 1)
            return;
        
        gameObject.SetActive(true);
        var buffer = new ByteBuffer(message.Payload);
        FError error = FError.GetRootAsFError(buffer);
        text.text = error.Message;
    }
}

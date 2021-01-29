using FlatBuffers;
using Networking;
using TMPro;
using UnityEngine;
using mainServer.schemas.FError;

public class ErrorController : MonoBehaviour, Controller
{
    [SerializeField] private TMP_Text errorText = default;
    [SerializeField] private Canvas errorCanvas = default;

    private string errorToDisplay;

    private void Awake()
    {
        errorCanvas.enabled = false;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(errorToDisplay))
        {
            errorCanvas.enabled = true;
            errorText.text = errorToDisplay;
            errorToDisplay = null;
        }
    }

    public void OnOpenScene(string sceneName)
    {
        //Do nothing
    }
    

    public void Receive(Message message)
    {
        if (message.Version != 1)
            return;

        var buffer = new ByteBuffer(message.Payload);
        FError error = FError.GetRootAsFError(buffer);
        errorToDisplay = error.Message;
    }
}

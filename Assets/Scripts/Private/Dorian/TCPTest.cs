using FlatBuffers;
using Networking;
using TMPro;
using UnityEngine;
using mainServer.schemas.FLoggingClient;

public class TCPTest : MonoBehaviour
{
    [SerializeField] private TMP_InputField login = default;
    [SerializeField] private TMP_InputField haslo = default;
    [SerializeField] private TMP_InputField iPAddress = default;
    [SerializeField] private TMP_InputField targetPort = default;

    public void Connect()
    {
        if (Communication.InitializeServer(iPAddress.text, int.Parse(targetPort.text)))
            Communication.Listeners += ReadData;
    }

    public void SendData()
    {
        var builder = new FlatBufferBuilder(200);
        
        var l = builder.CreateString(login.text);
        var h = builder.CreateString(haslo.text);
        
        FLoggingClient.StartFLoggingClient(builder);
        FLoggingClient.AddName(builder, l);
        FLoggingClient.AddPassword(builder, h);
        var obj = FLoggingClient.EndFLoggingClient(builder);
        builder.Finish(obj.Value);
        

        byte[] bytes = builder.SizedByteArray();
        Communication.SendToServer(new Message(bytes, 2));
    }

    private void ReadData(Message message)
    {
        Debug.Log($"Received payload version: {message.Version}");
    }
}

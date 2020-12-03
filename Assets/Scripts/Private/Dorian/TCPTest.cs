using System.Collections;
using System.Collections.Generic;
using Exensions;
using FlatBuffers;
using Networking;
using TestData;
using TMPro;
using UnityEngine;

public class TCPTest : MonoBehaviour
{
    [SerializeField] private TMP_InputField posX = default;
    [SerializeField] private TMP_InputField posY = default;
    [SerializeField] private TMP_InputField posZ = default;
    [SerializeField] private TMP_InputField inputInt = default;
    [SerializeField] private TMP_InputField inputString = default;
    [SerializeField] private TMP_InputField iPAddress = default;

    public void Connect()
    {
        Communication.InitializeServer(iPAddress.text,11100);
        Communication.Listeners += ReadData;
    }

    public void SendData()
    {
        var builder = new FlatBufferBuilder(250);
        
        var someString = builder.CreateString(inputString.text);
        var pos = Vec3.CreateVec3(builder,
            float.Parse(posX.text), float.Parse(posY.text), float.Parse(posZ.text));
        
        Tester.StartTester(builder);
        Tester.AddPos(builder, pos);
        Tester.AddSomeInteger(builder, int.Parse(inputInt.text));
        Tester.AddSomeString(builder, someString);
        var testObj = Tester.EndTester(builder);
        builder.Finish(testObj.Value);

        byte[] bytes = builder.SizedByteArray();
        Communication.SendToServer(new Message(bytes, 1));
    }

    private void ReadData(Message message)
    {
        var buffer = new ByteBuffer(message.Payload);
        Tester tester = Tester.GetRootAsTester(buffer);
        Debug.Log($"Integer: {tester.SomeInteger}\n");
        Debug.Log($"String: {tester.SomeString}\n");
        Debug.Log($"Pos: {((Vec3) tester.Pos).ToVector3().ToString()}\n");
    }
}

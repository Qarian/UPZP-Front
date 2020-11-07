using System;
using Exensions;
using FlatBuffers;
using TestData;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Networking
{
    public class FlatbufTest : MonoBehaviour
    {
        [SerializeField] private TMP_InputField posX;
        [SerializeField] private TMP_InputField posY;
        [SerializeField] private TMP_InputField posZ;
        [SerializeField] private TMP_InputField inputInt;
        [SerializeField] private TMP_InputField inputString;
        [SerializeField] private TMP_InputField iPAddress;
        [SerializeField] private TMP_Text logText;
        
        private void Start()
        {
            if (UDP.Instance == null)
                Debug.LogError("UDP nie robi brrrrrr");

            UDP.InterpreteData += ReadData;
        }

        private void Update()
        {
            logText.text += UDP.logText;
            UDP.logText = "";
        }

        public void SendData()
        {
            var builder = new FlatBufferBuilder(256);
            
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
            UDP.SendMessage(bytes, iPAddress.text);
        }

        private void ReadData(byte[] bytes)
        {
            var buffer = new ByteBuffer(bytes);
            Tester tester = Tester.GetRootAsTester(buffer);
            UDP.logText += $"Integer: {tester.SomeInteger}\n";
            UDP.logText += $"String: {tester.SomeString}\n";
            UDP.logText += $"Pos: {((Vec3) tester.Pos).ToVector3().ToString()}\n";
        }
    }
}

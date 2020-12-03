using System;
using Exensions;
using FlatBuffers;
using Networking;
using TestData;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(TMP_Text))]
public class LoggerTMP : MonoBehaviour
{
    private TMP_Text text;

    private string tmpLog = string.Empty;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(tmpLog))
            return;
        
        text.text += tmpLog;
        tmpLog = String.Empty;
    }

    private void OnEnable()
    {
        Communication.Listeners += InterpreteData;
    }

    private void OnDisable()
    {
        Communication.Listeners -= InterpreteData;
    }

    private void InterpreteData(Message message)
    {
        tmpLog += $"Version: {message.Version}\n";
        var buffer = new ByteBuffer(message.Payload);
        Tester tester = Tester.GetRootAsTester(buffer);
        tmpLog += $"Integer: {tester.SomeInteger}\n";
        tmpLog += $"String: {tester.SomeString}\n";
        tmpLog += $"Pos: {((Vec3) tester.Pos).ToVector3().ToString()}\n";
    }
}

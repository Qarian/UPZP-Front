using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using Networking;
using UnityEngine;

public class gameCommunicator : MonoBehaviour
{
    private ulong sequence = 1;
    // Start is called before the first frame update
    void Start()
    {
        SendData(0, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendData(float dir, bool move)
    {
        FlatBufferBuilder biuld = new FlatBufferBuilder(200);
        var offset = Upzp.PlayerInput.Input.CreateInput(biuld, sequence, 0, false, dir, move);
        Upzp.PlayerInput.Input.FinishInputBuffer(biuld, offset);
        var mess = biuld.SizedByteArray();

        Debug.Log(Communication.SendToGame(new Message(mess, 101)));
        sequence++;
    }
}

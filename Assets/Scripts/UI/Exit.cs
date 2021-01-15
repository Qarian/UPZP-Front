using System.Collections;
using System.Collections.Generic;
using Networking;
using UnityEngine;

public class Exit : MonoBehaviour
{   
    public void Quit() {
        Communication.CloseServer();
        Application.Quit();
        Debug.Log("end");
    }

}

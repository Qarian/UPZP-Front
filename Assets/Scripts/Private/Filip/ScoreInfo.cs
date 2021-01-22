using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ScoreInfo : MonoBehaviour
{
    public List<int> scoreList;

    public void Start()
    {
        scoreList = new List<int> { 0, 0, 0, 0, 0, 0 };
    }

    void Update()
    {

    }

    void OnGUI()
    {

        List<Rect> rectObjList = new List<Rect>();
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        for (int i = 0; i < this.scoreList.Count; i++) {
            rectObjList.Add(new Rect(20, i*20+20, 180, 90));
            GUI.Box(rectObjList[i], "Team #" + i + " : " + scoreList[i]
                , style);
        }
    }
}

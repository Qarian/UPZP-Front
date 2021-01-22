using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour {

    GameObject scoreReferenceObject;
    ScoreInfo scoreReferenceScript;

    void Start()
    {
        scoreReferenceObject = GameObject.Find("ScoreInfo");
        scoreReferenceScript = scoreReferenceObject.GetComponent<ScoreInfo>();
        scoreReferenceScript.scoreList[2] = 3;
        scoreReferenceScript.scoreList = new List<int> { 4, 8, 15, 16, 23, 42 };

    }
    void Update()
    {

    }

}

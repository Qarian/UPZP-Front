using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEMETEST : MonoBehaviour
{

    void Start()
    {
        if (!GameObject.FindObjectOfType<ControllersManager>())
        {
            var cm = gameObject.AddComponent<ControllersManager>();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float zoom;
    public float speed = 100.0f;
    public float minY = 5.0f;
    public float maxY = 1000.0f;
    public float ammortization = 0.9f;
    Vector3 tmp_position;
    float curent_speed = 0.0f;

    void Update()
    {
        curent_speed *= ammortization;
        

        if (Input.mouseScrollDelta.y > 0)
        {
            curent_speed += speed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            curent_speed -= speed * Time.deltaTime;
        }
        tmp_position = transform.position + transform.forward * curent_speed;
        if (tmp_position.y< maxY && tmp_position.y> minY) 
        { 
            transform.position = tmp_position;
        }
        
    }
}

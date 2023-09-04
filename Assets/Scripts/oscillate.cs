using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillate : MonoBehaviour
{
    public float length = 2.5f;
    public float midpoint = 0f;
    public string direction = "x";
    public int speed = 2;

    void Update()
    {
        float min = midpoint - length/2;
        if (direction == "x") { 
            Vector3 pos = transform.position;
            pos.x = Mathf.PingPong(Time.time*speed, length) + min;
            transform.position = pos;
        } else {
            Vector3 pos = transform.position;
            pos.z = Mathf.PingPong(Time.time*speed, length) + min;
            transform.position = pos;
        }
    }
}

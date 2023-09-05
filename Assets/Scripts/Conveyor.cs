using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Conveyor : MonoBehaviour
{
    public GameObject ball;
    public string dir = "x";
    public float strength = 0.1f;
    bool go = false;
    Rigidbody rb;

    void Start() {
        ball = GameObject.Find("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter() {
        go = true;
        Debug.Log("GO");
    }

    void OnCollisionExit() {
        go = false;
        Debug.Log("STOP");
    }

    void Update() {
        if (go) {
            if (dir == "x") {
                rb.velocity = rb.velocity + new Vector3(strength, 0, 0);
                //ball.transform.position = ball.transform.position + new Vector3(strenth, 0, 0);
            } else if (dir == "-x") {
                rb.velocity = rb.velocity - new Vector3(strength, 0, 0);
                //ball.transform.position = ball.transform.position - new Vector3(strenth, 0, 0);
            } else if (dir == "z") {
                rb.velocity = rb.velocity + new Vector3(0, 0, strength);
                //ball.transform.position = ball.transform.position + new Vector3(0, 0, strenth);
            } else if (dir == "-z") {
                rb.velocity = rb.velocity - new Vector3(0, 0, strength);
                //ball.transform.position = ball.transform.position - new Vector3(0, 0, strenth);
            }
        }
    }
}

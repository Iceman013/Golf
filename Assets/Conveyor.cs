using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject ball;
    public string dir = "x";
    bool go = false;

    void Start() {
        ball = GameObject.Find("Ball");
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
                ball.transform.position = ball.transform.position + new Vector3(.1f, 0, 0);
            } else if (dir == "-x") {
                ball.transform.position = ball.transform.position - new Vector3(.1f, 0, 0);
            } else if (dir == "z") {
                ball.transform.position = ball.transform.position + new Vector3(0, 0, .1f);
            } else if (dir == "-z") {
                ball.transform.position = ball.transform.position - new Vector3(0, 0, .1f);
            }
        }
    }
}

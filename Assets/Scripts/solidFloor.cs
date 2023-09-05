using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class solidFloor : MonoBehaviour
{
    public GameObject ball;
    int times = 0;
    Vector3[] ballDrops = {
        new Vector3(5, 1, 25),
        new Vector3(-40, 1, 30.5f)
    };

    void Start() {
        ball = GameObject.Find("Ball");
    }

    void OnCollisionEnter() {
        teleport(ballDrops[times]);
        times++;
    }

    void teleport(Vector3 pos) {
        ball.transform.position = pos;
    }
}

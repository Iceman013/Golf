using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    string[] lvls = {
        "SampleScene", "Stage_02"
    };

    void OnCollisionEnter() {
        Debug.Log(SceneManager.GetActiveScene().name);
        int lvPos = Array.IndexOf(lvls, SceneManager.GetActiveScene().name);
        Debug.Log(lvPos);
        if (lvPos + 1 < lvls.Length) {
            Debug.Log(lvls[lvPos + 1]);
            SceneManager.LoadScene(lvls[lvPos + 1]);
        } else {
            Debug.Log("WIN");
        }
    }
}

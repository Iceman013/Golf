using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class edges : MonoBehaviour
{
    void OnTriggerEnter() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

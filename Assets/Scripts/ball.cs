using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour {
    // Physics
    private float strength = 5;
    private double strengthScale = 3;
    private double minVelocity = 1;
    // Behavior
    private bool dragging = false;
    private Vector3 dragStart;
    // This
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Process a mouse button click.
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider == gameObject.GetComponent<Collider>()) {
                    dragging = true;
                    dragStart = hit.point;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && dragging) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                dragging = false;
                Vector3 dragEnd = hit.point;
                Debug.Log(getStrength(dragStart.x, dragEnd.x));
                rb.AddForce(new Vector3(
                    getStrength(dragStart.x, dragEnd.x),
                    0,
                    getStrength(dragStart.z, dragEnd.z)
                ));
            }
        }
        if (Input.GetKeyDown("space")) {
            Debug.Log("SPACE BAR");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Math.Pow((double)rb.velocity.x, 2) + Math.Pow((double)rb.velocity.y, 2) + Math.Pow((double)rb.velocity.z, 2) < Math.Pow(minVelocity, 2)) {
            rb.velocity = new Vector3(0, 0, 0);
            //Debug.Log("stopped");
        } else {
            Debug.Log(Math.Pow((double)rb.velocity.x, 2) + Math.Pow((double)rb.velocity.y, 2) + Math.Pow((double)rb.velocity.z, 2));
        }
    }

    private float getStrength(float start, float end) {
        float magnitude;
        if (start > end) {
            magnitude = 1;
        } else if (start < end) {
            magnitude = -1;
        } else {
            return 0;
        }
        float distance = magnitude*(start - end);
        float scaled = strength*(float)Math.Pow((double)distance, strengthScale);
        if (scaled > 5000) {
            scaled = 5000;
        }
        return magnitude*scaled;
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Ouch");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour {
    // Physics
    private float strength = 40;
    private double minVelocity = 1;
    private double maxForce = 1000;
    // Behavior
    private bool dragging = false;
    private bool stopped = false;
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
            beginDragging();
        }
        if (dragging && Input.GetMouseButtonUp(0)) {
            endDragging();
        }
        if (Input.GetKeyDown("space")) {
            Debug.Log("SPACE BAR");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Math.Pow((double)rb.velocity.x, 2) + Math.Pow((double)rb.velocity.y, 2) + Math.Pow((double)rb.velocity.z, 2) < Math.Pow(minVelocity, 2)) {
            rb.velocity = new Vector3(0, 0, 0);
            //Debug.Log("stopped");
        } else {
            //Debug.Log(Math.Pow((double)rb.velocity.x, 2) + Math.Pow((double)rb.velocity.y, 2) + Math.Pow((double)rb.velocity.z, 2));
        }
    }

    private void beginDragging() {
        rb.velocity = new Vector3(0, 0, 0);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider == gameObject.GetComponent<Collider>()) {
                dragging = true;
                dragStart = pointAtBallHeight();
            }
        }
    }

    private Vector3 pointAtBallHeight() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 camPos = ray.origin;
        Vector3 ballPos = transform.position;

        double xComponent = (double)Vector3.Angle(ray.direction, Vector3.right);
        double yComponent = (double)Vector3.Angle(ray.direction, Vector3.up);
        double zComponent = (double)Vector3.Angle(ray.direction, Vector3.forward);

        double magnitude = (double)(camPos.y - ballPos.y)*Math.Tan((180 - yComponent)*(Math.PI/180));

        double xPoint = (double)camPos.x + magnitude*Math.Cos(xComponent*(Math.PI/180));
        double yPoint = (double)ballPos.y;
        double zPoint = (double)camPos.z + magnitude*Math.Cos(zComponent*(Math.PI/180));
        Vector3 output = new Vector3((float)xPoint, (float)yPoint, (float)zPoint);

        return output;
    }

    private void endDragging() {
        Vector3 dragEnd = pointAtBallHeight();
        dragging = false;
        Vector3 force = new Vector3(
            getStrength(dragStart.x, dragEnd.x),
            0,
            getStrength(dragStart.z, dragEnd.z)
        );
        double totalStrength = Math.Sqrt(Math.Pow((double)force.x, 2) + Math.Pow((double)force.z, 2));
        if (totalStrength >= maxForce) {
            force.x = (float)(maxForce/totalStrength)*force.x;
            force.z = (float)(maxForce/totalStrength)*force.z;
        }
        rb.AddForce(force);
    }

    private float getStrength(float start, float end) {
        return strength*(start - end);
    }

    void OnCollisionEnter(Collision collision) {
        //Debug.Log("Ouch");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    // Control Sensativity
    private float sensitivity = 3;
    private double zoom = 0.8;
    // Measurements
    private bool rightMouse = false;
    private Vector3 relativePosition;

    // Start is called before the first frame update
    void Start() {
        updateRelativePosition();
    }

    private Vector3 getRelativePosition() {
        Vector3 camPos = transform.position;
        Vector3 ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
        Vector3 output = new Vector3(camPos.x - ballPos.x, camPos.y - ballPos.y, camPos.z - ballPos.z);
        return output;
    }
    private void updateRelativePosition() {
        relativePosition = getRelativePosition();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            Vector3 camPos = transform.position;
            Vector3 ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
            transform.position = new Vector3(
                (float)(zoom*camPos.x + (1 - zoom)*ballPos.x),
                (float)(zoom*camPos.y + (1 - zoom)*ballPos.y),
                (float)(zoom*camPos.z + (1 - zoom)*ballPos.z));
            
            updateRelativePosition();
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            Vector3 camPos = transform.position;
            Vector3 ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
            transform.position = new Vector3(
                (float)(ballPos.x + (1/zoom)*(camPos.x - ballPos.x)),
                (float)(ballPos.y + (1/zoom)*(camPos.y - ballPos.y)),
                (float)(ballPos.z + (1/zoom)*(camPos.z - ballPos.z)));
            
            updateRelativePosition();
        }
        if (Input.GetMouseButtonDown(1)) {
            rightMouse = true;
        }
        if (Input.GetMouseButtonUp(1)) {
            rightMouse = false;
        }

        if (getRelativePosition() != relativePosition) {
            Vector3 ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
            transform.position = new Vector3(relativePosition.x + ballPos.x, relativePosition.y + ballPos.y, relativePosition.z + ballPos.z);
        }
    }

	void FixedUpdate () {
        if (rightMouse) {
            float rotateHorizontal = Input.GetAxis("Mouse X");
		    float rotateVertical = Input.GetAxis("Mouse Y");
            transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, -Vector3.up, rotateHorizontal * sensitivity);
	    	transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, transform.right, rotateVertical * sensitivity);
            if (transform.localEulerAngles.x <= 30 || transform.localEulerAngles.x >= 60) {
                transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, transform.right, -rotateVertical * sensitivity);
            }
            updateRelativePosition();
        }
	}
}
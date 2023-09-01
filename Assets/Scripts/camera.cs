using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    private float sensitivity = 5;
    private double zoom = 0.8;
    private bool rightMouse = false;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("Camera Up");
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
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            Vector3 camPos = transform.position;
            Vector3 ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
            transform.position = new Vector3(
                (float)(ballPos.x + (1/zoom)*(camPos.x - ballPos.x)),
                (float)(ballPos.y + (1/zoom)*(camPos.y - ballPos.y)),
                (float)(ballPos.z + (1/zoom)*(camPos.z - ballPos.z)));
        }
        if (Input.GetMouseButtonDown(1)) {
            rightMouse = true;
        }
        if (Input.GetMouseButtonUp(1)) {
            rightMouse = false;
        }
    }

	void FixedUpdate () {
		float rotateHorizontal = Input.GetAxis("Mouse X");
		float rotateVertical = Input.GetAxis("Mouse Y");
        if (rightMouse) {
            transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, -Vector3.up, rotateHorizontal * sensitivity);
	    	transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, transform.right, rotateVertical * sensitivity);
            if (transform.position.y <= 0 || transform.localEulerAngles.z >= 90) {
                transform.RotateAround(GameObject.FindGameObjectWithTag("Ball").transform.position, transform.right, -rotateVertical * sensitivity);
            }
        }
	}
}

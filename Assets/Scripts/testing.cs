using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Debug.Log("owo");
    }

    // Update is called once per frame
    void Update() {
        // Process a mouse button click.
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HI!");
            }
        }
    }
}

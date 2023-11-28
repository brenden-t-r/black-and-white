using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start() {
        // camera1.enabled = false;
        // camera2.enabled = true;
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("ok");
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}

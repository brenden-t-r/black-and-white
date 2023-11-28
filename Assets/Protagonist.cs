using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    public float speed;
    public float degreesPerSecond;
    public Transform obj;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        degreesPerSecond = -50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputMovement();   
    }

    private void inputMovement() {
        float v = 0;
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        obj.transform.position += tempVect;
        cam.transform.transform.position += tempVect;
        Debug.Log(h);
        Debug.Log(h * degreesPerSecond * Time.deltaTime);
        obj.Rotate(new Vector3(0, 0, h) * degreesPerSecond * Time.deltaTime);
    }
}

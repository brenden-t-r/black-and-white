using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFace : MonoBehaviour
{
    float degreesPerSecond;


    // Start is called before the first frame update
    void Start()
    {
        degreesPerSecond = UnityEngine.Random.Range(-250, 250);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
}

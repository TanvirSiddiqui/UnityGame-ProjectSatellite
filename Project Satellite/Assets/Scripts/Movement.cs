using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }

     void processThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusting -Upward");
        }
       
    }

    void processRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating -Left Side");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating -Right Side");
        }
    }
}

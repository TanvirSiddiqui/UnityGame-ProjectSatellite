using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float mainThrust=100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
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

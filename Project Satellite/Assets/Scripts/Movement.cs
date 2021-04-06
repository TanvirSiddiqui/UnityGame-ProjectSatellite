using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 2f;
    [SerializeField] AudioClip EngineAudio;

    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem rightEngineParticle;
    [SerializeField] ParticleSystem leftEngineParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

     void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(EngineAudio);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

     void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    

    void processRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingRight();
        }
        else
        {
            StopRotating();
        }
    }

     void StopRotating()
    {
        rightEngineParticle.Stop();
        leftEngineParticle.Stop();
    }

    void RotatingRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftEngineParticle.isPlaying)
        {
            leftEngineParticle.Play();
        }
    }

     void RotatingLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightEngineParticle.isPlaying)
        {
            rightEngineParticle.Play();
        }
    }

    void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so that we can manually roate
        transform.Rotate(Vector3.forward*rotateThisFrame*Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so that the physics system can take over
    }
}

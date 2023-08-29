using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotateLeft = 1f;
    [SerializeField] float rotateRight = 1f;
    [SerializeField] float mainThrust = 10f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem sideBoostersParticles;
    [SerializeField] ParticleSystem sideBoostersParticles2;
    [SerializeField] ParticleSystem mainBoosterParticles;

   
    Rigidbody rb;
    AudioSource audioSource;
        
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = rb.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!sideBoostersParticles.isPlaying)
            {
                sideBoostersParticles.Play();
            }

            if (!sideBoostersParticles2.isPlaying)
            {
                sideBoostersParticles2.Play();
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(0, 3.5f, 0 * mainThrust * Time.deltaTime);
                if (!mainBoosterParticles.isPlaying)
                {
                    mainBoosterParticles.Play();
                }
            }

            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        
        else
        {
            audioSource.Stop();
            mainBoosterParticles.Stop();
            sideBoostersParticles.Stop();
            sideBoostersParticles2.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate (0, 0, -rotateLeft);
        }

       else  if (Input.GetKey(KeyCode.D))
       {
            transform.Rotate(0, 0, rotateRight);
       }
    }
}


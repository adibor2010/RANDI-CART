using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HitScripts : MonoBehaviour
{
    [SerializeField] float reloadSceneDelay = 0.5f;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem finishPaticles;
    [SerializeField] ParticleSystem deathParticles;

    AudioSource audioSource;
    
    

    bool isActivating = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (!isActivating)
        {
            if (other.gameObject.tag == "Ground")
            {
                isActivating = true;
                GetComponent<Movement>().enabled = false;
                audioSource.PlayOneShot(death);
                Invoke(nameof(ReloadScene), reloadSceneDelay);
            }

            if (other.gameObject.tag == "Obstecle")
            {
                isActivating = true;
                GetComponent<Movement>().enabled = false;
                deathParticles.Play();
                Invoke(nameof(ReloadScene), reloadSceneDelay);
                audioSource.PlayOneShot(death);
            }

            if (other.gameObject.tag == "Finish")
            {
                isActivating = true;
                audioSource.PlayOneShot(finish);
                finishPaticles.Play(finishPaticles);
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex = 0;
                }
                SceneManager.LoadScene(nextSceneIndex);
            }

        }

    }
        
        



    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class HitScripts : MonoBehaviour
{
    [SerializeField] float reloadSceneDelay = 0.5f;
    
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Invoke(nameof(ReloadScene), reloadSceneDelay);
        }

        if (other.gameObject.tag == "Obstecle")
        {
            GetComponent<Movement>().enabled = false;
            Invoke(nameof(ReloadScene), reloadSceneDelay);
        }

        if (other.gameObject.tag == "Finish")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}

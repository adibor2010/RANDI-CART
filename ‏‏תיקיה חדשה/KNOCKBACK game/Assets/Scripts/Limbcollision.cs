using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbcollision : MonoBehaviour
{
    public Movement movement;

    void Start()
    {
        movement = GameObject.FindObjectOfType<Movement>().GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        movement.isGrounded = true;
    }
}

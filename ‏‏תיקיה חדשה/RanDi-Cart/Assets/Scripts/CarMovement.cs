using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float rotateSpeed = 225f;

    float moveAmount;
    float rotateAmount;

    [SerializeField] int playerNum;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveAmount = moveSpeed * Input.GetAxis($"{playerNum}Vertical");

        rotateAmount = -rotateSpeed * Input.GetAxis($"{playerNum}Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * moveAmount);

        rb.AddTorque(rotateAmount);

        if (Input.GetKey(KeyCode.Space) && playerNum == 1)
        {

        }
    }
}

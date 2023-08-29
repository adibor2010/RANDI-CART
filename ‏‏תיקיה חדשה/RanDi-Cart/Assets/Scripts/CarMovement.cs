using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float rotateSpeed = 225f;

    [SerializeField] float stunnedTimer = 0f;
    [SerializeField] float stunnedTimeRate = 0.5f;

    float moveAmount;
    float rotateAmount;

    [SerializeField] int playerNum;

    Rigidbody2D rb;

    bool isStunned = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isStunned == true)
        {
            StartStunnTimer();
        }
        moveAmount = moveSpeed * Input.GetAxis($"{playerNum}Vertical");

        rotateAmount = -rotateSpeed * Input.GetAxis($"{playerNum}Horizontal");
    }

    private void StartStunnTimer()
    {
        if (stunnedTimer < stunnedTimeRate)
        {
            stunnedTimer += Time.deltaTime;
            if (stunnedTimer >= stunnedTimeRate)
            {
                isStunned = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isStunned == false)
        {
            rb.AddForce(transform.up * moveAmount);
        }
        
        rb.AddTorque(rotateAmount);
    }

    public int GetPlayerNumber()
    {
        return playerNum;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Back"))
        {
            isStunned = true;
            stunnedTimer = 0;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] string powerUpType;

    [SerializeField] GameObject P1UI;
    [SerializeField] GameObject P2UI;
    [SerializeField] GameObject P3UI;
    [SerializeField] GameObject P4UI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            
        }
    }

    public string GetPowerUpType()
    {
        return powerUpType;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] string powerUpType;
    [SerializeField] bool[] playerHasPowerUp = new bool[4];

    [SerializeField] GameObject P1UI;
    [SerializeField] GameObject P2UI;
    [SerializeField] GameObject P3UI;
    [SerializeField] GameObject P4UI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < playerHasPowerUp.Length; i++)
        {
            if (collision.CompareTag($"Player{i + 1}"))
            {
                playerHasPowerUp[i] = true;
            }
        }
    }

    public string GetPowerUpType()
    {
        return powerUpType;
    }

    public bool GetPlayerHasPowerUp(int playerNumber)
    {
        return playerHasPowerUp[playerNumber - 1];
    }
}

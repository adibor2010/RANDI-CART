using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBoxScript : MonoBehaviour
{
    bool startRespawnTimer;
    [SerializeField] float respawnTimeRate = 3f;
    float respawnTime;

    BoxCollider2D boxCollider2D;

    SpriteRenderer spriteRenderer;

    [SerializeField] string[] possiblePowerUpTypes = new string[6];
    [SerializeField] string currentPowerUpType;

    [SerializeField] bool[] playerHasPowerUp = new bool[4];

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (startRespawnTimer == true)
        {
            RespawnTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        for (int i = 0; i < 4; i++)
        {
            if (collision.CompareTag($"Player{i + 1}"))
            {
                currentPowerUpType = possiblePowerUpTypes[Random.Range(0, 6)];

                playerHasPowerUp[i] = true;


                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;

                startRespawnTimer = true;
            }
        }
    }

    void RespawnTimer()
    {
        if (respawnTime < respawnTimeRate)
        {
            respawnTime += Time.deltaTime;

            if (respawnTime >= respawnTimeRate)
            {
                respawnTime = 0;
                startRespawnTimer = false;

                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
            }
        }
    }

    public string GetPowerUpType()
    {
        return currentPowerUpType;
    }

    public bool GetPlayerHasPowerUp(int playerNumber)
    {
        return playerHasPowerUp[playerNumber - 1];
    }
}

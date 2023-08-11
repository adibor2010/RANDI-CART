using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    bool startBigScaleTimer;
    [SerializeField] float bigScaleTimeRate = 3f;
    float bigScaleTime;

    bool startRespawnTimer;
    [SerializeField] float respawnTimeRate = 3f;
    float respawnTime;

    float regularScale = 1f;
    float bigScale = 3f;

    [SerializeField] GameObject mushroomObject;
    CircleCollider2D circleCollider2D;

    GameObject player;

    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (startBigScaleTimer == true)
        {
            BigScaleTimer();
        }
        if (startRespawnTimer == true)
        {
            RespawnTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mushroomObject.SetActive(false);
            circleCollider2D.enabled = false;

            startBigScaleTimer = true;
            bigScaleTime = 0;
            collision.gameObject.transform.localScale =
                new Vector3(bigScale, bigScale, bigScale);

            startRespawnTimer = true;

            player = collision.gameObject;
        }
    }

    void BigScaleTimer()
    {
        if (bigScaleTime < bigScaleTimeRate)
        {
            bigScaleTime += Time.deltaTime;

            if (bigScaleTime >= bigScaleTimeRate)
            {
                startBigScaleTimer = false;
                bigScaleTime = 0;

                player.transform.localScale =
                    new Vector3(regularScale, regularScale, regularScale);
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

                mushroomObject.SetActive(true);
                circleCollider2D.enabled = true;
            }
        }
    }
}
